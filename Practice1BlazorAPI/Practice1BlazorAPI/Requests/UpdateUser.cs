namespace Practice1BlazorAPI.Requests
{
    public class UpdateUser
    {
        public int id_user { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string about { get; set; }
        public string password { get; set; }
    }
}
