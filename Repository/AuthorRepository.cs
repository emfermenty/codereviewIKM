using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repository.interfaces;

namespace WebApplication2.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _context;
        public AuthorRepository(ApplicationContext context)
        {
            this._context = context;
        }
        public async Task<List<Author>> GetAuthorWithSongs()
        {
            return await _context.Authors
                .Include(s => s.playlists)
                .ThenInclude(pl => pl.IdSong)
                .ToListAsync();
        }
        public async Task AddAuthorAsync(Author author)
        {
            await _context.AddAsync(author);
            await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteAuthorAsync(int id)
        {
            await _context.Authors
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
        public async Task UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
