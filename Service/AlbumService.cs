using WebApplication2.Models;
using WebApplication2.Repository.interfaces;
using WebApplication2.Service.Interfaces;

namespace WebApplication2.Service
{
    /// <summary>
    /// Сервис для работы с альбомами
    /// </summary>
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        /// <summary>
        /// инициализирует зависимость от репозитория
        /// </summary>
        public AlbumService(IAlbumRepository albumRepository)
        {
            this._albumRepository = albumRepository;
        }
        /// <summary>
        /// получение всех альбомов
        /// </summary>
        public async Task<List<Album>> GetAlbumsAsync()
        {
            return await _albumRepository.GetAlbumsAsync();
        }
        /// <summary>
        /// добавление альбома
        /// </summary>
        public async Task AddAlbumAsync(Album album)
        {
            await _albumRepository.AddAlbumAsync(album);
        }
        /// <summary>
        /// удаление альбома
        /// </summary>
        public async Task<int> DeleteAlbumAsync(int id)
        {
            return await _albumRepository.DeleteAlbumAsync(id);
        }
        /// <summary>
        /// обновление альбома
        /// </summary>
        public async Task UpdateAlbumAsync(Album album)
        {
            await _albumRepository.UpdateAlbumAsync(album);
        }
    }
}
