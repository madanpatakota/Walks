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

        public async Task<Region> GetAllRegionsByID(string code)
        {
            return await this._prowalksDbContext.Regions.Where(x => x.Code == code).SingleOrDefaultAsync();
        }


        //func delegate where select max min 

        // [1 , 2, 3, 4, 5 ,6 , 7 ] --> > [5,6,7]
        

    }
}
