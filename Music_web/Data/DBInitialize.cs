using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_web.Models
{
    public class DBInitialize
    {
        public static void  Initialize(MusicContext musicContext)
        {
            if(musicContext.Users.Any())
                return;
            var user = new User[]
            {
                new User {User_name = "小花", User_password = "123", User_sex = "女"},
                new User {User_name = "小明", User_password = "123", User_sex = "男"},
                new User {User_name = "小云", User_password = "123", User_sex = "女"},
            };
            foreach (User u in user)
            {
                musicContext.Users.Add(u);
            }

            musicContext.SaveChanges();

        }
    }
}
