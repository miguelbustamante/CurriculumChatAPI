using CurriculumChatAPI.Models;
using CurriculumChatAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CurriculumChatAPI.Controllers
{
    /// <summary>
    /// Controller responsible for handling chat-related API requests.
    /// Provides endpoints to process user messages and return chatbot responses.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Handles interactions with the chatbot, allowing users to send messages and receive responses.")]
    public class ChatController : ControllerBase
    {
        private readonly IIntentPredictionService _intentPredictionService;
        private readonly ICurriculumResponder _curriculumResponder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatController"/> class.
        /// </summary>
        /// <param name="intentPredictionService">The service used for predicting user intents based on their messages.</param>
        /// <param name="curriculumResponder">The service used to provide responses based on the curriculum.</param>
        public ChatController(
                              IIntentPredictionService intentPredictionService,
                              ICurriculumResponder curriculumResponder)
        {
            _intentPredictionService = intentPredictionService ?? throw new ArgumentNullException(nameof(intentPredictionService));
            _curriculumResponder = curriculumResponder ?? throw new ArgumentNullException(nameof(curriculumResponder));
        }

        /// <summary>
        /// Processes a user's chat message and returns a chatbot response.
        /// </summary>
        /// <param name="request">The chat request containing the user's message.</param>
        /// <returns>
        /// A <see cref="ChatResponse"/> containing the chatbot's response.
        /// Returns a 400 Bad Request if the message is empty or whitespace.
        /// </returns>
        /// <response code="200">Returns the chatbot's response to the user's message.</response>
        /// <response code="400">Returned when the input message is null, empty, or whitespace.</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Processes a user message and returns a chatbot response", 
                         Description = "Receives a chat message from the user and returns the chatbot's response.")]
        [SwaggerResponse(200, "Chat response generated successfully.", typeof(ChatResponse))]
        [SwaggerResponse(400, "Invalid input: message is required and cannot be empty or whitespace.")]
        public IActionResult Post([FromBody] ChatRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
                return BadRequest("Message is required.");

            var intent = _intentPredictionService.PredictIntent(request.Message);
            var response = _curriculumResponder.GetResponseForIntent(intent);
            return Ok(new ChatResponse { Response = response });
        }
    }
}