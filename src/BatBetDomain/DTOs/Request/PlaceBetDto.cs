using BatBetDomain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace BatBetDomain.DTOs.Request
{
    public class PlaceBetDto
    {
        [Required]
        public double Amount { get; set; }

        [Required]
        public string GameName { get; set; }
        public int GameId { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; } = DateTime.UtcNow.AddDays(60);
    }
}
