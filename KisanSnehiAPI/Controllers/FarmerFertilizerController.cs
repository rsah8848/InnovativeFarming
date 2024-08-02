using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KisanSnehi.Services;
using KisanSnehi.Services.Farmer;
using KisanSnehi.CustomExceptions;
using KisanSnehi.Entities;

namespace KisanSnehiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerFertilizerController : ControllerBase
    {
        private readonly IFarmerFertilizerService _farmerFertilizerService;

        public FarmerFertilizerController(IFarmerFertilizerService farmerFertilizerService)
        {
            _farmerFertilizerService = farmerFertilizerService;
        }

        [HttpGet]
        [Route("GetListOfFertilizers")]
        public async Task<ActionResult> GetListOfFertilizers()
        {
            try
            {
                return Ok(await _farmerFertilizerService.GetListOfFertilizers());
            }
            catch(RecordNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("AddFertilizerPurchase")]
        public async Task<ActionResult> AddFertilizerPurchase(FertilizerPurchase fertilizerPurchase)
        {
            try
            {
                return Ok(await _farmerFertilizerService.AddFertilizerPurchase(fertilizerPurchase));
            }
            catch (RecordNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("GetAllPurchasedFertilizers")]
        public async Task<ActionResult> GetAllPurchasedFertilizers()
        {
            try
            {
                return Ok(await _farmerFertilizerService.GetAllPurchasedFertilizers());
            }
            catch (RecordNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}