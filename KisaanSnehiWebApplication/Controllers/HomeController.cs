using KisaanSnehiWebApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KisaanSnehiWebApplication.Controllers
{
    public class HomeController : Controller
    {
        HttpClientHandler clientHandler = new HttpClientHandler();

        RegistrationModel registrationModel = new RegistrationModel();
        List<RegistrationModel> registrationModels = new List<RegistrationModel>();
        public HomeController()
        {
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoginOrSignUp()
        {
            List<LocationModel> locations = new List<LocationModel>();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Home/GetAllLocations"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    locations = JsonConvert.DeserializeObject<List<LocationModel>>(apiResponse);
                    ViewBag.locations = locations;
                }
            }
           
            return View();
        }
        [HttpGet]
        public IActionResult ChangePassword()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(RegistrationModel registration)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,12}$");
                Match match = regex.Match(registration.Password);
                if (match.Success)
                {
                    if (registration.Password != registration.ConfirmPassword)
                    {
                        ViewBag.ErrorMessage = "password and confirm password does not match";
                        throw new Exception("password doesn't match");
                    }

                    using (var httpClient = new HttpClient(clientHandler))
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(registration), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PostAsync("http://localhost:61806/api/Home/ChangePassword", content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            /*bool value = JsonConvert.DeserializeObject<bool>(apiResponse);*/
                            if (apiResponse == "this password is not available")
                            {
                                ViewBag.ErrorMessage = "this password is not available";
                                throw new Exception("this password is not available");
                            }
                            if (apiResponse == "No such record exists with this registration Id!!")
                            {
                                ViewBag.ErrorMessage = "No such record exists with this registration Id!!";
                                throw new Exception("No such record exists with this registration Id!!");
                            }
                            /*if (value == false)
                            {
                                ViewBag.ErrorMessage = "User not recognised";
                                throw new Exception("User not recognised");
                            }*/
                        }
                        ViewBag.ErrorMessage = "Password changed successfully";
                    }
                    return RedirectToAction("LoginOrSignUp", "Home");

                }
                else
                {
                    ViewBag.ErrorMessage = "Password does not match with the pattern";
                    throw new Exception("Password does not match with the pattern");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CheckLogin(RegistrationModel registration)
        {
            try
            {
                int value = 0;
                using (var httpClient = new HttpClient(clientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(registration), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:61806/api/Home/CheckLogin", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        value = JsonConvert.DeserializeObject<int>(apiResponse);
                    }
                }
                if (value == 0)
                {
                    ViewBag.ErrorMessage = "Invalid username or password";
                    return View();
                }
             /*
              * 1 = farmer
              * 2= supplier
              * 3=trader
              * 4=admin
              */
                else if (value == 1)

                {
                    var claims = new List<Claim>
                    {

                        new Claim(ClaimTypes.Email, registration.EmailId),
                        new Claim(ClaimTypes.Role,"Farmer")

                    };
                    var identity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                    HttpContext.Session.SetString("sessionEmail", registration.EmailId);
                    return RedirectToAction("Index", "FarmerProfile", new { @email = registration.EmailId });
                }
                    

                   

                else if (value == 2)
                {
                    var claims = new List<Claim>
                    {

                        new Claim(ClaimTypes.Email, registration.EmailId),
                        new Claim(ClaimTypes.Role,"Supplier")

                    };
                    var identity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                    
                    HttpContext.Session.SetString("sessionEmail", registration.EmailId);

                    return RedirectToAction("SupplierHome", "Supplier", new { @email = registration.EmailId });
                }
                else if (value == 3)
                {
                    var claims = new List<Claim>
                    {

                        new Claim(ClaimTypes.Email, registration.EmailId),
                        new Claim(ClaimTypes.Role,"Trader")

                    };
                    var identity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                    HttpContext.Session.SetString("sessionEmail", registration.EmailId);
                    
                     
                    return RedirectToAction("TraderHome", "Trader", new { @email = registration.EmailId });
                }
                else if (value == 4)
                {
                    var claims = new List<Claim>
                    {

                        new Claim(ClaimTypes.Email, registration.EmailId),
                        new Claim(ClaimTypes.Role,"admin")
                            
                    };

                    var identity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                    HttpContext.Session.SetString("sessionEmail", registration.EmailId);
                    ViewData["admin"] = HttpContext.Session.GetString("sessionEmail");
                    return RedirectToAction("Index", "Admin");
                }

                   


                else
                    return RedirectToAction("LoginOrSignUp", "Home");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRegistrationDetails(RegistrationModel registration)
        {
            try
            {

                if (registration.Password != registration.ConfirmPassword)
                {
                    ViewBag.ErrorMessage = "password and confirm password does not match";
                    throw new Exception("password doesn't match");
                }
                if (ModelState.IsValid)
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(registration), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PostAsync("http://localhost:61806/api/Home/AddRegistrationDetails", content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            /*bool value = JsonConvert.DeserializeObject<bool>(apiResponse);*/
                            if (apiResponse == " user already present")
                            {
                                ViewBag.ErrorMessage = "User Already Present";
                                throw new Exception("User Already Present");
                            }
                        }
                    }
                    return RedirectToAction("LoginOrSignUp", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "invalid details entered pleases try again!!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
