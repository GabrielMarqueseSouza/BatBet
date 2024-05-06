using System;
using System.ComponentModel.DataAnnotations;

namespace BatBetDomain.DTOs.Request
{
    public class PlaceBetDto
    {
        [Required]
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }

        [Required]
        public int GameId { get; set; }
        public int AvailableBetId { get; set; }
    }
}
