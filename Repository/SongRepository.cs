using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repository.interfaces;

namespace WebApplication2.Repository
{
    public class SongRepository : ISongRepository
    {
        private readonly ApplicationContext _context;
        public SongRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Song>> GetAllSongsWithAlbumAsync()
        {
            return await _context.Songs
                .AsNoTracking()
                .Include(a => a.Album)
                .Include(p => p.playlists)
                    .ThenInclude(pl => pl.IdAuthor)
                .ToListAsync();
        }
        public async Task AddSongAsync(Song song)
        {
            if (song.Album != null)
            {
                _context.Entry(song.Album).State = EntityState.Unchanged;
            }
            await _context.AddAsync(song);
            await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteSongAsync(int id)
        {
            await _context.Songs
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
        public async Task UpdateSongAsync(Song song)
        {
            _context.Songs.Update(song);
            await _context.SaveChangesAsync();
        }
    }
}
