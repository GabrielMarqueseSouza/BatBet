using System;

namespace Contracts;

public class BetCreated
{
    public double Amount { get; set; }
    public Status Status { get; set; }
    public double PlatformFee { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DueDate { get; set; }

    public string GameName { get; set; }

    public string UserName { get; set; }
    public string UserLastName { get; set; }
    public string UserCountry { get; set; }
    public double UserBalance { get; set; }
    public DateTime MemberSince { get; set; }
    public bool UserIsBlocked { get; set; }
    public string UserBlockReason { get; set; }
}
