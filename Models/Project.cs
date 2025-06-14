using System.Text.Json.Serialization;

namespace CurriculumChatAPI.Models;
/// <summary>
/// Represents a project in a curriculum vitae.
/// This class contains properties for the project's name, description, and technologies used.
/// </summary>
public class Project
{
  /// <summary>
  /// Gets or sets the name of the project.
  /// </summary>
  /// <value>
  /// A string representing the name of the project, such as "Web Application Development" or "Machine Learning Model".
  /// </value>
  [JsonPropertyName("name")]
  public string Name { get; set; } = null!;
  /// <summary>
  /// Gets or sets the description of the project.
  /// </summary>
  /// <value>
  /// A string providing a detailed description of the project, including its objectives, outcomes, and any notable achievements.
  /// </value>
  [JsonPropertyName("description")]
  public string Description { get; set; } = null!;
  /// <summary>
  /// Gets or sets the technologies used in the project.
  /// </summary>
  /// <value>
  /// A list of strings representing the technologies employed in the project, such as "C#", "JavaScript", or "Python".
  /// Defaults to an empty list if no technologies are specified.
  /// </value>
  [JsonPropertyName("technologies")]
  public List<string> Technologies { get; set; } = new List<string>();
}