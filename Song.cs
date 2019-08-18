using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary
{
    class Song
    {
        public string Title { get; set;}
        public string MusicFile { get; set;}
        public string MusicImage { get; set;}

        private const string TEXT_FILE_NAME = "Song.txt";

        public static void WriteSong(Song song)
        {
            var songData = $"{song.Title}, {song.MusicFile} , {song.MusicImage}";
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, songData);
        }

        public async static Task<ICollection<Song>> GetAllSongsAsync()
        {
            var songs = new List<Song>();
            var content = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            if (content != null)
            {
                var lines = content.Split('\r', '\n');
                foreach (var line in lines)
                {
                    if (string.IsNullOrEmpty(line))
                        continue;

                    var lineParts = line.Split(',');
                    var song = new Song
                    {
                       Title = lineParts[0],
                       MusicFile = lineParts[1],
                       MusicImage  = lineParts[2]
                    };
                    song.Add(song);
                }
            }

            return songs;
        }

        private void Add(Song song)
        {
            throw new NotImplementedException();
        }
    }

}
