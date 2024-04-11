using System;
using System.Collections.Generic;

namespace BatBetDomain.Entities
{
    public class AvailableBet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LimitDate { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }
    }
}
