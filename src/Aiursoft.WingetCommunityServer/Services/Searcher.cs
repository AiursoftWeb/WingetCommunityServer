using Aiursoft.WingetCommunityServer.Database;
using Aiursoft.WingetCommunityServer.Models.AddressModels;
using Aiursoft.WingetCommunityServer.Models.ViewModels.Search;

namespace Aiursoft.WingetCommunityServer.Services;

public class Searcher
{
    // ReSharper disable once NotAccessedField.Local
    private readonly WingetServerDbContext _dbContext;

    public Searcher(WingetServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<ManifestSearchResponse> Search(SearchAddressModel model)
    {
        throw new NotImplementedException();
        
        // var searchWord = model.Query?.KeyWord?.ToLower() ?? string.Empty;
        // var query = _dbContext.Packages.AsQueryable();
        // switch (model.Query?.MatchType)
        // {
        //     case "Substring":
        //         query = query.Where(package => 
        //             package.Name.ToLower().Contains(searchWord) ||
        //             package.Id.ToLower().Contains(searchWord));
        //         break;
        //     case "Exact":
        //         query = query.Where(package => 
        //             package.Name.ToLower() == searchWord ||
        //             package.Id.ToLower() == searchWord);
        //         break;
        //     case "StartsWith":
        //         query = query.Where(package => 
        //             package.Name.ToLower().StartsWith(searchWord) ||
        //             package.Id.ToLower().StartsWith(searchWord));
        //         break;
        //     default:
        //         throw new ArgumentOutOfRangeException();
        // }
        // var result = await query.ToListAsync();
        //
        // return new ManifestSearchResponse
        // {
        //     Data = result.Select(package => new ManifestSearchData
        //     {
        //         PackageIdentifier = package.Id,
        //         PackageName = package.Name,
        //         Publisher = package.Publisher,
        //         Versions = new List<ManifestSearchVersion>
        //         {
        //             new()
        //             {
        //                 PackageVersion = package.Version,
        //                 PackageFamilyNames = new List<string>
        //                 {
        //                     package.PackageFamilyName
        //                 }
        //             }
        //         }
        //     }).ToList()
        // };
    }
}
