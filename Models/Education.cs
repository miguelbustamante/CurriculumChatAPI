using System.Text.Json.Serialization;

namespace CurriculumChatAPI.Models;
/// <summary>
/// Represents an educational background entry.
/// This class contains properties for the degree, university, and year of graduation.
/// </summary>
public class Education
{
  /// <summary>
  /// Gets or sets the degree obtained.
  /// </summary>
  /// <value>
  /// A string representing the degree, such as "Bachelor of Science" or "Master of Arts".
  /// </value>
  [JsonPropertyName("degree")]
  public string Degree { get; set; } = null!;
  /// <summary>
  /// Gets or sets the name of the university.
  /// </summary>
  /// <value> 
  /// A string representing the university name, such as "Harvard University" or "Stanford University".
  /// </value>
  [JsonPropertyName("university")]
  public string University { get; set; } = string.Empty;
  /// <summary>
  /// Gets or sets the year of graduation.
  /// </summary>
  /// <value>
  /// A string representing the year of graduation, such as "2020" or "2021".
  /// </value>
  [JsonPropertyName("year")]
  public string Year { get; set; } = string.Empty;
}