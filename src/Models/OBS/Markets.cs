﻿using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class Markets
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = ObsoleteConsts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public List<string> AllowedMarkets { get; set; } = new List<string>();
}