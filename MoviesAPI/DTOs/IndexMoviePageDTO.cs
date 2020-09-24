using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.DTOs
{
    public class IndexMoviePageDTO
    {
        public List<MovieDTO> UpcomingReleases { get; set; } = new List<MovieDTO>();
        public List<MovieDTO> InTheaters { get; set; } = new List<MovieDTO> ();
    }
}
