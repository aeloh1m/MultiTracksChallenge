﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MultiTracksAPI.Data;
using MultiTracksAPI.Data.DTOs;

namespace MultiTracksAPI.Services
{
    public class ArtistService
    {
        private readonly MultiTracksDbContext _context;

        public ArtistService(MultiTracksDbContext context)
        {
            artists = new List<ArtistDTO>();
            _context = context;
        }

        public IEnumerable<ArtistDTO> GetAllArtists()
        {
            // Using the DbContext to query the database and retrieve artists
            return _context.Artist
                .Select(artist => new ArtistDTO
                {
                    ArtistId = artist.ArtistId,
                    Title = artist.Title,
                    Biography = artist.Biography,
                    ImageUrl = artist.ImageUrl,
                    HeroUrl = artist.HeroUrl
                })
                .ToList();
        }

        public ArtistDTO GetArtistById(int artistId)
        {
            // Using the DbContext to query the database and retrieve a specific artist by ID
            var artist = _context.Artist.FirstOrDefault(a => a.ArtistId == artistId);

            if (artist != null)
            {
                return new ArtistDTO
                {
                    ArtistId = artist.ArtistId,
                    Title = artist.Title,
                    Biography = artist.Biography,
                    ImageUrl = artist.ImageUrl,
                    HeroUrl = artist.HeroUrl
                };
            }

            return null; // Artist not found
        }

        // Search artist by name
        public IEnumerable<ArtistDTO> SearchArtistsByName(string name)
        {
            return _context.Artist
                .Where(artist => artist.Title.Contains(name)) // Allows to match the column and search criteria
                .Select(artist => new ArtistDTO
                {
                    ArtistId = artist.ArtistId,
                    Title = artist.Title,
                })
                .ToList();
        }

        private List<ArtistDTO> artists;
        private int nextArtistId = 1;
        public ArtistDTO AddArtist(AddArtistDTO addArtistDTO)
        {
            // Creates a new artist from the DTO
            var newArtist = new ArtistDTO
            {
                ArtistId = nextArtistId,
                Title = addArtistDTO.Title,
                Biography = addArtistDTO.Biography,
                ImageUrl = addArtistDTO.ImageUrl,
                HeroUrl = addArtistDTO.HeroUrl
            };

            // Adds the new artist to the list
            artists.Add(newArtist);

            // Increments the artist ID for the next artist
            nextArtistId++;

            return newArtist;
        }
    }
}
