using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repository.interfaces;

namespace WebApplication2.Repository
{
    /// <summary>
    /// репозиторий для песен
    /// </summary>
    public class SongRepository : ISongRepository
    {
        private readonly ApplicationContext _context;
        /// <summary>
        /// инициализация зависимости 
        /// </summary>
        public SongRepository(ApplicationContext context)
        {
            _context = context;
        }
        /// <summary>
        /// метод для получения песен вместе с альбомами и плейлистами
        /// </summary>
        /// <returns>список песен с альбомами и плейлистами</returns>
        public async Task<List<Song>> GetAllSongsWithAlbumAsync()
        {
            return await _context.Songs
                .AsNoTracking()
                .Include(a => a.Album)
                .Include(p => p.playlists)
                    .ThenInclude(pl => pl.IdAuthor)
                .ToListAsync();
        }
        /// <summary>
        /// добавление новой песни в бд
        /// </summary>
        public async Task AddSongAsync(Song song)
        {
            if (song.Album != null)
            {
                _context.Entry(song.Album).State = EntityState.Unchanged;
            }
            await _context.AddAsync(song);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// удаление песни из бд
        /// </summary>
        public async Task<int> DeleteSongAsync(int id)
        {
            await _context.Songs
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
        /// <summary>
        /// обновление песни в бд
        /// </summary>
        public async Task UpdateSongAsync(Song song)
        {
            _context.Songs.Update(song);
            await _context.SaveChangesAsync();
        }
    }
}
