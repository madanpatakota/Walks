using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.Configuration;
using ProWalks.Data;
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
        ProWalksDbContext proWalksDbContext;

        //Deep logic  (instance of the Regionreposioty)
        public RegionsController(IRegionRepository regionRepository, ProWalksDbContext dbContext)
        {
            _regionRepository = regionRepository;
            this.proWalksDbContext = dbContext;
        }


        //Get the Result data from the Async call.
        //https://localhost:7148/Regions/GetAllRegions
        [HttpGet]
        [Authorize]
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

            var region = new Region
            {
                Code = addRegtionDTO.Code,
                Name = addRegtionDTO.Name,
                Lat = addRegtionDTO.Lat,
                Long = addRegtionDTO.Long,
                Area = addRegtionDTO.Area,
                population = addRegtionDTO.population
            };

            await _regionRepository.CreateRegion(region);

            var RegionDto = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name
            };

            return Ok(RegionDto);

            //await _________________
            //return Ok("Good");

            // i will prepare the logic for insert the record.
        }


        //keerthi

        //Name in the passport  - keerthy   -- Keerthi based on which parameter we can update?

        // If you go the Mee seva Aadhar office offier i need the update the my name ... can you help on that 

        // Next reply from the officer -- AAdhar no  , passport no?


        // you can develp the update method ( PrimaryKey , what value you want to update )


        // you can develp the delete method ( PrimaryKey )

        ////CRUD
        




        
        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="regionID"></param>
        /// <param name="newUpdateRegtionDTO"></param>
        /// <returns></returns>
        [HttpPut] //postman
        [Route("UpdateRegion/{regionID:Guid}")]

        //6234********************  , /// updating   //siva , tamilnadu 
        public async Task<IActionResult> UpdateRegionMethod([FromRoute] Guid regionID,  [FromBody] AddRegtionDTO newUpdateRegtionDTO)
        {

            //Instagram update image


            //1. input parameter should contain the id
            //2. you have to get the update record from the angular
            //3. find the exisiting record with the id and then replace the record with the update record


            //Find the record based on the id then i will connect with reposioty method.
            var regionDetails = await proWalksDbContext.Regions.FindAsync(regionID); 

            // your details 
            // var xyz =  //aadhardatabase.tamilnadudetails(787234********************);  //shiiiva

            //what kind of details regionDetails contains?

            if (regionDetails == null)
            {
                return NotFound();
            }

            regionDetails.Code       = newUpdateRegtionDTO.Code;
            regionDetails.population = newUpdateRegtionDTO.population;
            regionDetails.Area       = newUpdateRegtionDTO.Area;
            regionDetails.Lat = newUpdateRegtionDTO.Lat;
            regionDetails.Long = newUpdateRegtionDTO.Long;
            regionDetails.Name = newUpdateRegtionDTO.Name;


            Region region = await _regionRepository.UpdateRegion(regionID, regionDetails);

            var RegionDto = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name
            };

            return Ok(RegionDto);
        }




        /// <summary>
        /// Delete the record
        /// </summary>
        /// <param name="regionID"></param>
        /// <param name="newUpdateRegtionDTO"></param>
        /// <returns></returns>
        [HttpDelete] //postman
        [Route("DeleteRegion/{regionID:Guid}")]

        //6234********************  , /// updating   //siva , tamilnadu 
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid regionID)
        {

            

            //Find the record based on the id then i will connect with reposioty method.
            var regionDetails = await proWalksDbContext.Regions.FindAsync(regionID);

            // your details 
            // var xyz =  //aadhardatabase.tamilnadudetails(787234********************);  //shiiiva

            //what kind of details regionDetails contains?

            if (regionDetails == null)
            {
                return NotFound();
            }

            Region region = await _regionRepository.DeleteRegion(regionDetails);

            var RegionDto = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name
            };

            return Ok(RegionDto);
        }





    }
}
