using WebApplication2.Models;
using WebApplication2.Repository.interfaces;
using WebApplication2.Service.Interfaces;

namespace WebApplication2.Service
{
    /// <summary>
    /// Сервис для работы с песнями
    /// </summary>
    public class SongService : ISongService
    {
        private readonly ISongRepository songRepository;
        /// <summary>
        /// инициализирует зависимость от репозитория
        /// </summary>
        public SongService(ISongRepository songRepository)
        {
            this.songRepository = songRepository;
        }
        /// <summary>
        /// получение всех песен с информацией об альбомах
        /// </summary>
        public async Task<List<Song>> GetAllSongsWithAlbumAsync()
        {
            return await songRepository.GetAllSongsWithAlbumAsync();
        }
        /// <summary>
        /// добавляет новую песню
        /// </summary>
        public async Task AddSongAsync(Song song)
        {
            await songRepository.AddSongAsync(song);
        }
        /// <summary>
        /// удаляет песню по id
        /// </summary>
        public async Task<int> DeleteSongAsync(int id)
        {
            return await songRepository.DeleteSongAsync(id);
        }
        /// <summary>
        /// обновляет информацию о песне
        /// </summary>
        public async Task UpdateSongAsync(Song song)
        {
            await songRepository.UpdateSongAsync(song);
        }
    }
}
