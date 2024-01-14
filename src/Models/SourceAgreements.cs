namespace WingetCommunityServer.Models;

public class SourceAgreements : WingetEntity
{
    public SourceAgreements(string @namespace, string identifier)
        : base(@namespace, nameof(SourceAgreements), identifier)
    {
        AgreementsIdentifier = identifier;
    }

    /// <summary>
    /// 
    /// </summary>
    public string AgreementsIdentifier { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public List<AgreementsItem> Agreements { get; set; } = new();
}