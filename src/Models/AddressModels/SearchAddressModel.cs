namespace WingetCommunityServer.Models;

public class SearchAddressModel
{
    public List<Filter>? Filters { get; set; }
    
    public Query? Query { get; set; }
}