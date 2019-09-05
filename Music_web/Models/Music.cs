using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Music_web.Models
{
    public class Music
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MusicId { get; set; }

        [Display(Name ="歌曲")]
        public string Music_name { get; set; }

        [Display(Name = "演唱者")]
        public string Music_singer { get; set; }

        [Display(Name = "专辑名")]
        public string Music_specialName { get; set; } //专辑名

        public string Music_size { get; set; }
        public string Music_Url { get; set; }
        public string Music_format { get; set; }//文件格式
        public string Music_hits { get; set; }//试听次数
        public string Music_download { get; set; }//下载次数
        public string Music_time { get; set; }//上传时间

        [Display(Name = "歌曲类型")]
        public string Music_type { get; set; }//歌曲类型

        public int Music_albumid { get; set; }


        public string Music_img { get; set; }

        [NotMapped]
        public IFormFile MusicFile { get; set; }
    }
}
