using KisanSnehi.CustomExceptions;
using KisanSnehi.Entities;
using KisanSnehi.Services.Farmer;
using KisanSnehi.Services.Home;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KisanSnehiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        IHomeServices _services;

        public HomeController(IHomeServices homeServices)
        {
            _services = homeServices;
        }


        [HttpPost("AddRegistrationDetails")]
        public async Task<IActionResult> AddRegistrationDetails(Registration registration)
        {
            try
            {
                return Ok(await _services.AddRegistrationDetails(registration));
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
        [HttpGet("GetRegistrationDetails")]
        public async Task<IActionResult> GetRegistrationDetails()
        {
            try
            {
                return Ok(await _services.GetRegistrationDetails());
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
        [HttpGet("GetAllLocations")]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                return Ok(await _services.GetAllLocations());
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
        [HttpPost("CheckLogin")]
        public async Task<IActionResult> CheckLogin(Registration registration)
        {
            try
            {
                return Ok(await _services.CheckLogin(registration));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(Registration registration)
        {
            try
            {
                return Ok(await _services.ChangePassword(registration));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
