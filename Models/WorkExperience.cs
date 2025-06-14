using System.Text.Json.Serialization;

namespace CurriculumChatAPI.Models;
/// <summary>
/// Represents a work experience entry in a curriculum vitae.
/// This class contains properties for the job title, company, duration, and a description of the work experience.
/// </summary>
public class WorkExperience
{
  /// <summary>
  /// Gets or sets the job title held during the work experience.
  /// </summary>
  /// <value>
  /// A string representing the job title, such as "Software Engineer" or "Project Manager".
  /// </value>
  [JsonPropertyName("title")]
  public string Title { get; set; } = null!;
  /// <summary>
  /// Gets or sets the name of the company where the work experience was gained.
  /// </summary>
  /// <value>
  /// A string representing the company name, such as "Tech Solutions Inc." or "Global Enterprises".
  /// </value>
  [JsonPropertyName("company")]
  public string Company { get; set; } = string.Empty;
  /// <summary>
  /// Gets or sets the duration of the work experience.
  /// </summary>
  /// <value>
  /// A string representing the duration of the work experience, such as "2 years" or "6 months".
  /// </value>
  [JsonPropertyName("duration")]
  public string Duration { get; set; } = string.Empty;
  /// <summary>
  /// Gets or sets the description of the work experience.
  /// </summary>
  /// <value>
  /// A string providing a detailed description of the work experience, including responsibilities, achievements, and skills utilized.
  /// </value>
  [JsonPropertyName("description")]
  public string? Description { get; set; }
}