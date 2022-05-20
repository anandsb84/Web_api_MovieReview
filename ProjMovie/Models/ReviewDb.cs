using System.ComponentModel.DataAnnotations;

namespace ProjMovie.Models
{
    public class ReviewDb
    {
        [Key]
        public int ReviewId { get; set; }

        public string Review { get; set; }

        public int MovieId { get; set; }

        public virtual MovieDb MovieDb { get; set; }
    }
}
