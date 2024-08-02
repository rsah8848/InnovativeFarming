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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using X.PagedList;

namespace KisaanSnehiWebApplication.Controllers
{
    [Authorize(Roles = "Farmer")]
    public class FarmerProfileController : Controller
    {

        static int CropId ;

        HttpClientHandler clientHandler = new HttpClientHandler();

        KisanSnehiApi _api = new KisanSnehiApi();

        private IWebHostEnvironment _HostEnvironment { get; }

        static RegistrationModel farmer = new RegistrationModel();

        public FarmerProfileController(IWebHostEnvironment hostEnvironment)
        {
            _HostEnvironment = hostEnvironment;

            
        }

        public async  Task<IActionResult> Index(string email)
        {
            if (email == null && farmer.EmailId != null)
                email = farmer.EmailId;

            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<string>("FarmerProfile/GetUser", email);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            farmer = registration;
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            return View(farmer);
           
        }

        public async Task<IActionResult> FarmerProfilePage()
        {
            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<string>("FarmerProfile/GetUser", farmer.EmailId);
            postTask.Wait();
            string apiResponse =await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            farmer = registration;
            List<LocationModel> locations = new List<LocationModel>();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Home/GetAllLocations"))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    locations = JsonConvert.DeserializeObject<List<LocationModel>>(apiResponse);
                    ViewBag.locations = locations;
                }
            }
            LocationModel location = locations.FirstOrDefault(l => l.LocationId == farmer.LocationId);
            ViewBag.State = location.State;
            ViewBag.City = location.City;
            ViewBag.Pin = location.Pin;
            if (farmer.Image == null)
                farmer.Image = "null_image.png";
            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            return View(farmer);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
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
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;

            return View(farmer);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(int id, RegistrationModel farmermodel)
        {
            try {
                Regex regex = new Regex(@"^\(?([0-9]{10})\)?$");
                Match match = regex.Match(farmermodel.PhoneNo.ToString());
                if (match.Success)
                {
                    if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            
            farmermodel.RegId = farmer.RegId;
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<RegistrationModel>("FarmerProfile/UpdateFarmerProfile", farmermodel);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
            if (value == true)
            {
                return RedirectToAction("FarmerProfilePage");
            }
                
            else
                return RedirectToAction("EditProfile");


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
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfilePicture(int id,RegistrationModel model)
        {
            try
            {
                if (model.ImageFile == null)
                {
                    ViewBag.ErrorMessage = "Invalid phone number";
                    throw new Exception("Invalid phone number");
                }

                string wwwRootPath = _HostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                model.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/ImagesDB/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }



                model.RegId = farmer.RegId;
                model.EmailId = farmer.EmailId;
                HttpClient client = _api.Initial();
                var postTask = client.PostAsJsonAsync<RegistrationModel>("FarmerProfile/UpdateFarmerProfileImage", model);
                postTask.Wait();
                string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
                bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
                if (value == true)
                {
                    return RedirectToAction("FarmerProfilePage");
                }
                else
                {
                    return RedirectToAction("UploadProfilePicture");
                }
                //return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;

                return RedirectToAction("Error");
            }
        }


        [HttpGet]
        public IActionResult RemoveProfilePicture()
        {
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            return View(farmer);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProfilePicture(RegistrationModel model)
        {
            model = farmer;
            if (model.Image == null)
                return RedirectToAction("FarmerProfilePage");


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
                return RedirectToAction("FarmerProfilePage");
            }


            return RedirectToAction("FarmerProfilePage");
        }


        [HttpGet]
        #nullable enable
        public async Task<IActionResult> DisplayAllCrops(string? searchName, int? page)
        {

            int pageSize = 10;
            int pageIndex =  1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;

            List<CropModel> crops = new List<CropModel>();
            

            HttpClient client = _api.Initial();
            var postTask = await client.PostAsJsonAsync<int>("FarmerProfile/GetAllCrops", farmer.RegId);
            
            var result = postTask.Content.ReadAsStringAsync().Result;
            crops = JsonConvert.DeserializeObject<List<CropModel>>(result);

            foreach(var c in crops)
            {
                if (c.Image == null)
                    c.Image = "empty_cropImage.jpg";
            }

            //crops = crops.Where(c => c.CropPrice <= 2000 && c.CropPrice >= 1000).ToList();
            if(searchName!=null)
            crops = crops.Where(c => c.CropName.ToLower().StartsWith(searchName.ToLower())).ToList();
            crops = crops.Where(c => c.IsDeleted==false).ToList();

            crops.Reverse();

            return View(crops.ToPagedList(pageIndex,pageSize));
        }

        [HttpGet]
        public IActionResult AddCrop()
        {
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            CropModel crop = new CropModel();
            return PartialView("AddCrop", crop);
        }

        [HttpPost]
        public async Task<IActionResult> AddCrop(CropModel crop)
        {
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            if (crop.CropName==null || crop.CropQuantity==0 || crop.CropPrice ==0 || crop.CropName.Length>50 || crop.CropDesc.Length>200)
            {
                ViewBag.ErrorMessage = "Inavlid details entered.";
                return View();
            }
            if (crop.ImageFile != null)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(crop.ImageFile.FileName);
                string extension = Path.GetExtension(crop.ImageFile.FileName);
                crop.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/CropImages/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await crop.ImageFile.CopyToAsync(fileStream);
                }
            }
            crop.FarmerId = farmer.RegId;
            bool value = false;
            using (var httpClient = new HttpClient(clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(crop), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:61806/FarmerProfile/AddCrop", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //if(!apiResponse.Equals("server error occured!"))
                        value = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }
            return RedirectToAction("DisplayAllCrops");

        }

        [HttpGet]
        public async Task<IActionResult> EditCrop(int id)
        {
            
            //HttpContext.Session.SetInt32(SessionCropId,id);
            
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;

            List<CropModel> crops = new List<CropModel>();


            HttpClient client = _api.Initial();
            var postTask = await client.PostAsJsonAsync<int>("FarmerProfile/GetAllCrops", farmer.RegId);

            var result = postTask.Content.ReadAsStringAsync().Result;
            crops = JsonConvert.DeserializeObject<List<CropModel>>(result);
            CropModel crop = crops.FirstOrDefault(c => c.CropId == id);
            CropId = id;

            return PartialView(crop);
        }

        [HttpPost]
        public async Task<IActionResult> EditCrop(CropModel crop) 
        {
            crop.CropId = CropId;
            //crop.CropId= Convert.ToInt32(HttpContext.Session.GetInt32(SessionCropId));
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;


            if (crop.ImageFile != null)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(crop.ImageFile.FileName);
                string extension = Path.GetExtension(crop.ImageFile.FileName);
                crop.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/CropImages/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await crop.ImageFile.CopyToAsync(fileStream);
                }
            }

            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<CropModel>("FarmerProfile/UpdateCropDetails", crop);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
            if (value == true)
            {
                CropId = 0;
                return RedirectToAction("DisplayAllCrops");
            }

            else
                return RedirectToAction("EditCrop");
        }

        [HttpGet]
        public async Task<IActionResult> CropDetails(int id) 
        {

            //HttpContext.Session.SetInt32(SessionCropId,id);

            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;

            List<CropModel> crops = new List<CropModel>();


            HttpClient client = _api.Initial();
            var postTask = await client.PostAsJsonAsync<int>("FarmerProfile/GetAllCrops", farmer.RegId);

            var result = postTask.Content.ReadAsStringAsync().Result;
            crops = JsonConvert.DeserializeObject<List<CropModel>>(result);
            CropModel crop = crops.FirstOrDefault(c => c.CropId == id);
            if (crop.Image == null)
                crop.Image = "empty_cropImage.jpg";

            return View(crop);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteCrop(int id)
        {

            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;

            List<CropModel> crops = new List<CropModel>();


            HttpClient client = _api.Initial();
            var postTask = await client.PostAsJsonAsync<int>("FarmerProfile/GetAllCrops", farmer.RegId);

            var result = postTask.Content.ReadAsStringAsync().Result;
            crops = JsonConvert.DeserializeObject<List<CropModel>>(result);
            CropModel crop = crops.FirstOrDefault(c => c.CropId == id);
            CropId = id;
            if (crop.Image == null)
                crop.Image = "empty_cropImage.jpg";

            return PartialView(crop);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCrop()
        {
            

            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<int>("FarmerProfile/DeleteCrop", CropId);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            bool value = JsonConvert.DeserializeObject<bool>(apiResponse);
            if (value == true)
            {
                CropId = 0;
                return RedirectToAction("DisplayAllCrops");
            }

            else
                return RedirectToAction("DeleteCrop");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {

            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            ViewData["email"] = HttpContext.Session.GetString("sessionEmail");
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
        #nullable enable
        public async Task<IActionResult> GetPurchasedCrops(DateTime? date,DateTime? todate, string? searchName, int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;

            List<CropPurchaseModel> purchasedCrops = new List<CropPurchaseModel>();
            List<CropModel> allCropList = new List<CropModel>();


            HttpClient client = _api.Initial();
            var postTask = await client.PostAsJsonAsync<int>("FarmerProfile/GetPurchasedCrops", farmer.RegId);

            var result = postTask.Content.ReadAsStringAsync().Result;
            purchasedCrops = JsonConvert.DeserializeObject<List<CropPurchaseModel>>(result);

            var postTask2 = await client.PostAsJsonAsync<int>("FarmerProfile/GetAllCrops", farmer.RegId);

            var result2 = postTask2.Content.ReadAsStringAsync().Result;
            allCropList = JsonConvert.DeserializeObject<List<CropModel>>(result2);

            List<RegistrationModel> registrationModels = new List<RegistrationModel>();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/GetUsersByUserType/" + 2))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    registrationModels = JsonConvert.DeserializeObject<List<RegistrationModel>>(apiResponse);
                    /*ViewData["actors"] = actorModels;*/
                }
            }

            foreach (CropPurchaseModel c in purchasedCrops)
            {
                CropModel crop = allCropList.FirstOrDefault(p => p.CropId == c.CropId);
                c.CropName = crop.CropName;
                RegistrationModel supplier = registrationModels.FirstOrDefault(p => p.RegId == c.SupplierId);
                c.SupplierName = supplier?.Name;
                c.PhoneNo = supplier?.PhoneNo ?? 0;
                string month = c.CropPurchaseDate.ToString("MMM");
                string day = c.CropPurchaseDate.Day.ToString();
                string yr = c.CropPurchaseDate.Year.ToString();
                c.DateOfPurchase = day + " " + month + ", " + yr;

            }
            purchasedCrops.Reverse();
            if (searchName != null)
                purchasedCrops = purchasedCrops.Where(c => c.SupplierName.ToLower().StartsWith(searchName.ToLower())).ToList();

            if (date != null && todate!=null)
                purchasedCrops = purchasedCrops.Where(c => c.CropPurchaseDate>=(date) && c.CropPurchaseDate<=todate).ToList();

            if(date!=null && todate==null)
                purchasedCrops = purchasedCrops.Where(c => c.CropPurchaseDate >= (date)).ToList();

            if (date == null && todate != null)
                purchasedCrops = purchasedCrops.Where(c => c.CropPurchaseDate <= (todate)).ToList();


            return View(purchasedCrops.ToPagedList(pageIndex, pageSize));
        }



        [HttpGet]
        public IActionResult AddFeedback() 
        {
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            FeedbackModel feedback = new FeedbackModel();
            return View(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback(FeedbackModel feedback)
        {

            feedback.RegId = farmer.RegId;
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
            if(value==true)
            ViewBag.Message = "Feedback sent successfully.";
            return RedirectToAction("AddFeedback");

        }

        [HttpGet]
        public IActionResult DeactivateAccount(int id)
        {
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            FeedbackModel feedback = new FeedbackModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeactivateAccount() 
        {
            try
            {
                int id = farmer.RegId;
                if (farmer.Image == null)
                    farmer.Image = "null_image.png";

                ViewBag.Name = farmer.Name;
                ViewBag.ProfilePicture = farmer.Image;
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
                            ViewBag.ErrorMessage = "User cannot be deleted";
                        }
                    }
                }
                if (registration.EmailId == HttpContext.Session.GetString("sessionEmail"))
                    return RedirectToAction("LoginOrSignUp", "Home");
                else
                    return RedirectToAction("Index", "FarmerProfile");

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }





        public IActionResult Error()
        {
            if (farmer.Image == null)
                farmer.Image = "null_image.png";

            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            return View();
        }

    }
}
