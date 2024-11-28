using Microsoft.AspNetCore.Mvc;
using ProWalks.DomainModels;
using ProWalks.DTOs;
using ProWalks.Repositories;
using System.Reflection.Metadata.Ecma335;

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

        //GetRegionID (regionCode){
        // return the that particular record which should match to the the regioncode.
        //}


        //https://localhost:7148/Regions/GetAllRegionsID/KL
        [HttpGet]
        [Route("GetAllRegionsID/{code}")]
        public async Task<IActionResult> GetAllRegionsID([FromRoute] string code)
        {
          

            try
            {
               var region = await _regionRepository.GetAllRegionsByID(code); // 2 records  //AP
               var regionDto = new RegionDTO();

                regionDto.Id = region.Id;
                regionDto.Code = region.Code;
                regionDto.Name = region.Name;
                regionDto.Lat = region.Lat;
                regionDto.Lat = region.Lat;
                regionDto.population = region.population;
                regionDto.Area = region.Area;
                return Ok(regionDto);
            }
            catch (Exception ex)
            {
                return BadRequest("Record is not available. Please enter another record.");
            }


           

           
        }



        //https://localhost:7148/Regions/CreateRegions
        [HttpPost]
        [Route("CreateRegions")]
        public async Task<IActionResult> CreateRegions([FromBody] AddRegtionDTO addRegtionDTO)
        {
            return Ok("Good");
        }
       


    }
}
