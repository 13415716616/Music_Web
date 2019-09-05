using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_web.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Music_web.Controllers
{
    public class HomeController : Controller
    {
        public MusicContext _MusicContext;

        public IActionResult Index()
        {
            ViewBag.Login = HttpContext.Session.GetInt32("Login");
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewBag.img = HttpContext.Session.GetString("img");
            var music_l = Music_web.Music_API.My_Musci.Search("流行",10);
            var music_g= Music_web.Music_API.My_Musci.Search("古风", 5);
            var music_c= Music_web.Music_API.My_Musci.Search("纯音乐", 5);
            var music_y = Music_web.Music_API.My_Musci.Search("摇滚", 5);
            var music_w = Music_web.Music_API.My_Musci.Search("唯美", 5);
            var music_m = Music_web.Music_API.My_Musci.Search("民谣", 5);
            ViewBag.music_l = music_l;
            ViewBag.music_g = music_g;
            ViewBag.music_c = music_c;
            ViewBag.music_y = music_y;
            ViewBag.music_w = music_w;
            ViewBag.music_m = music_m;
            return View();           
        }

        public HomeController(MusicContext musicContext)
        {
            _MusicContext = musicContext;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Music music)
        {
            //  List<Music> _musics = _MusicContext.Musics.Where(b => b.Music_name.Contains(music.Music_name)).ToList();
            string text = Request.Form["text"];
            IList<Music_API.Music_info> _musics = Music_API.My_Musci.Search(text);
            @ViewData["Music"] = _musics;
            return View(music);
        }

        public IActionResult Privacy()
        {
            return View();
        }
  
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult toalbum(long id)
        //{
        ////    return RedirectToAction("Music", "album?id="+id);
        //   // return View("~/Music/album?id=" + id);
        //}

    }
}
