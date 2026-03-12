namespace Practice1Blazor.Models
{
    public class UsersListResponse
    {
        public bool status { get; set; }
        public List<UserDto> users { get; set; }
        public string error { get; set; }
    }
}
