using ProWalks.DomainModels;

namespace ProWalks.Repositories
{
    public interface IRegionRepository
    {
       public Task<List<Region>> GetAllRegions();

    }
}
