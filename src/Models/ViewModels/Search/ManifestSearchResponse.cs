namespace WingetCommunityServer.Models;

public class ManifestSearchResponse : WingetEntity
{
    public required List<ManifestSearchData> Data { get; init; } = new();
}