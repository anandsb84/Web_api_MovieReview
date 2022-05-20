using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjMovie.Models
{
    public class MovieDb
    {
        [Key]
        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public virtual ICollection<MovieDb> Moviedb { get; set; }
    }
}
