using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Author
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Listeners")]
        public int Listeners { get; set; }

        [Column("Description")]
        public string Description { get; set; }
        
        public List<Playlist> playlists { get; set; }

        private Author(int Id, string Name, int Listeners, string Description, List<Playlist> playlists)
        {
            this.Id = Id;
            this.Name = Name;
            this.Listeners = Listeners;
            this.Description = Description;
            this.playlists = playlists;

        }
        public static Author CreateAuthor(int Id, string Name, int Listeners, string Description, List<Playlist> playlists)
        {
            return new Author(Id, Name, Listeners, Description, playlists);
        }
    }
}
