using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KisanSnehi.Entities;
using KisanSnehi.Services.Farmer;
using KisanSnehi.CustomExceptions;

namespace KisanSnehiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerGuidanceController : ControllerBase
    {
        private readonly IFarmerGuidanceService _farmerGuidanceService;

        public FarmerGuidanceController(IFarmerGuidanceService farmerGuidanceService)
        {
            _farmerGuidanceService = farmerGuidanceService;
        }

        [HttpPost]
        [Route("GetGuidance")]
        public async Task<ActionResult> GetGuidance(Guidance guidance)
        {
            try
            {
                //Guidance guidance = new Guidance();
                //guidance.FromMonth = 5;
                //guidance.ToMonth = 6;
                return Ok(await _farmerGuidanceService.GetGuidance(guidance));
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