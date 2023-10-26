using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MultiTracksAPI.Data.DTOs;
using MultiTracksAPI.Data;

namespace MultiTracksAPI.Services
{
    public class SongService
    {
        private readonly MultiTracksDbContext _context;
        public SongService(MultiTracksDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SongDTO> GetAllSongs()
        {
            // Use the DbContext to query the database and retrieve artists
            return _context.Song
                .Select(song => new SongDTO
                {
                    SongId = song.SongId,
                    DateCreation = song.DateCreation,
                    AlbumId = song.AlbumId,
                    ArtistId = song.ArtistId,
                    Title = song.Title,
                    Bpm = song.Bpm,
                    TimeSignature = song.TimeSignature
                  

                })
                .ToList();
        }
    }
}