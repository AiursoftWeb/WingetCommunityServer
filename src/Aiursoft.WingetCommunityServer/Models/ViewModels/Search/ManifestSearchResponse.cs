namespace Aiursoft.WingetCommunityServer.Models.ViewModels.Search;

public class ManifestSearchResponse : WingetEntity
{
    public required List<ManifestSearchData> Data { get; init; } = new();
}