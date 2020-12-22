using System;
using System.Collections.Generic;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var songs = new List<Song>();

            for (var i = 0; i < count; i++)
            {
                var songData = Console.ReadLine().Split('_');

                var type = songData[0];
                var name = songData[1];
                var duration = songData[2];

                var song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Duration = duration;
                songs.Add(song);
            }

            var wantedListType = Console.ReadLine();

            if (wantedListType == "all")
            {
                foreach (var currSong in songs)
                {
                    Console.WriteLine(currSong.Name);
                }
            }
            else
            {
                foreach (var currSong in songs)
                {
                    if (currSong.TypeList == wantedListType)
                    {
                        Console.WriteLine(currSong.Name);
                    }
                }

            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Duration { get; set; }
    }
}