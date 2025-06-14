namespace CurriculumChatAPI.Models;
/// <summary>
/// Represents the output of a model prediction.
/// </summary>
public class ModelOutput
{
  /// <summary>
  /// Gets or sets the predicted label for the input text.
  /// </summary>
  /// <remarks>
  /// This property contains the label predicted by the ML model based on the input text.
  /// </remarks>
  public string PredictedLabel { get; set; } = null!;
}