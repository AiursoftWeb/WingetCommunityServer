using Newtonsoft.Json;

namespace Aiursoft.WingetCommunityServer.Models.ViewModels.Information;

public class PackageMetadataResponse : WingetEntity
{
    [JsonProperty(PropertyName = "Data")]
    public required PackageMetadataData Data { get; init; }
}