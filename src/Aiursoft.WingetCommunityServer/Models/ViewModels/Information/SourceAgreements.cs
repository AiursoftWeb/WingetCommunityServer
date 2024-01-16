namespace Aiursoft.WingetCommunityServer.Models.ViewModels.Information;

public class SourceAgreements : WingetEntity
{
    public SourceAgreements(string agreementUrl)
    {
        if (!string.IsNullOrWhiteSpace(agreementUrl))
        {
            Agreements.Add(new AgreementDetail
            {
                AgreementUrl = agreementUrl
            });
        }
    }

    // ReSharper disable once UnusedMember.Global
    public string AgreementsIdentifier => Consts.ServerId;

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once CollectionNeverQueried.Global
    public List<AgreementDetail> Agreements { get; } = new();
}