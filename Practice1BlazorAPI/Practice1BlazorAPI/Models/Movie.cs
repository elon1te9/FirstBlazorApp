using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice1BlazorAPI.Models
{
    public class Movie
    {
        [Key]
        public int id_movie { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime release_date { get; set; }
        public double rating { get; set; }
        public string? image_url { get; set; }

        [Required]
        [ForeignKey("genre")]
        public int id_genre { get; set; }
        public Genre genre { get; set; }

    }
}
