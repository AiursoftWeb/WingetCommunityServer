using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class PackageMetadataResponse : WingetEntity
{
    [JsonProperty(PropertyName = "Data")]
    public required PackageMetadataData Data { get; init; }
}