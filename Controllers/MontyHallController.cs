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

        [HttpPost("game")]
        public IActionResult Simulate([FromBody] MontyHallRequest request)
        {
            var result = _simulationService.Simulate(request.InitialSelection, request.SwitchDoor);
            return Ok(result);
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("If you can see this message, Backend is running...!");
        }
    }

}
