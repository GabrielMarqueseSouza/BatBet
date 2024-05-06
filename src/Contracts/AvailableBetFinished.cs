namespace Contracts
{
    public class AvailableBetFinished
    {
        public bool AvBetDueDateReached { get; set; }
        public int AvBetId { get; set; }
        public string WinnerId { get; set; }
        public double Amount { get; set; }
    }
}