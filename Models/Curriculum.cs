using System.Text.Json.Serialization;
using CurriculumChatAPI.Services;

namespace CurriculumChatAPI.Models;
/// <summary>
/// Represents a curriculum containing personal information, education, work experience, skills, and projects.
/// This class serves as a comprehensive model for a curriculum vitae (CV) or resume.
/// </summary>
public class Curriculum
{
  /// <summary>
  /// Gets or sets the name of the individual.
  /// </summary>
  /// <value>
  /// A string representing the name of the individual. Defaults to an empty string.
  /// </value>
  [JsonPropertyName("name")]
  public string Name { get; set; } = null!;
  /// <summary>
  /// Gets or sets the summary of the individual's professional profile.
  /// </summary>
  /// <value>
  /// A string providing a brief overview of the individual's professional background and expertise.
  /// Defaults to an empty string.  
  /// </value>
  [JsonPropertyName("summary")]
  public string Summary { get; set; } = null!;
  /// <summary>
  /// Gets or sets contact information for the individual.
  /// </summary>
  /// <value>
  /// A <see cref="Contact"/> object containing the individual's contact details such as email, phone, and LinkedIn profile.
  /// Defaults to a new instance of <see cref="Contact"/> with default values.
  /// </value>
[JsonPropertyName("contact")]
  public Contact Contact { get; set; } = new Contact();
  /// <summary>
  /// Gets or sets the languages spoken by the individual.
  /// </summary>
  /// <value>
  /// A list of <see cref="Language"/> objects representing the languages spoken and their proficiency levels.
  /// Defaults to an empty list.
  /// </value>
  [JsonPropertyName("languages")]
  public List<Language> Languages { get; set; } = new List<Language>();
  /// <summary>
  /// Gets or sets the education details of the individual.
  /// </summary>
  /// <value>
  /// A list of <see cref="Education"/> objects representing the individual's educational background.
  /// Defaults to an empty list.
  /// </value>
  [JsonPropertyName("education")]
  public List<Education> Education { get; set; } = new List<Education>();
  /// <summary>
  /// Gets or sets the work experience of the individual.
  /// </summary>
  /// <value>
  /// A list of <see cref="WorkExperience"/> objects representing the individual's work history.
  /// Defaults to an empty list.
  /// </value>
  [JsonPropertyName("workExperience")]
  public List<WorkExperience> WorkExperience { get; set; } = new List<WorkExperience>();
  /// <summary>
  /// Gets or sets the skills of the individual.
  /// </summary>
  /// <value>
  /// A list of strings representing the skills of the individual.
  /// Defaults to an empty list.
  /// </value>
  [JsonPropertyName("skills")]
  public List<string> Skills { get; set; } = new List<string>();
  /// <summary>
  /// Gets or sets the projects undertaken by the individual.
  /// </summary>
  /// <value>
  /// A list of <see cref="Project"/> objects representing the individual's projects.
  /// Defaults to an empty list.
  /// </value>
  [JsonPropertyName("projects")]
  public List<Project> Projects { get; set; } = new List<Project>();
}
