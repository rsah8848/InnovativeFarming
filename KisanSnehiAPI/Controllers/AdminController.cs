using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KisanSnehi.Services.Supplier;
using KisanSnehi.Entities;
using KisanSnehi.CustomExceptions;
using KisanSnehi.Services.Admin;
using Microsoft.AspNetCore.Authorization;

namespace KisanSnehiAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    
    public class AdminController : ControllerBase
    {
        private IAdminServices _Services;

        public AdminController(IAdminServices adminServices)
        {
            _Services = adminServices;
        }
        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser([FromBody] string email)
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

        [HttpPost("EditAdminProfile")]
        public async Task<IActionResult> EditAdminProfile(Registration admin)
        {
            try
            {
                return Ok(await _Services.EditAdminProfile(admin));
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

        [HttpPost("ChangeAdminPassword")]
        public async Task<IActionResult> ChangeAdminPassword(Registration admin)
        {
            try
            {
                return Ok(await _Services.ChangeAdminPassword(admin));
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

        [HttpPost("DeactivateAdminProfile")]
        public async Task<IActionResult> DeactivateAdminProfile(Registration registration)
        {
            try
            {
                return Ok(await _Services.DeactivateAdminProfile(registration));
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
        [HttpGet()]
        [Route("GetUsersById/{id}")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            try
            {
                return Ok(await _Services.GetUsersById(id));
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
        [Route("GetUsersByUserType/{id}")]
        public async Task<IActionResult> GetUsersByUserType(int id)
        {
            try
            {
                return Ok(await _Services.GetUsersByUserType(id));
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
        [Route("GetFeedbacks")]
        public async Task<IActionResult> GetFeedbacks()
        {
            try
            {
                return Ok(await _Services.GetFeedbacks());
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
        [Route("ResolveFeedback/{id}")]
        public async Task<IActionResult> ResolveFeedback(int id)
        {
            try
            {
                return Ok(await _Services.ResolveFeedback(id));
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
        [HttpGet()]
        [Route("FeedbackDeatails/{id}")]
        public async Task<IActionResult> FeedbackDeatails(int id)
        {
            try
            {
                return Ok(await _Services.FeedbackDeatails(id));
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
