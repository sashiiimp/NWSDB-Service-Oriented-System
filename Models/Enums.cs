namespace NWSDB.Server.Models;

public enum ConnectionStatus
{
    Active,
    Inactive,
    Suspended
}

public enum BillStatus
{
    Unpaid,
    PartiallyPaid,
    Paid,
    Overdue
}

public enum PaymentMethod
{
    Cash,
    Card,
    BankTransfer,
    OnlineBanking,
    Cheque
}

public enum PaymentSource
{
    CustomerPortal,
    AdminOffice,
    ThirdPartyPartner
}

public enum PartnerStatus
{
    Active,
    Suspended
}
