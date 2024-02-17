using MongoDB.Entities;
using System;

namespace BetSearchService.Models
{
    public class Bets: Entity
    {
        public double Amount { get; set; }
        public Status Status { get; set; }
        public double PlatformFee { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }

        public string GameName { get; set; }
        public DateTime GameCreatedAt { get; set; }
        public bool GameIsActive { get; set; }

        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserCountry { get; set; }
        public double UserBalance { get; set; }
        public DateTime MemberSince { get; set; }
        public bool UserIsBlocked { get; set; }
        public string UserBlockReason { get; set; }
    }
}
