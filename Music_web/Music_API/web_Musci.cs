using NeteaseCloudMusicApi;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Music_web.Music_API
{
    public static class My_Musci
    {
        public static  int i= 0;

        public static List<Music_info> Search(string musicname,int i=10)
        {           
            var api = new NeteaseMusicAPI();
            var apires = api.Search(musicname,i);
            var name = "";
            List<Music_info> musics = new List<Music_info>();          
            name = apires.Result.Songs[0].Ar[0].Name;
            foreach (var song in apires.Result.Songs)
            {
                Music_info music = new Music_info();         
                music.music_name = string.Format("{0}",song.Name);
                music.music_alname = song.Ar[0].Name;
                music.musci_url = api.GetSongsUrl(new long[] { song.Id }).Data[0].Url;
                music.music_picurl = song.Al.PicUrl;
                music.album = song.Al.Name;
                music.id = song.Id;
                music.albumid = song.Al.Id;
                musics.Add(music);               
            }
            return musics;

        }

        public static IList<Album_info> Search_Album(long id,int i=30) 
        {
            var api = new NeteaseMusicAPI();
            var apires = api.Album(id);
            List<Album_info> musics = new List<Album_info>();
            var name = apires.Album.Name;
            var album_username = apires.Album.Artists[0].Name;
            var img = apires.Album.PicUrl;
            int a = 0;          
            foreach (var song in apires.Songs)
            {
                if(a<i)
                {
                Album_info music = new Album_info();
                music.album_username = album_username;
                music.dec = apires.Album.Description.ToString();
                music.music_name = string.Format("{0}", song.Name);
                music.musci_url = api.GetSongsUrl(new long[] { song.Id }).Data[0].Url;
            //    music.music_alname = song.Al.Name;
                music.id = song.Id;
                music.name = name;               
                music.img = img;
                music.singer = song.Ar[0].Name;
                musics.Add(music);
                a++;
                }
                else
                {
                    break;
                }
            }
            return musics;

        }

        static public string MusicJson(string musicid)
        {
            var api = new NeteaseMusicAPI();
            var apires = api.Search(musicid.ToString(), 1);        
            IList<Music_info> muscis = new List<Music_info>();
            var art = new ArtistResult();
            musicplay music = new musicplay();
            i++;
            music.id =i;
            music.song = apires.Result.Songs[0].Name;
            music.singer.name = apires.Result.Songs[0].Ar[0].Name;
            music.time = apires.Result.Songs[0].PublishTime.ToString();
            music.words = api.Lyric(apires.Result.Songs[0].Id).Lrc.Lyric;
            music.src = api.GetSongsUrl(new long[] { apires.Result.Songs[0].Id }).Data[0].Url;
            music.img = apires.Result.Songs[0].Al.PicUrl;
            music.album = apires.Result.Songs[0].Al.Name;
            var a = api.Lyric(apires.Result.Songs[0].Id);
            string output = JsonConvert.SerializeObject(music);
            return output;
        }
    }

  
}
