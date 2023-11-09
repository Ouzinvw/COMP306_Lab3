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
    }
}
