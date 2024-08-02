using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using KisaanSnehiWebApplication.HttpHelper;
using KisaanSnehiWebApplication.Models;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using X.PagedList;

namespace KisaanSnehiWebApplication.Controllers
{
    [Authorize(Roles = "Trader")]
    public class TraderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        static int FertilizerId;

        KisanSnehiApi _kisanSnehiApi = new KisanSnehiApi();

        HttpClientHandler clientHandler = new HttpClientHandler();

        static RegistrationModel trader = new RegistrationModel();
        private IWebHostEnvironment _HostEnvironment { get; }

        public TraderController(IWebHostEnvironment hostEnvironment)
        {
            _HostEnvironment = hostEnvironment;


        }

        public async Task<IActionResult> TraderHome( string email) // [FromBody]
        {
            if (email == null && trader.EmailId != null)
                email = trader.EmailId;

            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<string>("api/Trader/GetUser", email);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            trader = registration;
            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;
            return View(trader);

        }

        public async Task<IActionResult> TraderProfile()
        {
            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<string>("api/Trader/GetUser", trader.EmailId);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            trader = registration;
            if (trader.Image == null)
                trader.Image = "null_image.png";
            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;
            return View(trader);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTraderProfile()
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
            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;

            return View(trader);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTraderProfile(int id, RegistrationModel tradermodel)
        {
            try
            {
                Regex regex = new Regex(@"^\(?([0-9]{10})\)?$");
                Match match = regex.Match(tradermodel.PhoneNo.ToString());
                if (match.Success)
                {
                    if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;

            tradermodel.RegId = trader.RegId;
            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<RegistrationModel>("api/Tarder/UpdateTraderProfile", tradermodel);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
            if (value == true)
            {
                return RedirectToAction("TraderProfile");
            }

            else
                return RedirectToAction("UpdateTraderProfile");

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

        [HttpGet]
        public ActionResult UploadProfilePicture(RegistrationModel model)
        {
            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;
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

            model.RegId = trader.RegId;
            model.EmailId = trader.EmailId;
            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<RegistrationModel>("api/Trader/UpdateTraderProfileImage", model);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
            if (value == true)
            {
                return RedirectToAction("TraderProfile");
            }

            return View();
        }

        [HttpGet]
        public IActionResult RemoveProfilePicture()
        {
            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;
            return View(trader);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProfilePicture(RegistrationModel model)
        {
            model = trader;
            if (model.Image == null)
                return RedirectToAction("TraderProfile");


            var imagePath = Path.Combine(_HostEnvironment.WebRootPath, "ImagesDB", model.Image);

            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<RegistrationModel>("api/Trader/RemoveProfilePicture", model);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
            if (value == true)
            {
                return RedirectToAction("TraderProfile");
            }


            return RedirectToAction("TraderProfile");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTraderProfile(int id)
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
                        
                    }
                    StringContent content = new StringContent(JsonConvert.SerializeObject(registration), Encoding.UTF8, "application/json");
                    using (var response1 = await httpClient.PostAsync("http://localhost:61806/api/Admin/DeactivateAdminProfile", content))
                    {
                        string apiResponse1 = await response1.Content.ReadAsStringAsync();
                        bool value = JsonConvert.DeserializeObject<bool>(apiResponse1);
                        if (value == false)
                        {
                            ViewBag.ErrorMessage = "Trader could not be deleted";
                        }
                    }
                }
                if (registration.EmailId == HttpContext.Session.GetString("sessionEmail"))
                    return RedirectToAction("LoginOrSignUp", "Home");
                else
                    return RedirectToAction("TraderHome", "Trader");

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult AddFertilizer()
        {
            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;
            FertilizerModel fertilizer = new FertilizerModel();
            return PartialView("AddFertilizer", fertilizer);
        }

        [HttpPost]
        public async Task<IActionResult> AddFertilizer(FertilizerModel fertilizer)
        {
            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;
            if (fertilizer.FertilizerName == null || fertilizer.FertilizerQuantity == 0 || fertilizer.FertilizerPrice == 0 || fertilizer.FertilizerName.Length > 50 || fertilizer.FertilizerDesc.Length > 200)
            {
                ViewBag.ErrorMessage = "Inavlid details entered.";
                return View();
            }
            if (fertilizer.ImageFile != null)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(fertilizer.ImageFile.FileName);
                string extension = Path.GetExtension(fertilizer.ImageFile.FileName);
                fertilizer.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/FertilizerImages/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await fertilizer.ImageFile.CopyToAsync(fileStream);
                }
            }
            fertilizer.TraderId = trader.RegId;

            using (var httpClient = new HttpClient(clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(fertilizer), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:61806/api/Trader/AddFertilizer", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }
            return RedirectToAction("GetAllFertlizers");
        }

        [HttpGet]
#nullable enable
        public async Task<IActionResult> GetAllFertilizers(string? searchName, int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;

            List<FertilizerModel> fertilizers = new List<FertilizerModel>();


            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = await client.PostAsJsonAsync<int>("api/Trader/GetAllFertilizers", trader.RegId);

            var result = postTask.Content.ReadAsStringAsync().Result;
            fertilizers = JsonConvert.DeserializeObject<List<FertilizerModel>>(result);

            foreach (var c in fertilizers)
            {
                if (c.Image == null)
                    c.Image = "nullfertilizer_image.jpg";
            }

            if (searchName != null)
                fertilizers = fertilizers.Where(c => c.FertilizerName.ToLower().StartsWith(searchName.ToLower())).ToList();

            return View(fertilizers.ToPagedList(pageIndex, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFertilizer(int id)
        {

            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;

            List<FertilizerModel> fertilizers = new List<FertilizerModel>();


            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = await client.PostAsJsonAsync<int>("api/Trader/GetAllFertilizers", trader.RegId);

            var result = postTask.Content.ReadAsStringAsync().Result;
            fertilizers = JsonConvert.DeserializeObject<List<FertilizerModel>>(result);
            FertilizerModel fertilizer = fertilizers.FirstOrDefault(c => c.FertilizerId == id);
            FertilizerId = fertilizer.FertilizerId;
            return PartialView(fertilizer); 
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFertilizer(FertilizerModel fertilizer)
        {


            fertilizer.FertilizerId = FertilizerId;
            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;


            if (fertilizer.ImageFile != null)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(fertilizer.ImageFile.FileName);
                string extension = Path.GetExtension(fertilizer.ImageFile.FileName);
                fertilizer.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/FertilizerImages/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await fertilizer.ImageFile.CopyToAsync(fileStream);
                }
            }

            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<FertilizerModel>("api/Trader/UpdateFertilizer", fertilizer);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
            if (value == true)
            {
                FertilizerId = 0;
                return RedirectToAction("GetAllFertilizers");
            }

            else
                return RedirectToAction("UpdateFertilizer");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFertilizer(int id)
        {

            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;

            List<FertilizerModel> fertilizers = new List<FertilizerModel>();


            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = await client.PostAsJsonAsync<int>("api/Trader/GetAllFertilizers", trader.RegId);

            var result = postTask.Content.ReadAsStringAsync().Result;
            fertilizers = JsonConvert.DeserializeObject<List<FertilizerModel>>(result);
            FertilizerModel fertilizer = fertilizers.FirstOrDefault(c => c.FertilizerId == id);
            FertilizerId = id;
            if (fertilizer.Image == null)
                fertilizer.Image = "nullfertilizer_image.jpg";

            return PartialView(fertilizer);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFertilizer()
        {


            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<int>("api/Trader/DeleteFertilizer", FertilizerId);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
            if (value == true)
            {
                FertilizerId = 0;
                return RedirectToAction("GetAllFertilizers");
            }

            else
                return RedirectToAction("DeleteFertilizer");
        }


        [HttpGet]
        public async Task<IActionResult> FertilizerDetails(int id)
        {

            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;

            List<FertilizerModel> fertilizers = new List<FertilizerModel>();


            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = await client.PostAsJsonAsync<int>("api/Trader/GetAllFertilizers", trader.RegId);

            var result = postTask.Content.ReadAsStringAsync().Result;
            fertilizers = JsonConvert.DeserializeObject<List<FertilizerModel>>(result);
            FertilizerModel fertilizer = fertilizers.FirstOrDefault(c => c.FertilizerId == id);
            if (fertilizer.Image == null)
                fertilizer.Image = "nullfertilizer_image.jpg";

            return View(fertilizer);
        }



        [HttpGet]
        public async Task<IActionResult> GetFertilizerSalesHistory()
        {
            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;

            List<FertilizerPurchaseModel> fertilizerPurchases = new List<FertilizerPurchaseModel>();
            List<FertilizerModel> allFertilizerList = new List<FertilizerModel>();
            
            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = await client.PostAsJsonAsync<int>("api/Trader/GetFertilizerSalesHistory", trader.RegId);

            var result = postTask.Content.ReadAsStringAsync().Result;
            fertilizerPurchases = JsonConvert.DeserializeObject<List<FertilizerPurchaseModel>>(result);

            var postTask2 = await client.PostAsJsonAsync<int>("api/Trader/GetAllFertilizers", trader.RegId);

            var result2 = postTask2.Content.ReadAsStringAsync().Result;
            allFertilizerList = JsonConvert.DeserializeObject<List<FertilizerModel>>(result2);

            List<RegistrationModel> registrationModels = new List<RegistrationModel>();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/GetUsersbyUserType/" + 1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    registrationModels = JsonConvert.DeserializeObject<List<RegistrationModel>>(apiResponse);
                }
            }

            foreach (FertilizerPurchaseModel f in fertilizerPurchases)
            {
                FertilizerModel fertilizer = allFertilizerList.FirstOrDefault(p => p.FertilizerId == f.FertilizerId);
                f.FertilizerName = fertilizer.FertilizerName;
                RegistrationModel farmer = registrationModels.FirstOrDefault(p => p.RegId == f.FarmerId);
                f.FarmerName = farmer.Name;
                f.PhoneNo = farmer.PhoneNo;
            }

            return View(fertilizerPurchases);

        }


        [HttpGet]
        public IActionResult UpdateTraderPassword()
        {
            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;
            ViewData["email"] = HttpContext.Session.GetString("sessionEmail");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTraderPassword(RegistrationModel trader)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,12}$");
                Match match = regex.Match(trader.Password);
                if (match.Success)
                {
                        trader.EmailId = HttpContext.Session.GetString("sessionEmail");
                    if (trader.Password != trader.ConfirmPassword)
                    {
                        ViewBag.ErrorMessage = "password and confirm password does not match";
                        throw new Exception("password doesn't match");
                    }

                    using (var httpClient = new HttpClient(clientHandler))
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(trader), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PostAsync("http://localhost:61806/api/Trader/UpdateTraderPassword", content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
                            if (value == false)
                            {
                                ViewBag.ErrorMessage = "User not recognised";
                                throw new Exception("User not recognised");
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
        public IActionResult AddFeedback()
        {
            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;
            FeedbackModel feedback = new FeedbackModel();
            return View(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback(FeedbackModel feedback)
        {

            feedback.RegId = trader.RegId;
            bool value = false;
            using (var httpClient = new HttpClient(clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(feedback), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:61806/FarmerProfile/AddFeedback", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //if(!apiResponse.Equals("server error occured!"))
                    value = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }
            if (value == true)
                ViewBag.Message = "Feedback sent successfully.";
            return RedirectToAction("AddFeedback");

        }

        public IActionResult Error()
        {
            if (trader.Image == null)
                trader.Image = "null_image.png";

            ViewBag.Name = trader.Name;
            ViewBag.ProfilePicture = trader.Image;
            return View();
        }

    }
}
