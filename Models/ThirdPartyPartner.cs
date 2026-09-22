namespace NWSDB.Server.Models;

// Prototype-only API key storage (plain column). A production system should
// store a hash of the key (and rotate/expire it) rather than the raw value -
// this is called out here deliberately for the assignment report.
public class ThirdPartyPartner
{
    public int PartnerId { get; set; }

    public string PartnerName { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;

    public PartnerStatus Status { get; set; } = PartnerStatus.Active;
}
