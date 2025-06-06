using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using WebApplication2.Models;
using WebApplication2.Repository.interfaces;
using WebApplication2.Service.Interfaces;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/songs")]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        public SongController(ISongService songService)
        {
            _songService = songService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Song>>> GetAllSongsWithAlbum()
        {
            return Ok(await _songService.GetAllSongsWithAlbumAsync());
        }
        [HttpPost("create")]
        public async Task<ActionResult> CreateSong([FromBody] Song song)
        {
            await _songService.AddSongAsync(song);
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            return Ok(await _songService.DeleteSongAsync(id));
        }
        [HttpPut("edit/{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Song song)
        {
            if (id != song.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            await _songService.UpdateSongAsync(song);
            return Ok();
        }
    }
}
