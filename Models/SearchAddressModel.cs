namespace WingetCacheServer.Models;

public class Query
{
    /// <summary>
    /// 
    /// </summary>
    public string KeyWord { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string MatchType { get; set; }
}

public class SearchAddressModel
{
    /// <summary>
    /// 
    /// </summary>
    public Query Query { get; set; }
}
