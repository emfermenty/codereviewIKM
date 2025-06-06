using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repository.interfaces;

namespace WebApplication2.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ApplicationContext _context;
        public AlbumRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Album>> GetAlbumsAsync()
        {
            return await _context.Albums
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task AddAlbumAsync(Album album)
        {
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteAlbumAsync(int id)
        {
            await _context.Albums
                 .Where(a => a.Id == id)
                 .ExecuteDeleteAsync();
            return id;
        }
        public async Task UpdateAlbumAsync(Album album)
        {
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }
    }
}
