using CurriculumChatAPI.Models;
using System.Text.Json;

namespace CurriculumChatAPI.Services
{
    /// <summary>
    /// Provides access to curriculum data loaded from a JSON configuration file.
    /// </summary>
    public class CurriculumProvider : ICurriculumProvider
    {
        /// <summary>
        /// Gets the curriculum data loaded from the configured JSON file.
        /// </summary>
        public Curriculum Curriculum { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurriculumProvider"/> class.
        /// Loads and deserializes the curriculum data from the specified JSON file path.
        /// </summary>
        /// <param name="config">The configuration object containing the curriculum file path.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="config"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the curriculum file path is not configured or is empty.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the curriculum file does not exist at the specified path.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the curriculum file cannot be deserialized into a <see cref="Curriculum"/> object.</exception>
        public CurriculumProvider(IConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            var filePath = config["Curriculum:FilePath"];
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Curriculum file path is not configured.", nameof(config));

            var absolutePath = Path.Combine(AppContext.BaseDirectory, filePath);
            if (!File.Exists(absolutePath))
                throw new FileNotFoundException($"Curriculum file not found: {absolutePath}");

            var json = File.ReadAllText(absolutePath);
            Curriculum = JsonSerializer.Deserialize<Curriculum>(json)
                         ?? throw new InvalidOperationException("Failed to deserialize curriculum.");
        }
    }
}