namespace Practice1Blazor.Models
{
    public class AuthResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public UserDto user { get; set; }
        public string error { get; set; }
    }
}
