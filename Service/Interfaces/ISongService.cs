using WebApplication2.Models;

namespace WebApplication2.Service.Interfaces
{
    public interface ISongService
    {
        Task AddSongAsync(Song song);
        Task<int> DeleteSongAsync(int id);
        Task<List<Song>> GetAllSongsWithAlbumAsync();
        Task UpdateSongAsync(Song song);
    }
}