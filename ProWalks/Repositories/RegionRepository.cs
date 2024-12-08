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

        /// <summary>
        ///  This method useful for to create the region 4 lines 5 lines
        /// </summary>
        /// <param name="region"></param>
        /// <returns>region</returns>
        public async Task<Region> CreateRegion(Region region)
        {
            await _prowalksDbContext.Regions.AddAsync(region);
            _prowalksDbContext.SaveChanges();
            return region;
        }

        public async Task<Region> DeleteRegion(Region region)
        {
            _prowalksDbContext.Regions.Remove(region);
            _prowalksDbContext.SaveChanges();
            return region;
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

        public async Task<Region> UpdateRegion(Guid id, Region updateRegionDto)
        {
            await _prowalksDbContext.SaveChangesAsync();
            return updateRegionDto;
        }

        //public async Task<Region>

        // take the method what of importent notes 

        //1. input and return  


        //func delegate where select max min 

        // [1 , 2, 3, 4, 5 ,6 , 7 ] --> > [5,6,7]


    }
}
