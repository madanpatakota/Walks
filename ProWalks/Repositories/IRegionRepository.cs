﻿using ProWalks.DomainModels;

namespace ProWalks.Repositories
{
    public interface IRegionRepository
    {
       public Task<List<Region>> GetAllRegions();

        public Task<Region> GetAllRegionsByID(string code);

        public Task<Region> CreateRegion(Region region);

        public Task<Region> UpdateRegion(Guid id , Region region);

        public Task<Region> DeleteRegion(Region region);

    }
}
