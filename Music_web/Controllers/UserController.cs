using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Music_web.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        private readonly MusicContext _musicContext;
        private readonly IHostingEnvironment _hostingEnv;
        private const bool islogin=false;

        public UserController(MusicContext musicContext, IHostingEnvironment hostingEnv)
        {
            _musicContext = musicContext;
            _hostingEnv = hostingEnv;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User registerUser)
        {
            var a = Request.Form["password1"];var b = Request.Form["password2"];
            if (a != b)
                ViewBag.password = "两次密码不正确";
            if (ModelState.IsValid)
            {
                var num=_musicContext.Users.Count();
                registerUser.UserId = num++;            
                registerUser.User_time=DateTime.Now;
                registerUser.User_password = a;
                try
                {
                    var u = _musicContext.Users.Single(c=> c.User_name == registerUser.User_name);
                    ViewBag.info= "用户名已存在";
                    return View();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _musicContext.Users.Add(registerUser);
                    _musicContext.SaveChanges();
                    return RedirectToAction("Login");
                }
               
            }
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.login = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            //var users = await _userManager.FindByNameAsync(user.User_name);
            try
            {
                var password = _musicContext.Users.Single(b => b.User_name == user.User_name);
                //var result = await _signInManager.PasswordSignInAsync(users, user.User_password, false, false);
                if (password.User_password != null)
                {
                    var claims = new[] { new Claim("username", user.User_name) };
                    var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal user_cookie = new ClaimsPrincipal(claimsidentity);
                    Task.Run(async () =>
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user_cookie);
                    }).Wait();
                    ViewBag.login = "登陆后";
                    user.UserId = password.UserId;
                    HttpContext.Session.SetInt32("Login",user.UserId);
                    HttpContext.Session.SetString("User_name", user.User_name);
                    if(user.User_image!=null)
                    { 
                        HttpContext.Session.SetString("img", user.User_image);
                    }
                    else
                    {
                        HttpContext.Session.SetString("img", "/Src/images/defalut.jpg");
                    }
                   // HttpContext.Response.Cookies.Append("Login", user.UserId.ToString(), new CookieOptions() { HttpOnly = true});
                 //   HttpContext.Response.Cookies.Append("User_name", user.User_name, new CookieOptions() { HttpOnly = true });
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewBag.login = "用户名或密码错误";
            }
            return View(user);
        }

        [Authorize]
        public IActionResult Update_music()
        {
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewBag.img = HttpContext.Session.GetString("img");
            int loginid = (int)HttpContext.Session.GetInt32("Login");
            var userifon = _musicContext.Users.FirstOrDefault(b => b.UserId == loginid);
            ViewData["User"] = userifon;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update_music(Music music)
        {
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewBag.img = HttpContext.Session.GetString("img");
            int loginid = (int)HttpContext.Session.GetInt32("Login");
            var userifon = _musicContext.Users.FirstOrDefault(b => b.UserId == loginid);
            ViewData["User"] = userifon;
            IFormFile file = music.MusicFile;
            if (file == null)
                return View();
            long size = 0;
            var fileName = file.FileName;
            var filetype = Path.GetExtension(fileName);
            var bbb = Path.GetFileNameWithoutExtension(fileName);
            fileName = bbb + filetype;
            fileName = _hostingEnv.WebRootPath + "\\Src\\Music" + $@"\{fileName}";
            size += file.Length;
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            music.Music_size = size.ToString();
            music.MusicId = _musicContext.Musics.Count() + 1;
            music.Music_Url = fileName;
            music.Music_type = filetype;
            _musicContext.Musics.Add(music);
            _musicContext.SaveChanges();
            ViewBag.Message = $"{file.Name}个文件 /{size}字节上传成功!";
            return View();           
        }

        [Authorize]
        public IActionResult User_Setting()
        {
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewBag.img = HttpContext.Session.GetString("img");
            var loginid = HttpContext.Session.GetInt32("Login");
            User user=new User();
            user = _musicContext.Users.Single(u => u.UserId == loginid);
            ViewData["User"] = user;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult User_Setting(User user)
        {
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewBag.img = HttpContext.Session.GetString("img");
            int loginid = (int)HttpContext.Session.GetInt32("Login");
            
            var userifon=_musicContext.Users.FirstOrDefault(b => b.UserId == loginid);
            userifon.User_name = user.User_name;
            userifon.User_email = user.User_email;
            userifon.User_sex = user.User_sex;
            userifon.User_password = user.User_password;
            if (user.User_imageFile != null)
            {
                IFormFile file = user.User_imageFile;
                var fileName = file.FileName;
                var filetype = Path.GetExtension(fileName);
                var bbb = Path.GetFileNameWithoutExtension(fileName);
                fileName = bbb + filetype;
                fileName = _hostingEnv.WebRootPath + "\\Src\\Userimage" + $@"\{fileName}";
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                userifon.User_image = fileName;
            }          
            ViewData["User"] = userifon;
            _musicContext.SaveChanges();
            return View();
        }
     
     public IActionResult Upload_Music()
        {
            return View();
        }

    [Authorize]  
    public void shouchang(long id)
        {
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewBag.img = HttpContext.Session.GetString("img");
            var login_id = HttpContext.Session.GetInt32("Login");
           // Music music = new Music();
            var music =Music_API.My_Musci.Search(id.ToString());
            Music my_music = new Music();
            User_Music user_Music = new User_Music();
            my_music.MusicId =(int) music[0].id;
            my_music.Music_name = music[0].music_name;
            my_music.Music_singer = music[0].music_alname;
            my_music.Music_Url = music[0].musci_url;
            my_music.Music_img = music[0].music_picurl;
            var i = _musicContext.User_Music.Count();
            user_Music.id =++i;
            user_Music.UserId = (int)login_id;
            user_Music.MusicId= (int)id;
            user_Music.Album = (int)music[0].albumid;
            //   my_music.Music_specialName = music[0].album;
            my_music.Music_albumid =(int) music[0].albumid;
            try
            {
                var m = _musicContext.Musics.Single(b => b.MusicId == my_music.MusicId);              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _musicContext.Musics.Add(my_music);
            }
            _musicContext.User_Music.Add(user_Music);
            // _musicContext.User_Musics.c
            _musicContext.SaveChanges();
            Response.Redirect("/User/My_Music");
        }

    [Authorize]
    public IActionResult My_Music()
        {
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewBag.img = HttpContext.Session.GetString("img");
            int loginid = (int)HttpContext.Session.GetInt32("Login");
            var userifon = _musicContext.Users.FirstOrDefault(b => b.UserId == loginid);
            ViewBag.user = userifon;
            IList<User_Music> music = _musicContext.User_Music.Where(b => b.UserId == loginid).ToList();
            IList<Music> songs = new List<Music>();      
            foreach(var s in music) 
            {
                var a = _musicContext.Musics.FirstOrDefault(b => b.MusicId == s.MusicId);
                songs.Add(a);
            }
            ViewBag.songs = songs;
            return View();
        }

      [Authorize]
      public void Lgout()
        {
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewBag.img = HttpContext.Session.GetString("img");
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Redirect("/Home/Index");
            HttpContext.Session.Clear();           
        }
    }
}
