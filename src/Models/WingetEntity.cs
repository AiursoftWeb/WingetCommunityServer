using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public abstract class WingetEntity
{
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; init; }

    protected WingetEntity(string @namespace, string type, string identifier)
    {
        Type = $"{@namespace}.{type}, {identifier}";
    }
}