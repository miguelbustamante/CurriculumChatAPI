using System.Text.Json.Serialization;

namespace CurriculumChatAPI.Models;
/// <summary>
/// Represents a contact information model. 
/// </summary>
public class Contact
{
  /// <summary>
  /// Gets or sets the emauil address of the individual.
  /// </summary>
  [JsonPropertyName("email")]
  public string Email { get; set; } = string.Empty;
  /// <summary>
  /// Gets or sets the phone number of the individual.
  /// </summary>
  [JsonPropertyName("phone")]
  public string? Phone { get; set; }

  /// <summary>
  /// Gets or sets the LinkedIn profile URL of the individual.
  /// </summary>
  [JsonPropertyName("linkedIn")]
  public string? LinkedIn { get; set; }
}