using KisaanSnehiWebApplication.HttpHelper;
using KisaanSnehiWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Mvc.Core;

using System.Text.RegularExpressions;

namespace KisaanSnehiWebApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {

        HttpClientHandler clientHandler = new HttpClientHandler();

        RegistrationModel registrationModel = new RegistrationModel();
        List<RegistrationModel> registrationModels = new List<RegistrationModel>();
        KisanSnehiApi _api = new KisanSnehiApi();

        private IWebHostEnvironment _HostEnvironment { get; }

        static RegistrationModel admin = new RegistrationModel();
        public AdminController(IWebHostEnvironment hostEnvironment)
        {
            _HostEnvironment = hostEnvironment;
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        }

        public async Task<IActionResult> Index()
        {
            string email = HttpContext.Session.GetString("sessionEmail");
            if (email == null && admin.EmailId != null)
                email = admin.EmailId;

            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<string>("FarmerProfile/GetUser", email);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            admin = registration;
            if (admin.Image == null)
                admin.Image = "null_image.png";

            ViewBag.Name = admin.Name;
            ViewBag.ProfilePicture = admin.Image;
            return View(admin);
        }

        public async Task<IActionResult> AdminProfilePage()
        {
            RegistrationModel registration = new RegistrationModel();
            admin.EmailId = HttpContext.Session.GetString("sessionEmail");
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<string>("FarmerProfile/GetUser", admin.EmailId);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            admin = registration;
            if (admin.Image == null)
                admin.Image = "null_image.png";
            ViewBag.Name = admin.Name;
            ViewBag.ProfilePicture = admin.Image;
            return View(admin);
        }
        [HttpGet]
        public async Task<IActionResult> GetFarmersList(int? page)
        {
            registrationModels = new List<RegistrationModel>();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/GetUsersByUserType/" + 1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    registrationModels = JsonConvert.DeserializeObject<List<RegistrationModel>>(apiResponse);
                    /*ViewData["actors"] = actorModels;*/
                }
            }
            return View(registrationModels.ToPagedList(page ?? 1, 5));
            /*return View(registrationModels);*/
        }
        [HttpGet]
        public async Task<IActionResult> GetSuppliersList(int? i)
        {
            registrationModels = new List<RegistrationModel>();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/GetUsersByUserType/" + 2))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    registrationModels = JsonConvert.DeserializeObject<List<RegistrationModel>>(apiResponse);
                    /*ViewData["actors"] = actorModels;*/
                }
            }
            return View(registrationModels.ToPagedList(i ?? 1, 5));
        }
        [HttpGet]
        public async Task<IActionResult> GetTradersList(int? i)
        {
            registrationModels = new List<RegistrationModel>();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/GetUsersByUserType/" + 3))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    registrationModels = JsonConvert.DeserializeObject<List<RegistrationModel>>(apiResponse);
                    /*ViewData["actors"] = actorModels;*/
                }
            }
            return View(registrationModels.ToPagedList(i ?? 1, 5));
        }
        [HttpGet]
        public async Task<IActionResult> GetAdminsList(int? page)
        {
            registrationModels = new List<RegistrationModel>();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/GetUsersByUserType/" + 4))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    registrationModels = JsonConvert.DeserializeObject<List<RegistrationModel>>(apiResponse);
                    /*ViewData["actors"] = actorModels;*/
                }
            }
            return View(registrationModels.ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        public async Task<IActionResult> EditAdminProfile()
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
            ViewData["email"] = HttpContext.Session.GetString("sessionEmail");
            if (admin.Image == null)
                admin.Image = "null_image.png";

            ViewBag.Name = admin.Name;
            ViewBag.ProfilePicture = admin.Image;

            return View(admin);
             
        }
        [HttpPost]
        public async Task<IActionResult> EditAdminProfile(RegistrationModel registration)
        {
            try
            {
                Regex regex = new Regex(@"^\(?([0-9]{10})\)?$");
                Match match = regex.Match(registration.PhoneNo.ToString());
                if (match.Success)
                {
                    if (admin.Image == null)
                        admin.Image = "null_image.png";

                    ViewBag.Name = admin.Name;
                    ViewBag.ProfilePicture = admin.Image;
                    registration.EmailId = HttpContext.Session.GetString("sessionEmail");

                    using (var httpClient = new HttpClient(clientHandler))
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(registration), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PostAsync("http://localhost:61806/api/Admin/EditAdminProfile", content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
                        }
                    }
                    return RedirectToAction("AdminProfilePage", "Admin");
                }
                 
                else
                {
                    ViewBag.ErrorMessage = "Invalid phone number";
                    throw new Exception("Invalid phone number");
                    /*throw new Exception("Invalid phone number");*/
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                
                return RedirectToAction("Error");
            }
        }
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangeAdminPassword()
        {
            ViewData["email"] = HttpContext.Session.GetString("sessionEmail");
            if (admin.Image == null)
                admin.Image = "null_image.png";

            ViewBag.Name = admin.Name;
            ViewBag.ProfilePicture = admin.Image;
            return View(admin);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeAdminPassword(RegistrationModel registration)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,12}$");
                Match match = regex.Match(registration.Password);
                if (match.Success)
                {
                    if (admin.Image == null)
                        admin.Image = "null_image.png";

                    ViewBag.Name = admin.Name;
                    ViewBag.ProfilePicture = admin.Image;
                    registration.EmailId = HttpContext.Session.GetString("sessionEmail");
                    if (registration.Password != registration.ConfirmPassword)
                    {
                        ViewBag.ErrorMessage = "password and confirm password does not match";
                        throw new Exception("password doesn't match");
                    }

                    using (var httpClient = new HttpClient(clientHandler))
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(registration), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PostAsync("http://localhost:61806/api/Admin/ChangeAdminPassword", content))
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

        [HttpGet]
        public ActionResult UploadProfilePicture(RegistrationModel model)
        {
            if (admin.Image == null)
                admin.Image = "null_image.png";

            ViewBag.Name = admin.Name;
            ViewBag.ProfilePicture = admin.Image;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfilePicture(int id, RegistrationModel model)
        {
            if (model.ImageFile.FileName == null)
                return View();

            string wwwRootPath = _HostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string extension = Path.GetExtension(model.ImageFile.FileName);
            model.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/ImagesDB/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }



            model.RegId = admin.RegId;
            model.EmailId = admin.EmailId;
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<RegistrationModel>("FarmerProfile/UpdateFarmerProfileImage", model);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
            if (value == true)
            {
                return RedirectToAction("AdminProfilePage");
            }


            return View();
        }
        [HttpGet]
        public IActionResult RemoveProfilePicture()
        {
            if (admin.Image == null)
                admin.Image = "null_image.png";

            ViewBag.Name = admin.Name;
            ViewBag.ProfilePicture = admin.Image;
            return View(admin);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProfilePicture(RegistrationModel model)
        {
            model = admin;
            if (model.Image == null)
                return RedirectToAction("AdminProfilePage");


            var imagePath = Path.Combine(_HostEnvironment.WebRootPath, "ImagesDB", model.Image);

            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<RegistrationModel>("FarmerProfile/RemoveFarmerProfileImage", model);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
            if (value == true)
            {
                return RedirectToAction("AdminProfilePage");
            }


            return RedirectToAction("AdminProfilePage");
        }


        [HttpGet]
        public async Task<IActionResult> GetFeedbacks()
        {
            List<FeedbackModel> feedbacks = new List<FeedbackModel>();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/GetFeedbacks/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    feedbacks = JsonConvert.DeserializeObject<List<FeedbackModel>>(apiResponse);
                    /*ViewData["actors"] = actorModels;*/
                }
            }
            return View(feedbacks);
        }
        [HttpGet]
        public async Task<IActionResult> FeedbackDeatails(int id)
        {
            RegistrationModel registration = new RegistrationModel();
            FeedbackModel feedback = new FeedbackModel();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/FeedbackDeatails/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    feedback = JsonConvert.DeserializeObject<FeedbackModel>(apiResponse);
                    /*ViewData["actors"] = actorModels;*/
                }
                using (var response1 = await httpClient.GetAsync("http://localhost:61806/api/Admin/GetUsersById/" + feedback.RegId))
                {
                    string apiResponse = await response1.Content.ReadAsStringAsync();
                    registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);
                    ViewData["userEmail"] = registration.EmailId;
                    if (registration.UserTypeId == 1)
                    {
                        ViewData["userType"] = "Farmer";
                    }
                    else if (registration.UserTypeId == 2)
                    {
                        ViewData["userType"] = "Supplier";
                    }
                    else
                    {
                        ViewData["userType"] = "Trader";
                    }

                }
            }
            return View(feedback);
        }
        [HttpGet]
        public async Task<IActionResult> ResolveFeedback(int id)
        {
            bool value;
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/ResolveFeedback/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    value = JsonConvert.DeserializeObject<bool>(apiResponse);
                    /*ViewData["actors"] = actorModels;*/
                }
            }
            return RedirectToAction("GetFeedbacks");
        }

        [HttpGet]
        public async Task<IActionResult> AddAdmin()
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
        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegistrationModel registration)
        {
            try
            {

                registration.UserTypeId = 4;
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
                            //bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
                            if (apiResponse == " user already present")
                            {
                                ViewBag.ErrorMessage = "Admin Already Present";
                                throw new Exception("Admin Already Present");
                            }
                        }
                    }
                    return RedirectToAction("Index", "Admin");
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
        /*[HttpGet]
        public void DeactivateAdmin()
        {

        }*/
        /*[HttpPost]*/
        /*[HttpGet]*/
        [HttpGet]
        public async Task<RegistrationModel> Getuser(int id)
        {
            RegistrationModel registration = new RegistrationModel();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/GetUsersById/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);
                    /*ViewData["actors"] = actorModels;*/
                }
            }
            return registration;
        }
        public async Task<IActionResult> DeactivateAdmin(int id)
        {
            try
            {
                RegistrationModel registration = new RegistrationModel();

                using (var httpClient = new HttpClient(clientHandler))
                {
                    using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/GetUsersById/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);
                        /*ViewData["actors"] = actorModels;*/
                    }
                    StringContent content = new StringContent(JsonConvert.SerializeObject(registration), Encoding.UTF8, "application/json");
                    using (var response1 = await httpClient.PostAsync("http://localhost:61806/api/Admin/DeactivateAdminProfile", content))
                    {
                        string apiResponse1 = await response1.Content.ReadAsStringAsync();
                        bool value = JsonConvert.DeserializeObject<bool>(apiResponse1);
                        if (value == false)
                        {
                            ViewBag.ErrorMessage = "Admin could not be deleted";
                        }
                    }
                }
                if (registration.EmailId == HttpContext.Session.GetString("sessionEmail"))
                    return RedirectToAction("LoginOrSignUp", "Home");
                else
                    return RedirectToAction("GetAdminsList", "Admin");

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
