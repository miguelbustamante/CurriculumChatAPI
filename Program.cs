using System.Reflection;
using CurriculumChatAPI.ML;
using CurriculumChatAPI.Services;
using Microsoft.OpenApi.Models;

// Create the web application builder to configure services and the app pipeline.
var builder = WebApplication.CreateBuilder(args);

// Register CurriculumProvider as a singleton service to provide curriculum data across the application.
builder.Services.AddSingleton<ICurriculumProvider, CurriculumProvider>();

// Register ChatbotService as a singleton service to handle chat-related logic.
builder.Services.AddSingleton<IIntentPredictionService, IntentPredictionService>();
builder.Services.AddSingleton<ICurriculumResponder, CurriculumResponder>();


// Add support for MVC controllers to handle HTTP requests.
builder.Services.AddControllers();

// Configure CORS to allow cross-origin requests from any origin, with any headers and methods.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Enable API explorer for endpoint metadata, required for Swagger generation.
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger/OpenAPI documentation for the API.
builder.Services.AddSwaggerGen(c =>
{
    // Define the Swagger document with title and version.
    c.SwaggerDoc("v1",
    new OpenApiInfo
    {
        Title = "CurriculumChatAPI",
        Version = "v1",
        Description = "API for Curriculum Chatbot, providing chat interactions based on a curriculum.",
        Contact = new OpenApiContact
        {
            Name = "Curriculum Chatbot Team",
            Email = "miguel_bustamante_84@outlook.com",
            Url = new Uri("https://miguelbustamante.github.io/")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/license/mit/")
        }
    });

    // Include XML comments for enhanced Swagger documentation.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath); // Loads XML comments from the project’s generated XML file.
});

// Train the machine learning model using the specified data file and output model file.
ModelTrainer.Train("ML/intents.csv", "ML/IntentClassifier.zip");

// Build the web application from the configured builder.
var app = builder.Build();

// Apply middleware to the request pipeline.

// Enable CORS middleware to handle cross-origin requests as per the configured policy.
app.UseCors();

// Redirect HTTP requests to HTTPS for secure communication.
app.UseHttpsRedirection();

// Enable authorization middleware (placeholder, requires configuration if used).
app.UseAuthorization();

// Map controller routes to handle incoming HTTP requests.
app.MapControllers();

// Enable Swagger middleware to serve the OpenAPI JSON document.
app.UseSwagger();

// Enable Swagger UI middleware to provide an interactive API documentation interface.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CurriculumChatAPI v1");
    c.RoutePrefix = string.Empty; // Makes Swagger UI available at the app root "/"
});

// Start the application and listen for incoming requests.
app.Run();