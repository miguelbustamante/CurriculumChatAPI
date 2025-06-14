namespace CurriculumChatAPI.Models;
/// <summary>
/// Represents a request to a chat service.
/// This class contains a single property, Message, which holds the text of the chat request.
/// </summary>
public class ChatRequest
{
    /// <summary>
    /// Gets or sets the message text for the chat request.
    /// </summary>
    /// <value>
    /// A string containing the message text. Defaults to an empty string.
    /// </value>
  public string Message { get; set; } = string.Empty;
}