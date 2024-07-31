namespace MontyHallApi.Models
{
    public class MontyHallResult
    {
        public bool Win { get; set; }
        public int[] Doors { get; set; }
        public bool SwitchDoor { get; set; }
        public int InitialSelection { get; set; }
        public int RevealedDoor { get; set; }
        public int FinalSelection { get; set; }
        public int PrizeDoor { get; set; }
    }
}
