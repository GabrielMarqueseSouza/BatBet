using System;

namespace BatBetService.Entities
{
    public class Bet
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public Status Status { get; set; }
        public double PlatformFee { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DueDate { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
