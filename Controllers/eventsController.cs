using Microsoft.AspNetCore.Mvc;

namespace EventProcessorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class eventsController : ControllerBase
    {
        private readonly ILogger<eventsController> _logger;
        public eventsController(ILogger<eventsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("process")]
        public IActionResult ProcessEvent([FromBody] EventMessage eventMessage)
        {
            if (eventMessage == null)
            {
                _logger.LogError("Received null event message.");
                return BadRequest("Event message cannot be null.");
            }

            _logger.LogInformation($"Processing event with EventId: {eventMessage.EventId}");
            _logger.LogInformation($"EventData: {eventMessage.EventData}");

            return Ok(new { Message = $"Event with EventId: {eventMessage.EventId} processed successfully." });
        }
    }
}
