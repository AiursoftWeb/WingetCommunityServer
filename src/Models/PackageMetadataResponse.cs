using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class PackageMetadataResponse<T> : WingetEntity
{
    [JsonProperty(PropertyName = "Data")]
    public required T Data { get; set; }

    public PackageMetadataResponse(string @namespace, string identifier) 
        : base(@namespace, nameof(PackageMetadataResponse<object>), identifier)
    {
    }
}