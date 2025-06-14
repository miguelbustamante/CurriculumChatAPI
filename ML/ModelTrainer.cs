using CurriculumChatAPI.Models;
using Microsoft.ML;

namespace CurriculumChatAPI.ML;

/// <summary>
/// Provides functionality to train a machine learning model for intent classification using ML.NET.
/// </summary>
public static class ModelTrainer
{
    /// <summary>
    /// Trains a multiclass classification model based on the provided training data and saves it to the specified path.
    /// </summary>
    /// <param name="dataPath">The path to the CSV file containing the training data.</param>
    /// <param name="modelPath">The file path where the trained model will be saved.</param>
    /// <remarks>
    /// This method:
    /// <list type="bullet">
    /// <item>Loads the training data from a CSV file.</item>
    /// <item>Featurizes the text input.</item>
    /// <item>Maps the intent labels to keys for classification.</item>
    /// <item>Trains the model using SDCA Maximum Entropy algorithm.</item>
    /// <item>Maps the predicted keys back to original labels.</item>
    /// <item>Saves the trained model to disk.</item>
    /// </list>
    /// </remarks>
    public static void Train(string dataPath, string modelPath)
    {
        var mlContext = new MLContext();

        // Load training data from CSV
        var data = mlContext.Data.LoadFromTextFile<ModelInput>(
            path: dataPath,
            hasHeader: true,
            separatorChar: ',');

        // Define the data processing and training pipeline
        var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(ModelInput.Text))
            .Append(mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(ModelInput.Intent)))
            .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
            .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

        // Train the model
        var model = pipeline.Fit(data);

        // Save the trained model to disk
        mlContext.Model.Save(model, data.Schema, modelPath);
    }
}
