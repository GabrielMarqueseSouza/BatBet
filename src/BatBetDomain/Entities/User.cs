using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatBetDomain.Entities
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string StateAcronym { get; set; }
        public string Complement { get; set; }
        public int Age { get; set; }
        public string DocumentNumber { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsBlocked { get; set; }
        public string BlockReason { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}