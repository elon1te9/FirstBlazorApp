namespace Practice1Blazor.Models
{
    public class ProfileResponse
    {
        public bool status { get; set; }
        public string error { get; set; }
        public UserDto profile { get; set; }
    }
}
