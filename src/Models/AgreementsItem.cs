using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class AgreementDetail : WingetEntity
{
    public AgreementDetail(string @namespace, string identifier) 
        : base(@namespace, nameof(AgreementDetail), identifier)
    {
    }
    
    public string AgreementLabel { get; init; } = "Terms of Transaction";

    public string AgreementUrl { get; init; } = string.Empty;
}