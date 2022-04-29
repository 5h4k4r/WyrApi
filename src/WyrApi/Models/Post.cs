using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WyrApi.Models;

public class Post
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string Id { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public bool Pending { get; set; } = true;
  [Required]
  public Choice FirstChoice { get; set; } = null!;
  [Required]
  public Choice SecondChoice { get; set; } = null!;

}
