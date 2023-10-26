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
            // Using the DbContext to query the database and retrieve artists
            return _context.Song
                .Select(song => new SongDTO
                {
                    SongId = song.SongId,
                    DateCreation = song.DateCreation,
                    AlbumId = song.AlbumId,
                    ArtistId = song.ArtistId,
                    Title = song.Title,
                    Bpm = song.Bpm,
                    TimeSignature = song.TimeSignature,
                    Multitracks = song.Multitracks,
                    CustomMix = song.CustomMix,
                    Chart = song.Chart,
                    RehearsalMix = song.RehearsalMix,
                    Patches = song.Patches,
                    SongSpecificPatches = song.SongSpecificPatches,
                    ProPresenter = song.ProPresenter


                })
                .ToList();
        }

        public IEnumerable<SongDTO> GetSongsWithPaging(int pageSize, int pageNumber)
        {
            // Calculates the number of records to skip based on the page number and page size
            int recordsToSkip = (pageNumber - 1) * pageSize;

            // Useing the DbContext to query the database and retrieve songs with pagination
            return _context.Song
                .Skip(recordsToSkip)  // Skips the specified number of records
                .Take(pageSize)       // Takes the specified number of records for the page
                .Select(song => new SongDTO
                {
                    SongId = song.SongId,
                    DateCreation = song.DateCreation,
                    AlbumId = song.AlbumId,
                    ArtistId = song.ArtistId,
                    Title = song.Title,
                    Bpm = song.Bpm,
                    TimeSignature = song.TimeSignature,
                    Multitracks = song.Multitracks,
                    CustomMix = song.CustomMix,
                    Chart = song.Chart,
                    RehearsalMix = song.RehearsalMix,
                    Patches = song.Patches,
                    SongSpecificPatches = song.SongSpecificPatches,
                    ProPresenter = song.ProPresenter
                })
                .ToList();
        }


    }
}