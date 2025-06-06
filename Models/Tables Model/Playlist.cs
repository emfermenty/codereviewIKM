using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Playlist
    {
        [Column("songsId")]
        public int IdSong { get; set; }

        [Column("authorsId")]
        public int IdAuthor { get; set; }

        public Playlist(int IdSong, int IdAuthor)
        {
            this.IdSong = IdSong;
            this.IdAuthor = IdAuthor;
        }
    }
}
