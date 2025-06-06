using WebApplication2.Models;
using WebApplication2.Repository.interfaces;
using WebApplication2.Service.Interfaces;

namespace WebApplication2.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumService(IAlbumRepository albumRepository)
        {
            this._albumRepository = albumRepository;
        }
        public async Task<List<Album>> GetAlbumsAsync()
        {
            return await _albumRepository.GetAlbumsAsync();
        }
        public async Task AddAlbumAsync(Album album)
        {
            await _albumRepository.AddAlbumAsync(album);
        }
        public async Task<int> DeleteAlbumAsync(int id)
        {
            return await _albumRepository.DeleteAlbumAsync(id);
        }
        public async Task UpdateAlbumAsync(Album album)
        {
            await _albumRepository.UpdateAlbumAsync(album);
        }
    }
}
