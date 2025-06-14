using Microsoft.ML.Data;

namespace CurriculumChatAPI.Models;
public class ModelInput
{
  /// <summary>
  /// Gets or sets the text input for intent prediction.
  /// </summary>
  /// <remarks>
  /// This property is used as the input feature for the ML model.
  /// </remarks>
  [LoadColumn(0)]
  public string Text { get; set; } = null!;
  /// <summary>
  /// Gets or sets the intent label for the text input.
  /// </summary>
  /// <remarks>
  /// This property is used as the label for training the ML model.
  /// </remarks>
  [LoadColumn(1)]
  public string Intent { get; set; } = null!;
}