using BatBetDomain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace BatBetDomain.DTOs.Request
{
    public class PlaceBetDto
    {
        [Required]
        public double Amount { get; set; }
        public string GameName { get; set; }
        public int AvailableBetId { get; set; }

        [Required]
        public int GameId { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
    }
}
