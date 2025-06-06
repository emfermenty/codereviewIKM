using WebApplication2.Models;
using WebApplication2.Repository.interfaces;
using WebApplication2.Service.Interfaces;

namespace WebApplication2.Service
{
    /// <summary>
    /// Сервис для работы с авторами
    /// </summary>
    public class AuthorService : IAuthorService
    {
        /// <summary>
        /// инициализирует зависимость от репозитория
        /// </summary>
        private readonly IAuthorRepository _authorrepository;
        public AuthorService(IAuthorRepository authorrepository)
        {
            this._authorrepository = authorrepository;
        }
        /// <summary>
        /// получение всех авторов
        /// </summary>
        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await _authorrepository.GetAuthorWithSongs();
        }
        /// <summary>
        /// добавление авторов
        /// </summary>
        public async Task AddAuthorAsync(Author author)
        {
            await _authorrepository.AddAuthorAsync(author);
        }
        /// <summary>
        /// удаление авторов
        /// </summary>
        public async Task<int> DeleteAuthorAsync(int id)
        {
            return await _authorrepository.DeleteAuthorAsync(id);
        }
        /// <summary>
        /// обновление авторов
        /// </summary>
        public async Task UpdateAuthorAsync(Author author)
        {
            await _authorrepository.AddAuthorAsync(author);
        }
    }
}
