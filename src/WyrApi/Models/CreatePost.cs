using System.ComponentModel.DataAnnotations;

namespace WyrApi.Models;

public class CreatePost
{
  [Required]
  public Choice FirstChoice { get; set; } = null!;
  [Required]
  public Choice SecondChoice { get; set; } = null!;

  public Post ToPost()
  {
    return new Post
    {
      CreatedAt = DateTime.UtcNow,
      UpdatedAt = DateTime.UtcNow,
      FirstChoice = FirstChoice,
      SecondChoice = SecondChoice
    };
  }
}