using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Models
{
    public class Album
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Release_date")]
        public DateOnly ReleaseDate { get; set; }

        public List<Song> Songs { get; set; }
        private Album(int Id, string Title, DateOnly ReleaseDate)
        {
            this.Id = Id;
            this.Title = Title;
            this.ReleaseDate = ReleaseDate;
        }
        public static Album CreateAlbum(int Id, string Title, string ReleaseDate)
        {
            if(Title == null)
            {
                throw new Exception("Название не должно быть пустым");
            }
            if(!DateTime.TryParse(ReleaseDate, out DateTime DateRelease))
            {
                throw new Exception("Неверный формат даты");
            }
            DateOnly Date = DateOnly.Parse(ReleaseDate);
            return new Album(Id, Title, Date);
        }
    }
}
