using Microsoft.AspNetCore.Mvc;
using MultiTracksAPI.Data.DTOs;
using MultiTracksAPI.Services;

namespace MultiTracksAPI.Controllers
{
    [Route("api/songs")]
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
    }
}