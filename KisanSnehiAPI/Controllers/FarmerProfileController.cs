using KisanSnehi.CustomExceptions;
using KisanSnehi.Entities;
using KisanSnehi.Services.Farmer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KisanSnehiAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FarmerProfileController : ControllerBase
    {
        IFarmerProfileServices _Services;

        public FarmerProfileController(IFarmerProfileServices farmerServices)
        {
            _Services = farmerServices;
        }

        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser([FromBody]string email)
        {
            try
            {
                email = Convert.ToString(email);
                return Ok(await _Services.GetUser(email));
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

        [HttpPost("GetPurchasedCrops")]
        public async Task<IActionResult> GetPurchasedCrops([FromBody]int farmerId)
        {
            try
            {
                
                return Ok(await _Services.GetPurchasedCrops(farmerId));
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

        [HttpPost("UpdateFarmerProfile")]
        public async Task<IActionResult> UpdateFarmerProfile([FromBody]Registration farmer)
        {
            try
            {
                return Ok(await _Services.UpdateFarmerProfile(farmer));
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

        [HttpPost("UpdateFarmerPassword")]
        public async Task<IActionResult> UpdateFarmerPassword(Registration farmer)
        {
            try
            {
                return Ok(await _Services.UpdateFarmerPassword(farmer));
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

        [HttpPost("AddFarmerFeedback")]
        public async Task<IActionResult> AddFarmerFeedback(Feedback feedback)
        {
            try
            {
                return Ok(await _Services.AddFarmerFeedback(feedback));
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


        [HttpPost("AddCrop")]
        public async Task<IActionResult> AddCrop(Crop crop)
        {
            try
            {
                return Ok(await _Services.AddCrop(crop));
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


        [HttpGet("GetCropsByName")]
        public async Task<IActionResult> GetCropsByName(string cropName, int farmerId)
        {
            try
            {
                return Ok(await _Services.GetCropsByName(cropName, farmerId));
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

        [HttpGet("GetCropsByPrice")]
        public async Task<IActionResult> GetCropsByPrice(int MinPrice, int MaxPrice, int farmerId)
        {
            try
            {
                return Ok(await _Services.GetCropsByPrice(MinPrice, MaxPrice, farmerId));
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

        [HttpPost("GetAllCrops")]
        public async Task<IActionResult> GetAllCrops([FromBody]int farmerId)
        {
            try
            {
                return Ok(await _Services.GetAllCrops(farmerId));
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

        [HttpPost("UpdateCropDetails")]
        public async Task<IActionResult> UpdateCropDetails(Crop crop)
        {
            try
            {
                return Ok(await _Services.UpdateCropDetails(crop));
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

        [HttpPost("UpdateCropImage")]
        public async Task<IActionResult> UpdateCropImage(Crop crop)
        {
            try
            {
                return Ok(await _Services.UpdateCropImage(crop));
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


        [HttpPost("UpdateFarmerProfileImage")]
        public async Task<IActionResult> UpdateFarmerProfileImage(Registration farmer)
        {
            try
            {
                return Ok(await _Services.UpdateFarmerProfileImage(farmer));
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

        [HttpPost("RemoveFarmerProfileImage")]
        public async Task<IActionResult> RemoveFarmerProfileImage(Registration user)
        {
            try
            {
                return Ok(await _Services.RemoveFarmerProfileImage(user));
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

        [HttpPost("DeleteCrop")]
        public async Task<IActionResult> DeleteCrop([FromBody]int cropId)
        {
            try
            {
                return Ok(await _Services.DeleteCrop(cropId));
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

        [HttpPost("AddFeedback")]
        public async Task<IActionResult> AddFeedback([FromBody]Feedback feedback)
        {
            try
            {
                return Ok(await _Services.AddFeedback(feedback));
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
