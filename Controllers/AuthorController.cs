using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service.Interfaces;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorservice;
        public AuthorController(IAuthorService authorservice)
        {
            _authorservice = authorservice;
        }
        [HttpGet]
        public async Task<ActionResult> GetAlbumsAsync()
        {
            return Ok(await _authorservice.GetAuthorsAsync());

        }
        [HttpPost("create")]
        public async Task<ActionResult> CreateSong([FromBody] Author author)
        {
            await _authorservice.AddAuthorAsync(author);
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            return Ok(await _authorservice.DeleteAuthorAsync(id));
        }
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
