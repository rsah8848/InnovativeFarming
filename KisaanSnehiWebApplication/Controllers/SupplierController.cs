using KisaanSnehiWebApplication.HttpHelper;
using KisaanSnehiWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;

namespace KisaanSnehiWebApplication.Controllers
{
    [Authorize(Roles = "Supplier")]
    public class SupplierController : Controller
    {
        HttpClientHandler clientHandler = new HttpClientHandler();

        KisanSnehiApi _api = new KisanSnehiApi();

        const string SessionCropId = "";

        static RegistrationModel supplier = new RegistrationModel();

        static List<CropPurchaseModel> cropPurchaseCart = new List<CropPurchaseModel>();
        static CropModel purchasedCrop = new CropModel();

        private IWebHostEnvironment _HostEnvironment { get; }

        public SupplierController(IWebHostEnvironment webHostEnvironment)
        {
            _HostEnvironment = webHostEnvironment;


        }
        public IActionResult Index()
        {
            return RedirectToAction("SupplierHome");
        }

        public async Task<IActionResult> SupplierHome()
        {
            string emailId = HttpContext.Session.GetString("sessionEmail");
            if (emailId == null && supplier.EmailId != null)
                emailId = supplier.EmailId;

            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<string>("api/Supplier/GetSupplier", emailId);
            postTask.Wait();
            string response = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(response);

            supplier = registration;
            if (supplier.Image == null)
                supplier.Image = "null_image.png";

            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;
            return View(supplier);

        }

        public async Task<IActionResult> SupplierProfile()
        {
            RegistrationModel registration = new RegistrationModel();
            string emailId = HttpContext.Session.GetString("sessionEmail");
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<string>("api/Supplier/GetSupplier", emailId);
            postTask.Wait();
            string response = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(response);

            supplier = registration;
            if (supplier.Image == null)
                supplier.Image = "null_image.png";
            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;
            return View(supplier);
        }

        [HttpGet]
        public async Task<IActionResult> EditSupplierProfile()
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
            if (supplier.Image == null)
                supplier.Image = "null_image.png";

            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;
            ViewBag.ContactNumber = supplier.PhoneNo;

            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> EditSupplierProfile(int id, RegistrationModel supplierModel)
        {  
            try
            {
                if (supplier.Image == null)
                    supplier.Image = "null_image.png";
                ViewBag.Name = supplier.Name;
                ViewBag.ProfilePicture = supplier.Image;


                Regex regex = new Regex(@"^\(?([0-9]{10})\)?$");
                Match match = regex.Match(supplierModel.PhoneNo.ToString());
                if (match.Success)
                {
                    supplierModel.RegId = supplier.RegId;
                    supplierModel.EmailId = supplier.EmailId;
                    HttpClient client = _api.Initial();
                    var postTask = client.PostAsJsonAsync<RegistrationModel>("api/Supplier/EditSupplierProfile", supplierModel);
                    postTask.Wait();
                    string response = await postTask.Result.Content.ReadAsStringAsync();
                    bool value = JsonConvert.DeserializeObject<bool>(response);
                    if (value == true)
                    {
                        return RedirectToAction("SupplierProfile");
                    }
                    else
                        return RedirectToAction("EditSupplierProfile");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid phone number";
                    throw new Exception("Invalid phone number");
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
            if (supplier.Image == null)
                supplier.Image = "null_image.png";
            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;
            return View();
        }

        [HttpGet]
        public ActionResult UploadSupplierProfilePicture(RegistrationModel supplierModel)
        {
            if (supplier.Image == null)
                supplier.Image = "null_image.png";

            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadSupplierProfilePicture(int id, RegistrationModel supplierModel)
        {
            if (supplierModel.ImageFile == null)
                return View();

            string wwwRootPath = _HostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(supplierModel.ImageFile.FileName);
            string fileExtension = Path.GetExtension(supplierModel.ImageFile.FileName);
            supplierModel.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;
            string filePath = Path.Combine(wwwRootPath + "/ImagesDB/", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await supplierModel.ImageFile.CopyToAsync(fileStream);
            }

            supplierModel.RegId = supplier.RegId;
            supplierModel.EmailId = supplier.EmailId;
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<RegistrationModel>("api/Supplier/UpdateSupplierProfileImage", supplierModel);
            postTask.Wait();
            string response = await postTask.Result.Content.ReadAsStringAsync();
            bool value = JsonConvert.DeserializeObject<bool>(response);
            if (value == true)
            {
                return RedirectToAction("SupplierProfile");
            }

            return View();
        }

        [HttpGet]
        public IActionResult RemoveSupplierProfilePicture()
        {
            if (supplier.Image == null)
                supplier.Image = "null_image.png";

            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveSupplierProfilePicture(RegistrationModel model)
        {
            model = supplier;
            if (model.Image == null)
                return RedirectToAction("SupplierProfile");


            var imagePath = Path.Combine(_HostEnvironment.WebRootPath, "ImagesDB", model.Image);

            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<RegistrationModel>("api/Supplier/RemoveSupplierProfileImage", model);
            postTask.Wait();
            string response = await postTask.Result.Content.ReadAsStringAsync();
            bool value = JsonConvert.DeserializeObject<bool>(response);
            if (value == true)
            {
                return RedirectToAction("SupplierProfile");
            }


            return RedirectToAction("SupplierProfile");
        }

        [HttpGet]
        public async Task<IActionResult> DeactivateAccount(int id)
        {
            try
            {
                if (supplier.Image == null)
                    supplier.Image = "null_image.png";

                ViewBag.Name = supplier.Name;
                ViewBag.ProfilePicture = supplier.Image;
                RegistrationModel registration = new RegistrationModel();

                using (var httpClient = new HttpClient(clientHandler))
                {
                    using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/GetUsersById/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);
                    }
                    StringContent content = new StringContent(JsonConvert.SerializeObject(registration), Encoding.UTF8, "application/json");
                    using (var response1 = await httpClient.PostAsync("http://localhost:61806/api/Supplier/DeactivateSupplierProfile", content))
                    {
                        string apiResponse1 = await response1.Content.ReadAsStringAsync();
                        bool value = JsonConvert.DeserializeObject<bool>(apiResponse1);
                        if (value == false)
                        {
                            ViewBag.ErrorMessage = "User cannot be deactivated";
                        }
                    }
                }
                if (registration.EmailId == HttpContext.Session.GetString("sessionEmail"))
                    return RedirectToAction("LoginOrSignUp", "Home");
                else
                    return RedirectToAction("SupplierProfile", "Supplier");

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult ChangeSupplierPassword()
        {
            ViewData["email"] = HttpContext.Session.GetString("sessionEmail");
            if (supplier.Image == null)
                supplier.Image = "null_image.png";

            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangeSupplierPassword(RegistrationModel supplierModel)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,12}$");
                Match match = regex.Match(supplierModel.Password);
                if (match.Success)
                {
                    supplierModel.EmailId = HttpContext.Session.GetString("sessionEmail");
                    if (supplierModel.Password != supplierModel.ConfirmPassword)
                    {
                        ViewBag.ErrorMessage = "password and confirm password does not match";
                        throw new Exception("password and confirm password does not match");
                    }

                    using (var httpClient = new HttpClient(clientHandler))
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(supplierModel), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PostAsync("http://localhost:61806/api/Supplier/ChangeSupplierPassword", content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
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
        public async Task<IActionResult> GetListOfAllAvailableCrops()
        {
            List<CropModel> crops = new List<CropModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage responseMessage = await client.GetAsync("api/Supplier/GetListOfAllAvailableCrops");
            if (responseMessage.IsSuccessStatusCode)
            {
                var res = responseMessage.Content.ReadAsStringAsync().Result;
                crops = JsonConvert.DeserializeObject<List<CropModel>>(res);
            }
            foreach (var c in crops)
            {
                if (c.Image == null)
                    c.Image = "empty_cropImage.jpg";
            }
            return View(crops);
        }



        [HttpGet]
        #nullable enable
        public async Task<IActionResult> GetListOfCropsByName(string? cropName, int? page)
        {

            if (supplier.Image == null)
                supplier.Image = "null_image.png";
            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;

            List<CropModel> crops = new List<CropModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage responseMessage = await client.GetAsync("api/Supplier/GetListOfAllAvailableCrops");
            if (responseMessage.IsSuccessStatusCode)
            {
                var res = responseMessage.Content.ReadAsStringAsync().Result;
                crops = JsonConvert.DeserializeObject<List<CropModel>>(res);
            }
            if (cropName != null)
                crops = crops.Where(c => c.CropName.ToLower().StartsWith(cropName.ToLower())).ToList();
            return View(crops.ToPagedList(page ?? 1,5));
        }

        /*[HttpGet]
        public async Task<IActionResult> GetCropPurchaseHistory()
        {
            if (supplier.Image == null)
                supplier.Image = "null_image.png";

            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;
            List<CropPurchaseModel> cropPurchases = new List<CropPurchaseModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage responseMessage = await client.GetAsync("api/Supplier/GetCropPurchaseHistory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                cropPurchases = JsonConvert.DeserializeObject<List<CropPurchaseModel>>(result);
            }

            return View(cropPurchases);
        }*/

        [HttpGet]
        public async Task<IActionResult> GetCropPurchaseHistory(int? page)
        {
            if (supplier.Image == null)
                supplier.Image = "null_image.png";

            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;

            List<CropPurchaseModel> cropPurchases = new List<CropPurchaseModel>();
            List<CropModel> crops = new List<CropModel>();

            HttpClient client = _api.Initial();
            HttpResponseMessage responseMessage = await client.GetAsync("api/Supplier/GetCropPurchaseHistory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                cropPurchases = JsonConvert.DeserializeObject<List<CropPurchaseModel>>(result);
            }

            HttpResponseMessage responseMessage2 = await client.GetAsync("api/Supplier/GetListOfAllAvailableCrops");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var res = responseMessage2.Content.ReadAsStringAsync().Result;
                crops = JsonConvert.DeserializeObject<List<CropModel>>(res);
            }

            List<RegistrationModel> registrationModels = new List<RegistrationModel>();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:61806/api/Admin/GetUsersByUserType/" + 1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    registrationModels = JsonConvert.DeserializeObject<List<RegistrationModel>>(apiResponse);
                    /*ViewData["actors"] = actorModels;*/
                }
            }

            foreach (CropPurchaseModel c in cropPurchases)
            {
                CropModel crop = crops.FirstOrDefault(p => p.CropId == c.CropId);
                c.CropName = crop.CropName;
                RegistrationModel farmer = registrationModels.FirstOrDefault(p => p.RegId == c.FarmerId);
                c.FarmerName = farmer.Name;
                c.PhoneNo = farmer.PhoneNo;
            }


            return View(cropPurchases.ToPagedList(page ?? 1, 5));
        }
        public IActionResult RemoveFromCart(int id)
        {

            foreach (CropPurchaseModel cropPurchase in cropPurchaseCart)
            {
                if (cropPurchase.CropId == id)
                {
                    cropPurchaseCart.Remove(cropPurchase);
                    break;
                }
            }

            return RedirectToAction("DisplayCartContents", "Supplier");
        }

        [HttpGet]
        public IActionResult DisplayCartContents()
        {
            if (supplier.Image == null)
                supplier.Image = "null_image.png";

            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;
            return View(cropPurchaseCart);
        }

        public async Task<IActionResult> GetCropsBasedOnID(int id)
        {
            List<CropModel> crops = new List<CropModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage responseMessage = await client.GetAsync("api/Supplier/GetListOfAllAvailableCrops");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                crops = JsonConvert.DeserializeObject<List<CropModel>>(result);
            }

            foreach (CropModel crop in crops)
            {
                if (crop.CropId == id)
                {
                    purchasedCrop = crop;
                }
            }

            return RedirectToAction("AddCropToCart", "Supplier");
        }

        [HttpGet]
        public IActionResult AddCropToCart()
        {
            if (supplier.Image == null)
                supplier.Image = "null_image.png";

            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;
            return View();
        }


        [HttpPost]
        public IActionResult AddCropToCart(CropPurchaseModel cropPurchase)
        {
            cropPurchase.CropId = purchasedCrop.CropId;
            cropPurchase.FarmerId = purchasedCrop.FarmerId;
            cropPurchase.CropBillAmount = cropPurchase.CropPurchaseQuantity * purchasedCrop.CropPrice;
            cropPurchase.CropPurchaseQuantity = cropPurchase.CropPurchaseQuantity;
            cropPurchase.CropPurchaseDate = System.DateTime.Now.Date;

            if (cropPurchaseCart.Count != 0)
            {
                foreach (CropPurchaseModel crop in cropPurchaseCart)
                {
                    if (crop.CropId == cropPurchase.CropId)
                    {
                        ModelState.AddModelError("", "The crop is already present in the cart");
                        return View(new CropPurchaseModel());
                    }
                    else
                    {
                        cropPurchaseCart.Add(cropPurchase);
                        return RedirectToAction("GetListOfCropsByName", "Supplier");
                    }
                }
            }
            else
            {
                cropPurchaseCart.Add(cropPurchase);
                return RedirectToAction("GetListOfCropsByName", "Supplier");
            }
            return RedirectToAction("GetListOfCropsByName", "Supplier");
        }



        [HttpGet]
        public IActionResult GenerateBill()
        {
            
            HttpClient client = _api.Initial();
            HttpResponseMessage postTask = new HttpResponseMessage();

            if (supplier.Image == null)
                supplier.Image = "null_image.png";

            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;

            foreach (CropPurchaseModel cropPurchase in cropPurchaseCart)
            {
                cropPurchase.SupplierId = supplier.RegId;

                postTask = client.PostAsJsonAsync<CropPurchaseModel>("api/Supplier/AddCropPurchase", cropPurchase).Result;

            }

            if (!postTask.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Sorry!! Server error occured. Could not complete request.");
                return View(new SupplierReceiptModel());
            }

            SupplierReceiptModel receipt = new SupplierReceiptModel();
            double totalBill = 0;
            int count = 0;

            foreach (CropPurchaseModel crop in cropPurchaseCart)
            {
                totalBill = totalBill + (double)crop.CropBillAmount;
                count++;
            }

            receipt.SupplierID = supplier.RegId;
            receipt.NumberOfItems = count;
            receipt.TotalBill = totalBill;
            receipt.ReciptDate = System.DateTime.Now.Date;

            cropPurchaseCart.Clear();

            return View(receipt);
        }

        [HttpGet]
        public IActionResult AddSupplierFeedback()
        {
            if (supplier.Image == null)
                supplier.Image = "null_image.png";

            ViewBag.Name = supplier.Name;
            ViewBag.ProfilePicture = supplier.Image;
            FeedbackModel feedback = new FeedbackModel();
            return View(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplierFeedback(FeedbackModel feedback)
        {

            feedback.RegId = supplier.RegId;
            bool value = false;
            using (var httpClient = new HttpClient(clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(feedback), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:61806/api/Supplier/AddSupplierFeedback", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    value = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }
            if (value == true)
                ViewBag.Message = "Feedback submitted successfully";
            return RedirectToAction("SupplierProfile");

        }
    }
}
