using WingetCommunityServer.Models;
using WingetCommunityServer.Models.Database;

namespace WingetCommunityServer.Services;

public class Searcher
{
    public ManifestSearchResponse Search(SearchAddressModel model)
    {
        var mockData = new List<Package>
        {
            new()
            {
                Id = "Python.Python.3.11",
                Name = "Python 3.11",
                Version = "3.11.7",
                Publisher = "Python Software Foundation"
            },
            new()
            {
                Id = "Python.Python.3.10",
                Name = "Python 3.10",
                Version = "3.10.11",
                Publisher = "Python Software Foundation"
            }
        };
        
        return new ManifestSearchResponse
        {
            Data = mockData.Select(package => new ManifestSearchData
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
