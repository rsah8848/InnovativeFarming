using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KisanSnehi.Services.Supplier;
using KisanSnehi.Entities;
using KisanSnehi.CustomExceptions;

namespace KisanSnehiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private ISupplierServices _Services;

        public SupplierController(ISupplierServices supplierServices)
        {
            _Services = supplierServices;
        }

        [HttpPost("GetSupplier")]
        public async Task<IActionResult> GetSupplier([FromBody] string emailId)
        {
            try
            {
                emailId = Convert.ToString(emailId);
                return Ok(await _Services.GetSupplier(emailId));
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

        [HttpPost("EditSupplierProfile")]
        public async Task<IActionResult> EditSupplierProfile([FromBody] Registration supplier)
        {
            try
            {
                return Ok(await _Services.EditSupplierProfile(supplier));
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

        [HttpPost("ChangeSupplierPassword")]
        public async Task<IActionResult> ChangeSupplierPassword(Registration supplier)
        {
            try
            {
                return Ok(await _Services.ChangeSupplierPassword(supplier));
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

        [HttpPost("DeactivateSupplierProfile")]
        public async Task<IActionResult> DeactivateSupplierProfile(Registration supplier)
        {
            try
            {
                return Ok(await _Services.DeactivateSupplierProfile(supplier));
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

        [HttpPost("UpdateSupplierProfileImage")]
        public async Task<IActionResult> UpdateSupplierProfileImage(Registration supplier)
        {
            try
            {
                return Ok(await _Services.UpdateSupplierProfileImage(supplier));
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

        [HttpPost("RemoveSupplierProfileImage")]
        public async Task<IActionResult> RemoveSupplierProfileImage(Registration supplier)
        {
            try
            {
                return Ok(await _Services.RemoveSupplierProfileImage(supplier));
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

        [HttpGet("GetListOfAllAvailableCrops")]
        public async Task<IActionResult> GetListOfAllAvailableCrops()
        {
            try
            {
                return Ok(await _Services.GetListOfAllAvailableCrops());
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

        [HttpGet("GetListOfCropsByName")]
        public async Task<IActionResult> GetListOfCropsByName(string cropName)
        {
            try
            {
                return Ok(await _Services.GetListOfCropsByName(cropName));
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

        [HttpGet("GetListOfCropsByPrice")]
        public async Task<IActionResult> GetListOfCropsByPrice(float cropPriceLowerLimit, float cropPriceUpperLimit)
        {
            try
            {
                return Ok(await _Services.GetListOfCropsByPrice(cropPriceLowerLimit, cropPriceUpperLimit));
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

        [HttpGet("GetListOfCropsByLocation")]
        public async Task<IActionResult> GetListOfCropsByLocation(string state, string city)
        {
            try
            {
                return Ok(await _Services.GetListOfCropsByLocation(state, city));
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
        [Route("AddCropPurchase")]
        public async Task<ActionResult> AddCropPurchase(CropPurchase cropPurchase)
        {
            try
            {
                return Ok(await _Services.AddCropPurchase(cropPurchase));
            }
            catch (InvalidIdException ex)
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
        [Route("GetCropPurchaseHistory")]
        public async Task<ActionResult> GetCropPurchaseHistory()
        {
            try
            {
                return Ok(await _Services.GetCropPurchaseHistory());
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

        [HttpPost("AddSupplierFeedback")]
        public async Task<IActionResult> AddSupplierFeedback([FromBody] Feedback feedback)
        {
            try
            {
                return Ok(await _Services.AddSupplierFeedback(feedback));
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
