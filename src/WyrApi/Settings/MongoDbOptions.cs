using System.ComponentModel.DataAnnotations;

namespace WyrApi.Settings;

public class MongoDbOptions
{
  public const string Config = "MongoDb";
  [Required]
  public string DatabaseName { get; set; } = string.Empty;
  [Required]
  public string ConnectionString { get; set; } = string.Empty;
}