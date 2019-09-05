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
    public class User
    {
        
      
        public int UserId { get; set; }

        [StringLength(15, MinimumLength = 6,ErrorMessage ="用户名长度需要在6-15之间")]       
        [Required(ErrorMessage ="用户名不允许为空")]
        [Display(Name = "用户名")]
        public String User_name { get; set; }


        //[RegularExpression(@"^[A-Z][A-z0-9]*$", ErrorMessage ="密码需要大写")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "密码长度需要在6-15之间")]
        //[Required(ErrorMessage ="密码不能为空")]
        [Display(Name = "用户密码")]        
        public String User_password { get; set; }

        [Display(Name ="性别")]
        public String User_sex { get; set; }

        [EmailAddress(ErrorMessage ="邮箱格式不正确")]
        [Required(ErrorMessage ="邮箱不允许为空")]
        [Display(Name ="电子邮箱")]
        public String User_email { get; set; }

        [Display(Name = "用户头像")]
        public String User_image { get; set; }

        public int User_music { get; set; }//这个是上传歌曲的次数，放着好看QWQ

        public DateTime User_time { get; set; }//这是注册时间，没什么用

        [NotMapped]
        [Display(Name = "用户头像")]
        public IFormFile User_imageFile { get; set; }
    }
}
