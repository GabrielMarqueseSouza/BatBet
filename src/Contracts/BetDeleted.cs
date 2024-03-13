using BatBetDomain.Entities;

namespace Contracts
{
    public class BetDeleted
    {
        public int BetId { get; set; }
        public double Amount { get; set; }
        public Status Status { get; set; }
        public double PlatformFee { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public string GameName { get; set; }

        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public double UserBalance { get; set; }
    }
}
