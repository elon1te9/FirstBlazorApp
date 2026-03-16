namespace Practice1Blazor.Models
{
    public class GenreListResponse
    {
        public bool status { get; set; }
        public List<GenreDto>? genres { get; set; }
        public string? error { get; set; }

    }
}
