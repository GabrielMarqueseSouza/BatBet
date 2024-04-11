using System;

namespace Contracts
{
    public class BetDeleted
    {
        public int Id { get; set; }
        public DateTime DeletedAt { get; set; } = DateTime.UtcNow;
    }
}
