namespace WingetCommunityServer.Models;

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
