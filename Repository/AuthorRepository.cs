using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repository.interfaces;

namespace WebApplication2.Repository
{
    /// <summary>
    /// репозиторий для авторов
    /// </summary>
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _context;
        /// <summary>
        /// инициализация зависимости 
        /// </summary>
        public AuthorRepository(ApplicationContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// метод для получения авторов с песнями
        /// </summary>
        /// <returns>список авторов и песен</returns>
        public async Task<List<Author>> GetAuthorWithSongs()
        {
            return await _context.Authors
                .Include(s => s.playlists)
                .ThenInclude(pl => pl.IdSong)
                .ToListAsync();
        }
        /// <summary>
        /// добавление нового автора в бд
        /// </summary>
        public async Task AddAuthorAsync(Author author)
        {
            await _context.AddAsync(author);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// удаление автора из бд
        /// </summary>
        public async Task<int> DeleteAuthorAsync(int id)
        {
            await _context.Authors
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
        /// <summary>
        /// обновление автора в бд
        /// </summary>
        public async Task UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
