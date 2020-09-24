using Microsoft.Extensions.Logging;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public class InMemoryRepository : IRepository
    {
        private List<Genre> _genres;
        private readonly ILogger<InMemoryRepository> logger;

        public InMemoryRepository(ILogger<InMemoryRepository> logger)
        {
            _genres = new List<Genre>()
            {
                new Genre() {Id = 1, Name="Comedy" },
                new Genre() {Id = 2, Name="Action" }
            };
            this.logger = logger;
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            logger.LogInformation("Executing get all Genres");
            await Task.Delay(1);
            return _genres;
        }
        public Genre GetGenreById(int id)
        {
            return _genres.FirstOrDefault(g => g.Id == id);
        }

        public void AddGenre(Genre genre)
        {
            genre.Id = _genres.Max(r => r.Id) + 1;
            _genres.Add(genre);
        }
    }
}
