using Microsoft.AspNetCore.Mvc;
using MultiTracksAPI.Data.DTOs;
using MultiTracksAPI.Services;

namespace MultiTracksAPI.Controllers
{
    [Route("api.multitracks.com/song")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly SongService songService;

        public SongController(SongService service)
        {
            songService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SongDTO>> GetSongs()
        {
            var songs = songService.GetAllSongs();
            return Ok(songs);
        }

        [HttpGet("list")] //getSongsByPageSizeAndNumber
        public ActionResult<IEnumerable<SongDTO>> GetSongsWithPaging(int pageSize = 10, int pageNumber = 1)
        {
            if (pageSize <= 0 || pageNumber <= 0)
            {
                return BadRequest("Page size and page number must be positive values.");
            }

            var songs = songService.GetSongsWithPaging(pageSize, pageNumber);

            if (songs.Any())
            {
                return Ok(songs);
            }
            else
            {
                return NotFound("No songs found on this page.");
            }
        }
    }
}