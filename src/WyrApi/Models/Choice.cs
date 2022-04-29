using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WyrApi.Models;

public class Choice
{
  [Required]
  public string Description { get; set; } = string.Empty;
  [JsonIgnore]
  public double Percentage { get; set; }
  [JsonIgnore]
  public int Votes { get; set; }
}