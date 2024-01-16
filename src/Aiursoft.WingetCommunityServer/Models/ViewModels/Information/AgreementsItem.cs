namespace Aiursoft.WingetCommunityServer.Models.ViewModels.Information;

public class AgreementDetail : WingetEntity
{
    // ReSharper disable once UnusedMember.Global
    public string AgreementLabel { get; init; } = "Terms of Transaction";

    public string AgreementUrl { get; init; } = string.Empty;
}