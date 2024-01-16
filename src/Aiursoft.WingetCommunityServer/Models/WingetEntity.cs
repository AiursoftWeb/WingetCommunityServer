using Newtonsoft.Json;

namespace Aiursoft.WingetCommunityServer.Models;

public abstract class WingetEntity
{
    [JsonProperty(PropertyName = "$type", Order = -999)]
    public string Type => 
        $"{GetType().Namespace}.{GetType().Name}, {Consts.ServerId}".Replace("`1", string.Empty); 
}