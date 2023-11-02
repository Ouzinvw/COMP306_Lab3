using System.ComponentModel.DataAnnotations;

namespace HuluWeb.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public int displayOrder { get; set; }
    }
}
