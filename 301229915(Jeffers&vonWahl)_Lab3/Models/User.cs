using System.ComponentModel.DataAnnotations;

namespace HuluWeb.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? username { get; set; }
        [Required]
        public string? password { get; set; }
    }
}
