namespace MontyHallApi.Models
{
    public class MontyHallRequest
    {
        public int NumberOfSimulations { get; set; }
        public int InitialSelection { get; set; }
        public bool SwitchDoor { get; set; }
    }
}
