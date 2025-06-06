using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using WebApplication2.Models;
using WebApplication2.Repository.interfaces;
using WebApplication2.Service.Interfaces;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/songs")]
    ///<summary>
    /// контроллер для работы с песнями
    /// </summary>
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        public SongController(ISongService songService)
        {
            _songService = songService;
        }
        /// <summary>
        /// получает список всех авторов
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<Song>>> GetAllSongsWithAlbum()
        {
            return Ok(await _songService.GetAllSongsWithAlbumAsync());
        }
        /// <summary>
        /// создает нового автора
        /// </summary>
        [HttpPost("create")]
        public async Task<ActionResult> CreateSong([FromBody] Song song)
        {
            await _songService.AddSongAsync(song);
            return Ok();
        }
        /// <summary>
        /// удаляет автора по идентификатору
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            return Ok(await _songService.DeleteSongAsync(id));
        }
        /// <summary>
        /// обновляет данные автора
        /// </summary>
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
