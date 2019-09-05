using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_web.Models;
using System.IO;
using System.Linq;
using Music_web.Music_API;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Music_web.Controllers
{
    public class MusicController : Controller
    {
        private IHostingEnvironment hostingEnv;
        private MusicContext _musicContext;
        private static bool first = false;

        public MusicController(IHostingEnvironment hostingEnv, MusicContext musicContext)
        {
            this.hostingEnv = hostingEnv;
            _musicContext = musicContext;
            if (first == false)
            {
                using (StreamWriter filebase = new StreamWriter(@"F:/web/Music_web/Music_web/wwwroot/js/data.js"))
                {
                    filebase.WriteLine("var data =[]"); first = true;
                }
            }
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Play()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Music music)
        {
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewBag.img = HttpContext.Session.GetString("img");
            IFormFile file=music.MusicFile;
            long size = 0;          
                var fileName = file.FileName;
                var filetype = Path.GetExtension(fileName);
                var bbb = Path.GetFileNameWithoutExtension(fileName);
                //var fileName = ContentDispositionHeaderValue
                //    .Parse(file.ContentDisposition)
                //    .FileName
                //    .Trim('"');
                fileName = bbb + filetype;
                fileName = hostingEnv.WebRootPath+"\\Src\\Music" + $@"\{fileName}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                music.Music_size = size.ToString();
                music.MusicId = _musicContext.Musics.Count()+1;
                music.Music_Url = fileName;
                music.Music_type = filetype;
                _musicContext.Musics.Add(music);
                _musicContext.SaveChanges();
            ViewBag.Message = $"{file.Name}个文件 /{size}字节上传成功!";
            return View();
        }

        public IActionResult Search()
        {
            ViewBag.img = HttpContext.Session.GetString("img");
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            return View();
        }

        [HttpPost]
        public IActionResult Search(string music)
        {
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewBag.img = HttpContext.Session.GetString("img");
            try
            { 
            string text = Request.Form["text"];
            IList<Music_API.Music_info> _musics = Music_API.My_Musci.Search(text);
           // file.WriteLine(Music_API.My_Musci.MusicJson()
            @ViewData["Music"] = _musics;
            return View(music);
            }
            catch
            {
                return View();
            }
        }

        public IActionResult writejson(string id)
        {
            string str;
            string str1 = System.IO.File.ReadAllText(@"F:/web/Music_web/Music_web/wwwroot/js/data.js");
          
           str = str1;
            using (StreamWriter file = new StreamWriter(@"F:/web/Music_web/Music_web/wwwroot/js/data.js"))
            {
                str = str.Replace("]", "");
                file.WriteLine(str+Music_API.My_Musci.MusicJson(id) + ",]");
                file.Flush();
                return View("Play");
            }
        }

        public IActionResult Class(string classname="古风")
        {
            ViewBag.img = HttpContext.Session.GetString("img");
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            IList<Music_info> music = My_Musci.Search(classname);
            ViewData["Music"] = music;
            return View();
        }

        public IActionResult album(long id)
        {
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewBag.img = HttpContext.Session.GetString("img");
            var album =Music_API.My_Musci.Search_Album(id);
            ViewBag.album = album;
            return View();
        }

        
    }
}
