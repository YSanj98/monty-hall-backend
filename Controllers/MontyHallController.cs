using Microsoft.AspNetCore.Mvc;
using MontyHallApi.Models;
using MontyHallApi.Services;

namespace MontyHallApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MontyHallController : ControllerBase
    {
        private readonly IMontyHallSimulationService _simulationService;

        public MontyHallController(IMontyHallSimulationService simulationService)
        {
            _simulationService = simulationService;
        }

        // endpoint for the game 
        [HttpPost("game")]
        public IActionResult Game([FromBody] MontyHallRequest request)
        {
            // Log request for debugging
            Console.WriteLine($"Game Request - InitialSelection: {request.InitialSelection}, SwitchDoor: {request.SwitchDoor}");

            var result = _simulationService.Simulate(request.InitialSelection, request.SwitchDoor);
            return Ok(result);
        }

        // endpoint for multiple simulations
        [HttpPost("simulate")]
        public IActionResult Simulate([FromBody] MontyHallRequest request)
        {

            var results = _simulationService.SimulateMultiple(request.NumberOfSimulations, request.InitialSelection, request.SwitchDoor);
            return Ok(results);
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("If you can see this message, Backend is running...!");
        }
    }
}
