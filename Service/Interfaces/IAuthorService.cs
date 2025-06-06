using WebApplication2.Models;

namespace WebApplication2.Service.Interfaces
{
    public interface IAuthorService
    {
        Task AddAuthorAsync(Author author);
        Task<int> DeleteAuthorAsync(int id);
        Task<List<Author>> GetAuthorsAsync();
        Task UpdateAuthorAsync(Author author);
    }
}