using System;

namespace Contracts
{
    public class BetPlaced
    {
        public string Id { get; set; }
        public string AvBetId { get; set; }
        public string Bettor { get; set; }
        public DateTime BetTime { get; set; }
        public double Amount { get; set; }
        public int BetStatus { get; set; }
    }
}
