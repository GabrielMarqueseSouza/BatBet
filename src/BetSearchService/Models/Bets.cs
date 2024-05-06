using MongoDB.Entities;
using System;

namespace BetSearchServiceAPI.Models
{
    public class Bets : Entity
    {
        public double Amount { get; set; }
        public Status Status { get; set; }
        public double PlatformFee { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string GameName { get; set; }
        public string UserId { get; set; }
        public int AvailableBetId { get; set; }
    }
}
