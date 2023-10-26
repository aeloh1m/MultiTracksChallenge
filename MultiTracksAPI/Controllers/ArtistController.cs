using Microsoft.AspNetCore.Mvc;
using MultiTracksAPI.Data.DTOs;
using MultiTracksAPI.Data.Models;
using MultiTracksAPI.Services;

[Route("api.multitracks.com/artist")]
[ApiController]
public class ArtistController : ControllerBase
{
    private readonly ArtistService artistService;


    public ArtistController(ArtistService service)
    {
        artistService = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ArtistDTO>> GetArtists()
    {
        var artists = artistService.GetAllArtists();
        return Ok(artists);
    }

    [HttpGet("{artistId}")]
    public ActionResult<ArtistDTO> GetArtist(int artistId)
    {
        var artist = artistService.GetArtistById(artistId);

        if (artist == null)
        {
            return NotFound();
        }

        return Ok(artist);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<ArtistDTO>> SearchArtists([FromQuery] string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest("Name parameter is required.");
        }

        var artist = artistService.SearchArtistsByName(name);

        if (!artist.Any())
        {
            return NotFound("No artists found for the given name.");
        }

        return Ok(artist);
    }

    [HttpPost("add")] // addNewArtist
    public ActionResult<ArtistDTO> CreateArtist(AddArtistDTO addArtistDTO)
    {
        if (addArtistDTO == null)
        {
            return BadRequest("Invalid artist data");
        }

        var newArtist = artistService.AddArtist(addArtistDTO);

        return CreatedAtAction("GetArtist", new { artistId = newArtist.ArtistId }, newArtist);
    }
    
}