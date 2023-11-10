using System.ComponentModel.DataAnnotations;

namespace HuluWeb.Models
{
	public class User
	{
		[Key]
		public int id { get; set; }
		public string? firstname { get; set; }
		public string? lastname { get; set; }
		public int? phonecontact { get; set; }
		public int? age { get; set; }
		public string? emailcontact { get; set; }
		public string? gender { get; set; }
		public string? address { get; set; }
		public string? username { get; set; }
		public string? password { get; set; }
		public string? confirmpassword { get; set; }
	}
}
