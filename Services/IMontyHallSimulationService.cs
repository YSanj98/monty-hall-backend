using MontyHallApi.Models;

namespace MontyHallApi.Services
{
    public interface IMontyHallSimulationService
    {
        MontyHallResult Simulate(int initialSelection, bool switchDoor);
    }
}
