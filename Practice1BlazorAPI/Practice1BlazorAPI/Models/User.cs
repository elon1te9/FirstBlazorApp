using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice1BlazorAPI.Models
{
    public class User
    {
        [Key]
        public int id_user { get; set; }       
        public string email { get; set; }
        public string name { get; set; }
        public string about { get; set; }
        public string password { get; set; }

        [Required]
        [ForeignKey("role")]
        public int id_role { get; set; }
        public Role role { get; set; }
    }
}
