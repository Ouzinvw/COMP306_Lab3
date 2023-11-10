using System.ComponentModel.DataAnnotations;
using Amazon.DynamoDBv2.DataModel;

namespace HuluWeb.Models
{
    [DynamoDBTable("movie")]
    public class Movie
    {
        [DynamoDBHashKey("id")]
        public string? id { get; set; }
        [DynamoDBProperty("uploaderId")]
        public int? uploaderId { get; set; }
        [DynamoDBProperty("title")]
        public string? title { get; set; }
        [DynamoDBProperty("genre")]
        public string? genre { get; set; }
        [DynamoDBProperty("director")]
        public string? director { get; set; }
        [DynamoDBProperty("dateOfRelease")]
        public string? dateOfRelease { get; set; }
        public string? imageUrl { get; set; }
		//public List<Moviecomments>? comments { get; set; }
	}
	//public class Moviecomments
	//{
	//	public string comment { get; set; }
	//	public string userID { get; set; }
	//	public string userTitle { get; set; }
	//	public string userDescription { get; set; }
	//	public DateTime created { get; set; }
	//	public DateTime updated { get; set; }
	//	public string description { get; set; }
	//	public string imageUrl { get; set; }
	//	public string imageTitle { get; set; }
	//	public string imageDescription { get; set; }
	//	public string commenttime { get; set; }
	//	public DateTime PublishedDate { get; set; }
	//	public string commenturl { get; set; }
	//	public bool Visible { get; set; }
	//}
}

