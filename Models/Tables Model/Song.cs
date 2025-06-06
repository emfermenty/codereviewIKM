using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Song
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Duration")]
        public ushort Duration { get; set; }

        [Column("Auditions")]
        public long Auditions { get; set; }

        [Column("Explicit")]
        public bool Explicit { get; set; }

        [Column("AlbumId")]
        public int AlbumId { get; set; }

        public Album Album { get; set; }
        public List<Playlist> playlists { get; set; } = new List<Playlist>();
        private Song(int Id, string Title, ushort Duration, long Auditions, bool Explicit, int AlbumId, List<Playlist> playlists)
        {
            this.Id = Id;
            this.Title = Title;
            this.Duration = Duration;
            this.Auditions = Auditions;
            this.Explicit = Explicit;
            this.AlbumId = AlbumId;
            this.playlists = playlists;
        }
        public static Song CreateSong(int Id, string Title, ushort Duration, long Auditions, bool Explicit, int AlbumId, List<Playlist> playlists)
        {
            if (Title == null)
                throw new Exception("Длина не должна быть null");
            return new Song(Id, Title, Duration, Auditions, Explicit, AlbumId, playlists);
        }
    }
}
