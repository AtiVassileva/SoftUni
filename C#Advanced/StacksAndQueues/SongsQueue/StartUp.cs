using System;
using System.Linq;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var givenSongs = Console.ReadLine().Split(", ").ToArray();

            var songsQueue = new Queue<string>(givenSongs);

            while (songsQueue.Any())
            {
                var line = Console.ReadLine();
                var command = line.Split(" ").ToArray();

                switch (command[0])
                {
                    case "Play":
                        songsQueue.Dequeue();
                        break;
                    case "Add":
                        var currentSong = line.Substring(4);
                        if (!songsQueue.Contains(currentSong))
                        {
                            songsQueue.Enqueue(currentSong);
                        }
                        else
                        {
                            Console.WriteLine($"{currentSong} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songsQueue));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}