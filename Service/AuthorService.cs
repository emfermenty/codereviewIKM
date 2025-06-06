using WebApplication2.Models;
using WebApplication2.Repository.interfaces;
using WebApplication2.Service.Interfaces;

namespace WebApplication2.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorrepository;
        public AuthorService(IAuthorRepository authorrepository)
        {
            this._authorrepository = authorrepository;
        }
        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await _authorrepository.GetAuthorWithSongs();
        }
        public async Task AddAuthorAsync(Author author)
        {
            await _authorrepository.AddAuthorAsync(author);
        }
        public async Task<int> DeleteAuthorAsync(int id)
        {
            return await _authorrepository.DeleteAuthorAsync(id);
        }
        public async Task UpdateAuthorAsync(Author author)
        {
            await _authorrepository.AddAuthorAsync(author);
        }
    }
}
