namespace WingetCommunityServer.Models;

public class Query
{
    /// <summary>
    /// 
    /// </summary>
    public string? KeyWord { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? MatchType { get; set; }
}

public class Inclusion
{
    /// <summary>
    /// 
    /// </summary>
    public string? PackageMatchField { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Query? RequestMatch { get; set; }
}

public class SearchAddressModel
{
    /// <summary>
    /// Query with keyword
    /// </summary>
    public Query? Query { get; set; }

    /// <summary>
    /// Inclusions
    /// </summary>
    public List<Inclusion> Inclusions { get; set; } = new List<Inclusion>();
}
