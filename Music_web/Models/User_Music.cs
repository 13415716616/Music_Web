using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Music_web.Models
{
    public class User_Music
    {
        [Key]
        public int id { get; set; }

        public int UserId { get; set; }

        public int MusicId { get; set; }

        public int Album { get; set; }
    }
}
