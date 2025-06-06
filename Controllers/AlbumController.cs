using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service.Interfaces;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/album")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAlbumsAsync()
        {
            return Ok(await _albumService.GetAlbumsAsync());
            
        }
        [HttpPost("create")]
        public async Task<ActionResult> CreateSong([FromBody] Album album)
        {
            await _albumService.AddAlbumAsync(album);
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            return Ok(await _albumService.DeleteAlbumAsync(id));
        }
        [HttpPut("edit/{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Album album)
        {
            if (id != album.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            await _albumService.UpdateAlbumAsync(album);
            return Ok();
        }
    }
}
