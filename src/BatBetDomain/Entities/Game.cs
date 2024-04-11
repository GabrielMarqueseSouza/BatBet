using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatBetDomain.Entities
{
    [Table("Games")]
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }
        public virtual ICollection<AvailableBet> AvailableBets { get; set; }
    }
}
