using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Practice1BlazorAPI.Models
{
    public class Genre
    {
        [Key]
        public int id_genre {  get; set; }
        public string name { get; set; }

        [JsonIgnore]
        public ICollection<Movie> movies { get; set; }

    }
}
