using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_web.Music_API
{
    public class Music_info
    {
        public long id;
        public long albumid;
        public string music_name;
        public string music_alname;
        public string musci_url;
        public string music_picurl;
        public string album;
    }

    public class Album_info
    {
        public long id;
        public string name;
        public string album_username;
        public string img;
        public string singer;
        public string music_name;
        public string music_alname;
        public string musci_url;
        public string music_picurl;
        public string album;
        public string dec;
    }

    public class musicplay
    {
        public string song { get; set; }
        public int id { get; set; }
        public string time { get; set; }
        public singer singer { get; set; }
        public string words { get; set; }
        public string src { get; set; }
        public string img { get; set; }
        public bool like = true;
        public string album { get; set; }

        public musicplay()
        {
            this.singer = new singer();
        }
    }

    public class singer
    {
        public string name { get; set; }
        public string first { get; set; }
        public string sex { get; set; }
        public string intro { get; set; }
        public string tap { get; set; }
        public string photo { get; set; }
    }
}
