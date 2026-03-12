namespace Practice1Blazor.Models
{
    public class MovieListResponse
    {
        public bool status { get; set; }
        public List<MovieDto>? movies { get; set; }
        public string? error { get; set; }
    }
}
