namespace WingetCommunityServer.Models;

public class Query
{
    /// <summary>
    /// Maybe 'vlc' or 'vscode'
    /// </summary>
    public string? KeyWord { get; set; }

    /// <summary>
    /// Maybe 'Substring' or 'Exact'
    /// </summary>
    public string? MatchType { get; set; }
}