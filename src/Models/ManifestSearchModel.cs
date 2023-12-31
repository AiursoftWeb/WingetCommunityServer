﻿using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class SearchVersionsItem
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string PackageVersion { get; set; } = Consts.FakePackageVersion;
}
 
public class DataItem
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string PackageIdentifier { get; set; } = Consts.FakePackageIdentifier;

    /// <summary>
    /// 
    /// </summary>
    public string PackageName { get; set; } = Consts.FakePackageName;

    /// <summary>
    /// 
    /// </summary>
    public string Publisher { get; set; } = Consts.FakePackagePublisher;

    /// <summary>
    /// 
    /// </summary>
    public List<SearchVersionsItem> Versions { get; set; } = new List<SearchVersionsItem> { new SearchVersionsItem() };
}
 
public class ManifestSearchModel
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public List<DataItem> Data { get; set; } = new List<DataItem>();
}

