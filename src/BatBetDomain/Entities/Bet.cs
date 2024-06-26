﻿using System;

namespace BatBetDomain.Entities
{
    public class Bet
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int Status { get; set; }
        public double PlatformFee { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DueDate { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
        public string UserId { get; set; }
        public int AvailableBetId { get; set; }
        public AvailableBet AvailableBet { get; set; }
    }
}
