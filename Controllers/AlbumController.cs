using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service.Interfaces;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/album")]
    ///<summary>
    /// контроллер для работы с альбомами
    /// </summary>
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        /// <summary>
        /// получает все альбомы
        /// </summary>
        /// <returns>возвращает в формате json</returns>
        [HttpGet]
        public async Task<ActionResult> GetAlbumsAsync()
        {
            return Ok(await _albumService.GetAlbumsAsync());
            
        }
        /// <summary>
        /// создает новую песню
        /// </summary>
        /// <returns>результат операции</returns>
        [HttpPost("create")]
        public async Task<ActionResult> CreateSong([FromBody] Album album)
        {
            await _albumService.AddAlbumAsync(album);
            return Ok();
        }
        /// <summary>
        /// удаляет
        /// </summary>
        /// <returns>id удаленного</returns>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            return Ok(await _albumService.DeleteAlbumAsync(id));
        }
        /// <summary>
        /// обновление данных альбома
        /// </summary>
        /// <returns>результат операции</returns>
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
