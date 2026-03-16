namespace Practice1Blazor.Models
{
    public class MovieDto
    {
        public int id_movie { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int id_genre { get; set; }
        public string name_genre { get; set; }
        public DateTime release_date { get; set; }
        public double rating { get; set; }
        public string? image_url { get; set; }
    }
}
