using ProWalks.DomainModels;

namespace ProWalks.Repositories
{
    public interface IRegionRepository
    {
       public Task<List<Region>> GetAllRegions();

        public Task<Region> GetAllRegionsByID(string code);

    }
}
