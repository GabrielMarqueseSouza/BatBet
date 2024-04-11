using System;

namespace Contracts
{
    public class BetUpdated
    {
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Status Status { get; set; } = Status.Finished;
    }
}
