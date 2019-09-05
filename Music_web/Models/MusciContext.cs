using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace Music_web.Models
{
    public class MusicContext:DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<User_Music> User_Music { get; set; }
    }
}
