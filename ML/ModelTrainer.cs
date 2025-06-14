using CurriculumChatAPI.Models;
using Microsoft.ML;

namespace CurriculumChatAPI.ML;
public static class ModelTrainer
    {
        public static void Train(string dataPath, string modelPath)
        {
            var mlContext = new MLContext();

            var data = mlContext.Data.LoadFromTextFile<ModelInput>(
                path: dataPath,
                hasHeader: true,
                separatorChar: ',');

            var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(ModelInput.Text))
                .Append(mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(ModelInput.Intent)))
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            var model = pipeline.Fit(data);
            mlContext.Model.Save(model, data.Schema, modelPath);
        }
    }