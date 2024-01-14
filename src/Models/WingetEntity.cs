using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public abstract class WingetEntity
{
    [JsonProperty(PropertyName = "$type", Order = -999)]
    public string Type { get; private init; }

    protected WingetEntity(string @namespace, string type, string identifier)
    {
        Type = $"{@namespace}.{type}, {identifier}";
    }
}