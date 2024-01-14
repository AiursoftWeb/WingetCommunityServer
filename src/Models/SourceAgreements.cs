namespace WingetCommunityServer.Models;

public class SourceAgreements : WingetEntity
{
    public SourceAgreements(string @namespace, string identifier, string agreementUrl)
        : base(@namespace, nameof(SourceAgreements), identifier)
    {
        AgreementsIdentifier = identifier;
        if (!string.IsNullOrWhiteSpace(agreementUrl))
        {
            Agreements.Add(new AgreementDetail(@namespace, identifier)
            {
                AgreementUrl = agreementUrl
            });
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string AgreementsIdentifier { get; init; }

    /// <summary>
    /// 
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once CollectionNeverQueried.Global
    public List<AgreementDetail> Agreements { get; } = new();
}