using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service.Interfaces;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/author")]
    ///<summary>
    /// контроллер для работы с авторами
    /// </summary>
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorservice;
        public AuthorController(IAuthorService authorservice)
        {
            _authorservice = authorservice;
        }
        /// <summary>
        /// получает список всех альбомов
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAlbumsAsync()
        {
            return Ok(await _authorservice.GetAuthorsAsync());

        }
        /// <summary>
        /// создает новую песню
        /// </summary>
        [HttpPost("create")]
        public async Task<ActionResult> CreateSong([FromBody] Author author)
        {
            await _authorservice.AddAuthorAsync(author);
            return Ok();
        }
        /// <summary>
        /// удаляет автора по id
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            return Ok(await _authorservice.DeleteAuthorAsync(id));
        }
        /// <summary>
        /// обновляет данные автора
        /// </summary>
        [HttpPut("edit/{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Author author)
        {
            if (id != author.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            await _authorservice.UpdateAuthorAsync(author);
            return Ok();
        }
    }
}
