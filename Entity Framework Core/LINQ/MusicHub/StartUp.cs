using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MusicHub.Data;
using MusicHub.Initializer;

namespace MusicHub
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new MusicHubDbContext();
            DbInitializer.ResetDatabase(context);
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var producer = context.Producers
                .FirstOrDefault(p => p.Id == producerId);

            var albums = context.Albums.Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    a.Name, a.ReleaseDate,
                    AlbumSongs = a.Songs.Select(s => new { s.Name, s.Price, SongWriterName = s.Writer.Name })
                        .OrderByDescending(s => s.Name).ThenBy(s => s.SongWriterName).ToList(),
                    TotalAlbumPrice = a.Price
                }).ToList().OrderByDescending(a => a.TotalAlbumPrice);

            var sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate:MM/dd/yyyy}")
                    .AppendLine($"-ProducerName: {producer?.Name}")
                    .AppendLine("-Songs:");

                var counter = 1;

                foreach (var song in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{counter++}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Price: {song.Price:F2}")
                    .AppendLine($"---Writer: {song.SongWriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Include(s => s.Album)
                .ThenInclude(s => s.Producer)
                .Include(s => s.Writer)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new 
                {
                    SongName = s.Name,
                    PerformerFullName = s.SongPerformers.Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                        .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    s.Duration,

                }).OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                 .ThenBy(s => s.PerformerFullName)
                .ToList();

            var sb = new StringBuilder();
            var counter = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}")
                .AppendLine($"---SongName: {song.SongName}")
                .AppendLine($"---Writer: {song.WriterName}")
                .AppendLine($"---Performer: {song.PerformerFullName}")
                .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                .AppendLine($"---Duration: {song.Duration:c}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}