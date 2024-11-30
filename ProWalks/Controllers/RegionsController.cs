using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.Configuration;
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

        // 1. Input params
        // 2. return type


        //Sync
        //public int getid(string gname)
        //{
        //    return 1;
        //}


        //public async Task<int> getid(string name)
        //{
        //    await _______________________________;

        //    ///

        //    ///
        //    return 1;
        //}


        //public async Task<IActionResult> CreateRegionMethod(string code , string lat , string long , string area , string population)

        //API part
        //[HttpGet]
        //[Route("GetAllRegionsID/{code}")]

        [HttpPost] //postman
        [Route("CreateRegion")]

        
        //https://localhost:7148/Regions/CreateRegion
        //https://localhost:7148/Regions/CreateRegion

        public async Task<IActionResult> CreateRegionMethod([FromBody] AddRegtionDTO addRegtionDTO)
        {
            //await _________________
            return Ok("Good");

            // i will prepare the logic for insert the record.
        }


        //keerthi

        //Name in the passport  - keerthy   -- Keerthi based on which parameter we can update?

        // If you go the Mee seva Aadhar office offier i need the update the my name ... can you help on that 

        // Next reply from the officer -- AAdhar no  , passport no?


        // you can develp the update method ( PrimaryKey , what value you want to update )


        // you can develp the delete method ( PrimaryKey )

        ////CRUD


    }
}
