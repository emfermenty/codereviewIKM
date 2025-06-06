using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repository.interfaces;

namespace WebApplication2.Repository
{
    /// <summary>
    /// репозиторий для альбомов
    /// </summary>
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ApplicationContext _context;
        /// <summary>
        /// инициализация зависимости 
        /// </summary>
        public AlbumRepository(ApplicationContext context)
        {
            _context = context;
        }
        /// <summary>
        /// метод для получения альбомов
        /// </summary>
        /// <returns>список альбомов</returns>
        public async Task<List<Album>> GetAlbumsAsync()
        {
            return await _context.Albums
                .AsNoTracking()
                .ToListAsync();
        }
        /// <summary>
        /// добавление нового альбома в бд
        /// </summary>
        public async Task AddAlbumAsync(Album album)
        {
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// удаление альбома из бд
        /// </summary>
        public async Task<int> DeleteAlbumAsync(int id)
        {
            await _context.Albums
                 .Where(a => a.Id == id)
                 .ExecuteDeleteAsync();
            return id;
        }
        /// <summary>
        /// обновление альбома в бд
        /// </summary>
        public async Task UpdateAlbumAsync(Album album)
        {
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }
    }
}
