using CurriculumChatAPI.Models;
using System.Text.Json;

namespace CurriculumChatAPI.Services
{
  /// <summary>
  /// Service for handling chatbot interactions related to a curriculum vitae.
  /// This service processes user messages and provides responses based on the curriculum data.
  /// </summary>

  public class ChatbotService
  {
    private readonly Curriculum _curriculum;
    /// <summary>
    /// Initializes a new instance of the <see cref="ChatbotService"/> class.
    /// Loads the curriculum data from a JSON file located in the application's content root path.
    /// </summary>
    /// <param name="curriculumProvider">The provider that supplies the curriculum data.</param>
    /// <exception cref="ArgumentNullException">Thrown when the curriculum provider is null.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the curriculum JSON file is not found.</exception>
    public ChatbotService(CurriculumProvider curriculumProvider)
    {
      _curriculum = curriculumProvider.Curriculum ?? throw new ArgumentNullException(nameof(curriculumProvider));
      if (_curriculum == null)
        throw new FileNotFoundException("Curriculum data not found.");
    }
    /// <summary>
    /// Processes a user message and returns an appropriate response based on the curriculum data.
    /// The method checks the content of the message for keywords related to education, work experience, skills, or projects,
    /// and constructs a response accordingly. If no relevant keywords are found, it prompts the user to ask about specific topics.
    /// </summary>
    /// <param name="message">The user message to process.</param>

    public string GetResponse(string message)
    {
      var msg = message.ToLowerInvariant();
      Console.WriteLine($"Received message: {msg}");
      if (msg.Contains("experience") || msg.Contains("work"))
      {
        return string.Join("\n", _curriculum.WorkExperience.Select(w =>
            $"{w.Title} at {w.Company} ({w.Duration}) - {w.Description}"));
      }
      else if (msg.Contains("education") || msg.Contains("degree"))
      {
        return string.Join("\n", _curriculum.Education.Select(e =>
            $"{e.Degree} from {e.University} ({e.Year})"));
      }
      else if (msg.Contains("skills") || msg.Contains("technologies"))
      {
        return "Skills: " + string.Join(", ", _curriculum.Skills);
      }
      else if (msg.Contains("project"))
      {
        return string.Join("\n", _curriculum.Projects.Select(p =>
            $"{p.Name}: {p.Description} (Tech: {string.Join(", ", p.Technologies)})"));
      }
      else
      {
        return "I'm not sure about that. You can ask about my education, work experience, skills, or projects!";
      }
    }
  }
}
