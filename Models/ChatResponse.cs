namespace CurriculumChatAPI.Models;
/// <summary>
/// Represents a response from a chat service.
/// This class contains a single property, Response, which holds the text of the chat response.
/// </summary>
public class ChatResponse
{
    /// <summary>
    /// Gets or sets the response text from the chat service.
    /// </summary>
    /// <value>
    /// A string containing the response text. Defaults to an empty string.
    /// </value>
  public string Response { get; set; } = string.Empty;
}