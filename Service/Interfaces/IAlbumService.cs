using WebApplication2.Models;

namespace WebApplication2.Service.Interfaces
{
    public interface IAlbumService
    {
        Task AddAlbumAsync(Album album);
        Task<int> DeleteAlbumAsync(int id);
        Task<List<Album>> GetAlbumsAsync();
        Task UpdateAlbumAsync(Album album);
    }
}