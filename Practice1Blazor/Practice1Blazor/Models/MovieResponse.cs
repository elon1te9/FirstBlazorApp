namespace Practice1Blazor.Models
{
    public class MovieResponse
    {
        public bool status { get; set; }
        public MovieDto? movie { get; set; }
        public string? error { get; set; }
        public string? message { get; set; }
    }
}
