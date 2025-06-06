using WebApplication2.Models;

namespace WebApplication2.Repository.interfaces
{
    public interface IAuthorRepository
    {
        Task AddAuthorAsync(Author author);
        Task<int> DeleteAuthorAsync(int id);
        Task<List<Author>> GetAuthorWithSongs();
        Task UpdateAuthorAsync(Author author);
    }
}