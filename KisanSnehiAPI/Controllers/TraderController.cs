using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KisanSnehi.Services.Trader;
using KisanSnehi.CustomExceptions;
using KisanSnehi.Entities;


namespace KisanSnehiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraderController : ControllerBase
    {
        ITraderServices _traderServices;

        public TraderController(ITraderServices traderServices)
        {
            _traderServices = traderServices;
        }

        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser([FromBody] string email)
        {
            try
            {
                email = Convert.ToString(email);
                return Ok(await _traderServices.GetUser(email));
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

        [HttpGet()]
        [Route("GetUsersById/{id}")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            try
            {
                return Ok(await _traderServices.GetUsersById(id));
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

        [HttpPost]
        [Route("UpdateTraderProfile")]
        public async Task<IActionResult> UpdateTraderProfile([FromBody] Registration trader)
        {
            try
            {
                return Ok(await _traderServices.UpdateTraderProfile(trader));
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

        [HttpPost("UpdateTraderProfileImage")]
        public async Task<IActionResult> UpdateTraderProfileImage(Registration trader)
        {
            try
            {
                return Ok(await _traderServices.UpdateTraderProfileImage(trader));
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

        [HttpPost("RemoveProfilePicture")]
        public async Task<IActionResult> RemoveProfilePicture(Registration user)
        {
            try
            {
                return Ok(await _traderServices.RemoveProfilePicture(user));
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

        [HttpPost]
        [Route("UpdateTraderPassword")]
        public async Task<IActionResult> UpdateTraderPassword(Registration trader)
        {
            try
            {
                return Ok(await _traderServices.UpdateTraderPassword(trader));
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

        [HttpPost]
        [Route("DeleteTraderProfile")]
        public async Task<IActionResult> DeleteTraderProfile(Registration trader)
        {
            try
            {
                return Ok(await _traderServices.DeleteTraderProfile(trader));
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

        [HttpPost]
        [Route("AddFertilizer")]
        public async Task<IActionResult> AddFertilizer(Fertilizer fertilizer)
        {
            try
            {
                return Ok(await _traderServices.AddFertilizer(fertilizer));
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

        [HttpPost]
        [Route("UpdateFertilizer")]
        public async Task<IActionResult> UpdateFertilizer(Fertilizer fertilizer)
        {
            try
            {
                return Ok(await _traderServices.UpdateFertilizer(fertilizer));
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

        [HttpPost]
        [Route("DeleteFertilizer")]
        public async Task<IActionResult> DeleteFertilizer([FromBody] int fertilizerId)
        {
            try
            {
                return Ok(await _traderServices.DeleteFertilizer(fertilizerId));
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

        [HttpPost]
        [Route("AddTraderFeedback")]
        public async Task<IActionResult> AddTraderFeedback(Feedback feedback)
        {
            try
            {
                return Ok(await _traderServices.AddTraderFeedback(feedback));
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

        [HttpPost]
        [Route("GetFertilizerByName")]
        public async Task<ActionResult> GetFertilizerByName(Fertilizer fertilzer)
        {
            try
            {
                int traderId = fertilzer.TraderId;
                string name = fertilzer.FertilizerName;
                return Ok(await _traderServices.GetFertilizerByName(name,traderId));
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
        [Route("GetFertilizerByPrice")]
        public async Task<ActionResult> GetFertilizerByPrice(int MinPrice, int MaxPrice, int traderId)
        {
            try
            {
                return Ok(await _traderServices.GetFertilizerByPrice(MinPrice, MaxPrice, traderId));
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

        [HttpPost]
        [Route("GetAllFertilizers")]
        public async Task<ActionResult> GetAllFertilizers([FromBody] int traderId)
        {
            try
            {
                return Ok(await _traderServices.GetAllFertilizers(traderId));
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

        [HttpPost]
        [Route("GetFertilizerSalesHistory")]
        public async Task<ActionResult> GetFertilizerSalesHistory()
        {
            try
            {
                return Ok(await _traderServices.GetFertilizerSalesHistory());
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

        [HttpPost]
        [Route("AddFeedback")]
        public async Task<IActionResult> AddFeedback([FromBody] Feedback feedback)
        {
            try
            {
                return Ok(await _traderServices.AddFeedback(feedback));
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
