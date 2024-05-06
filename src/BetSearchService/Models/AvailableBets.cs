using System;
using MongoDB.Entities;

namespace BetSearchServiceAPI.Models
{
    public class AvailableBets : Entity
    {
        public string Name { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double HighestBet { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastBetPlaced { get; set; }
        public string LastBetPlacedUserId { get; set; }
        public DateTime LimitDate { get; set; }
        public bool IsFinished { get; set; }
        public bool Canceled { get; set; }
        public string WinnerId { get; set; }
        public int GameId { get; set; }
    }
}