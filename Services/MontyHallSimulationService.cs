using MontyHallApi.Models;
using System;
using System.Collections.Generic;

namespace MontyHallApi.Services
{
    public class MontyHallSimulationService : IMontyHallSimulationService
    {
        public MontyHallResult Simulate(int initialSelection, bool switchDoor)
        {
            Random random = new Random();
            int prizeDoor = random.Next(0, 3);
            int[] doors = new int[3];
            doors[prizeDoor] = 2; // 2 represents the prize

            // Simulate the host revealing a door that is neither the prize door nor the initial selection
            int revealedDoor;
            do
            {
                revealedDoor = random.Next(0, 3);
            } while (revealedDoor == prizeDoor || revealedDoor == initialSelection);

            // If the user decides to switch, they can't switch to the revealed door
            int finalSelection = initialSelection;
            if (switchDoor)
            {
                // Switch to the remaining door that is not the initial selection or the revealed door
                finalSelection = 3 - initialSelection - revealedDoor;
            }

            bool win = (finalSelection == prizeDoor);

            return new MontyHallResult
            {
                Win = win,
                Doors = doors,
                SwitchDoor = switchDoor,
                InitialSelection = initialSelection,
                RevealedDoor = revealedDoor,
                FinalSelection = finalSelection,
                PrizeDoor = prizeDoor
            };
        }

        public IEnumerable<MontyHallResult> SimulateMultiple(int numberOfSimulations, int initialSelection, bool switchDoor)
        {

            List<MontyHallResult> results = new List<MontyHallResult>();

            for (int i = 0; i < numberOfSimulations; i++)
            {
                results.Add(Simulate(initialSelection, switchDoor));
            }

            return results;
        }
    }
}
