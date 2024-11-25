using Microsoft.EntityFrameworkCore;
using ProWalks.Data;
using ProWalks.DomainModels;

namespace ProWalks.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        ProWalksDbContext _prowalksDbContext;
        public RegionRepository(ProWalksDbContext dbContext) { 
            this._prowalksDbContext = dbContext;
        }
        //Weshould not implement methods without interface.
        public async Task<List<Region>> GetAllRegions()
        {
           return  await this._prowalksDbContext.Regions.ToListAsync();
        }




        //public List<Region> GetAllRegions1()
        //{
        //    return  this._prowalksDbContext.Regions.ToList();
        //}

    }
}
