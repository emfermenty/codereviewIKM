using WebApplication2.Models;

namespace WebApplication2.Repository.interfaces
{
    public interface IAlbumRepository
    {
        Task AddAlbumAsync(Album album);
        Task<int> DeleteAlbumAsync(int id);
        Task<List<Album>> GetAlbumsAsync();
        Task UpdateAlbumAsync(Album album);
    }
}