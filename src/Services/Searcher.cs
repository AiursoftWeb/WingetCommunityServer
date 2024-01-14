using Aiursoft.WingetCommunityServer.Data;
using Microsoft.EntityFrameworkCore;
using WingetCommunityServer.Models;
using WingetCommunityServer.Models.Database;

namespace WingetCommunityServer.Services;

public class Searcher
{
    private readonly WingetServerDbContext _dbContext;

    public Searcher(WingetServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ManifestSearchResponse> Search(SearchAddressModel model)
    {
        var searchWord = model.Query?.KeyWord ?? string.Empty;
        var query = _dbContext.Packages.AsQueryable();
        switch (model.Query?.MatchType)
        {
            case "Substring":
                query = query.Where(package => package.Name.Contains(searchWord));
                break;
            case "Exact":
                query = query.Where(package => package.Name == searchWord);
                break;
            case "StartsWith":
                query = query.Where(package => package.Name.StartsWith(searchWord));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        var result = await query.ToListAsync();
        return new ManifestSearchResponse
        {
            Data = result.Select(package => new ManifestSearchData
            {
                PackageIdentifier = package.Id,
                PackageName = package.Name,
                Publisher = package.Publisher,
                Versions = new List<ManifestSearchVersion>
                {
                    new()
                    {
                        PackageVersion = package.Version,
                        PackageFamilyNames = new List<string>
                        {
                            package.PackageFamilyName
                        }
                    }
                }
            }).ToList()
        };
    }
}
