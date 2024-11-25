using Microsoft.AspNetCore.Mvc;
using ProWalks.DomainModels;
using ProWalks.DTOs;
using ProWalks.Repositories;

namespace ProWalks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : ControllerBase
    {
        IRegionRepository _regionRepository;


        //Deep logic  (instance of the Regionreposioty)
        public RegionsController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }


        //Get the Result data from the Async call.
        //https://localhost:7148/Regions/GetAllRegions
        [HttpGet]
        [Route("GetAllRegions")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllRegions(); // 2 records
            var regionDTOs = new List<RegionDTO>();
            foreach (var region in regions)
            {
                regionDTOs.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    Lat = region.Lat,
                    Long = region.Long,
                    Area = region.Area,
                    population = region.population
                });
            }
            return Ok(regionDTOs);
        }



        //CreateRegion




    }
}
