using CurriculumChatAPI.Models;
using Microsoft.ML;

namespace CurriculumChatAPI.Services;
public class IntentPredictionService : IIntentPredictionService
    {
        private readonly PredictionEngine<ModelInput, ModelOutput> _predictionEngine;

        public IntentPredictionService(IWebHostEnvironment env)
        {
            var mlContext = new MLContext();
            var modelPath = Path.Combine(env.ContentRootPath, "ML", "IntentClassifier.zip");

            if (!File.Exists(modelPath))
                throw new FileNotFoundException("Trained ML model not found.", modelPath);

            ITransformer mlModel = mlContext.Model.Load(modelPath, out _);
            _predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        public string PredictIntent(string input)
        {
            var prediction = _predictionEngine.Predict(new ModelInput { Text = input });
            return prediction.PredictedLabel ?? "Unknown";
        }
    }