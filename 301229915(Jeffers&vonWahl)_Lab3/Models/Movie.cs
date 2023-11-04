using System.ComponentModel.DataAnnotations;

namespace HuluWeb.Models
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public int? uploaderId { get; set; }
        public string? title { get; set; }
        public string? genre { get; set; }
        public string? director { get; set; }
        public string? dateOfRelease { get; set; }
    }
}
