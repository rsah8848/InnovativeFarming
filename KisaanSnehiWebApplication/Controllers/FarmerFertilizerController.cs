using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KisaanSnehiWebApplication.Models;
using KisaanSnehiWebApplication.HttpHelper;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace KisaanSnehiWebApplication.Controllers
{
    public class FarmerFertilizerController : Controller
    {
        KisanSnehiApi _kisanSnehiApi = new KisanSnehiApi();
        static List<FertilizerPurchaseModel> fertilizerCart = new List<FertilizerPurchaseModel>();
        static FertilizerModel purchasedFertilizer = new FertilizerModel();
        static RegistrationModel farmer = new RegistrationModel();
        static int farmerID = 0;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        #nullable enable
        public async Task<IActionResult> GetListOfFertilizers(string? searchName)
        {
            string emailId = HttpContext.Session.GetString("sessionEmail");

            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<string>("FarmerProfile/GetUser", emailId);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            farmer = registration;
            if (farmer.Image == null)
                farmer.Image = "null_image.png";
            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            farmerID = farmer.RegId;

            List<FertilizerModel> fertilizers = new List<FertilizerModel>();
            
            HttpResponseMessage responseMessage = await client.GetAsync("api/FarmerFertilizer/GetListOfFertilizers");
            if(responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                fertilizers = JsonConvert.DeserializeObject<List<FertilizerModel>>(result);
            }

            if (searchName != null)
            {
                fertilizers = fertilizers.Where(f => f.FertilizerName.ToLower().StartsWith(searchName.ToLower())).ToList();
            }

            return View(fertilizers);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPurchasedFertilizers()
        {
            string emailId = HttpContext.Session.GetString("sessionEmail");

            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<string>("FarmerProfile/GetUser", emailId);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            farmer = registration;
            if (farmer.Image == null)
                farmer.Image = "null_image.png";
            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            farmerID = farmer.RegId;

            List<FertilizerPurchaseModel> fertilizerPurchases = new List<FertilizerPurchaseModel>();
            
            HttpResponseMessage responseMessage = await client.GetAsync("api/FarmerFertilizer/GetAllPurchasedFertilizers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                fertilizerPurchases = JsonConvert.DeserializeObject<List<FertilizerPurchaseModel>>(result);
            }

            fertilizerPurchases = fertilizerPurchases.Where(f => f.FarmerId == farmerID).ToList();


            return View(fertilizerPurchases);
        }

        //public async Task<IActionResult> AddFertilizerToCart(int id)
        //{
        //    List<FertilizerModel> fertilizers = new List<FertilizerModel>();
        //    HttpClient client = _kisanSnehiApi.Initial();
        //    HttpResponseMessage responseMessage = await client.GetAsync("api/FarmerFertilizer/GetListOfFertilizers");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var result = responseMessage.Content.ReadAsStringAsync().Result;
        //        fertilizers = JsonConvert.DeserializeObject<List<FertilizerModel>>(result);
        //    }

        //    foreach(FertilizerModel fertilizer in fertilizers)
        //    {
        //        if(fertilizer.FertilizerId == id)
        //        {
        //            fertilizerCart.Add(fertilizer);
        //        }
        //    }

        //    return RedirectToAction("GetListOfFertilizers", "FarmerFertilizer");
        //}

        public IActionResult RemoveFromCart(int id)
        {
            //List<FertilizerModel> fertilizers = new List<FertilizerModel>();
            //HttpClient client = _kisanSnehiApi.Initial();
            //HttpResponseMessage responseMessage = await client.GetAsync("api/FarmerFertilizer/GetListOfFertilizers");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var result = responseMessage.Content.ReadAsStringAsync().Result;
            //    fertilizers = JsonConvert.DeserializeObject<List<FertilizerModel>>(result);
            //}


            foreach (FertilizerPurchaseModel fertilizer in fertilizerCart)
            {
                if (fertilizer.FertilizerId == id)
                {
                    fertilizerCart.Remove(fertilizer);
                    break;
                }
            }

            return RedirectToAction("DisplayCartContents", "FarmerFertilizer");
        }

        [HttpGet]
        public async Task<IActionResult> DisplayCartContents()
        {
            string emailId = HttpContext.Session.GetString("sessionEmail");

            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<string>("FarmerProfile/GetUser", emailId);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            farmer = registration;
            if (farmer.Image == null)
                farmer.Image = "null_image.png";
            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            farmerID = farmer.RegId;

            return View(fertilizerCart);
        }
        
        public async Task<IActionResult> GetFertilizerBasedOnID(int id)
        {
            string emailId = HttpContext.Session.GetString("sessionEmail");

            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<string>("FarmerProfile/GetUser", emailId);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            farmer = registration;
            if (farmer.Image == null)
                farmer.Image = "null_image.png";
            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            farmerID = farmer.RegId;

            List<FertilizerModel> fertilizers = new List<FertilizerModel>();
            
            HttpResponseMessage responseMessage = await client.GetAsync("api/FarmerFertilizer/GetListOfFertilizers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                fertilizers = JsonConvert.DeserializeObject<List<FertilizerModel>>(result);
            }

            foreach (FertilizerModel fertilizer in fertilizers)
            {
                if (fertilizer.FertilizerId == id)
                {
                    purchasedFertilizer = fertilizer;
                }
            }

            return RedirectToAction("AddFertilizerToCart", "FarmerFertilizer");
        }

        [HttpGet]
        public async Task<IActionResult> AddFertilizerToCart()
        {
            string emailId = HttpContext.Session.GetString("sessionEmail");

            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<string>("FarmerProfile/GetUser", emailId);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            farmer = registration;
            if (farmer.Image == null)
                farmer.Image = "null_image.png";
            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            farmerID = farmer.RegId;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddFertilizerToCart(FertilizerPurchaseModel fertilizerPurchase)
        {
            string emailId = HttpContext.Session.GetString("sessionEmail");

            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<string>("FarmerProfile/GetUser", emailId);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            farmer = registration;
            if (farmer.Image == null)
                farmer.Image = "null_image.png";
            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            farmerID = farmer.RegId;
            fertilizerPurchase.FertilizerId = purchasedFertilizer.FertilizerId;
            fertilizerPurchase.TraderId = purchasedFertilizer.TraderId;
            fertilizerPurchase.FertilizerBillAmount = fertilizerPurchase.FertilizerPurchaseQuantity * purchasedFertilizer.FertilizerPrice;
            fertilizerPurchase.FertilizerPurchaseDate = System.DateTime.Now.Date;
            fertilizerPurchase.FarmerId = farmerID;

            if (fertilizerPurchase.FertilizerPurchaseQuantity == 0)
            {
                ViewBag.ErrorMessage = "Inavlid details entered.";
                return View();
            }

            if (fertilizerCart.Count != 0)
            {
                foreach (FertilizerPurchaseModel fertilizer in fertilizerCart)
                {
                    if (fertilizer.FertilizerId == fertilizerPurchase.FertilizerId)
                    {
                        ModelState.AddModelError("", "Fertilizer already present in cart");
                        return View(new FertilizerPurchaseModel());
                    }
                    else
                    {
                        fertilizerCart.Add(fertilizerPurchase);
                        return RedirectToAction("GetListOfFertilizers", "FarmerFertilizer");
                    }
                }
            }
            else
            {
                fertilizerCart.Add(fertilizerPurchase);
                return RedirectToAction("GetListOfFertilizers", "FarmerFertilizer");
            }
            return RedirectToAction("GetListOfFertilizers", "FarmerFertilizer");
        }


        //[HttpGet]
        //public IActionResult AddFertilizerPurchase()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public IActionResult AddFertilizerPurchase(bool done)
        //{
           

        //    ModelState.AddModelError("", "Server Error...Could not complete purchase");
        //    return RedirectToAction("DisplayCartContents","FarmerFertilizer");
        //}

        [HttpGet]
        public async Task< IActionResult> GenerateBill()
        {
            string emailId = HttpContext.Session.GetString("sessionEmail");

            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<string>("FarmerProfile/GetUser", emailId);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            farmer = registration;
            if (farmer.Image == null)
                farmer.Image = "null_image.png";
            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            farmerID = farmer.RegId;

            
            HttpResponseMessage postTask1 = new HttpResponseMessage();

            foreach (FertilizerPurchaseModel fertilizer in fertilizerCart)
            {
                fertilizer.FarmerId = farmerID;
                postTask1 = client.PostAsJsonAsync<FertilizerPurchaseModel>("api/FarmerFertilizer/AddFertilizerPurchase", fertilizer).Result;

            }

            if (!postTask1.IsSuccessStatusCode)
            {               
                ModelState.AddModelError("", "Server Error...Could not complete request");
                return View(new ReceiptModel());
            }
            /*else
            {
                ModelState.AddModelError("", "Server Error...Could not complete request");
                return View("DisplayCartContents","FarmerFertilizer");
            }*/

            ReceiptModel receipt = new ReceiptModel();
            double totalBill = 0;
            int count = 0;

            foreach(FertilizerPurchaseModel fertilizer in fertilizerCart)
            {
                totalBill = totalBill + (double)fertilizer.FertilizerBillAmount;
                count++;
            }

            receipt.FarmerID = farmerID;
            receipt.NumberOfItems = count;
            receipt.TotalBill = totalBill;
            receipt.ReciptDate = System.DateTime.Now.Date;

            return View(receipt);
        }



        [HttpGet]
        public async Task<IActionResult> FertilizerDetails(int id)
        {
            string emailId = HttpContext.Session.GetString("sessionEmail");

            RegistrationModel registration = new RegistrationModel();

            HttpClient client = _kisanSnehiApi.Initial();
            var postTask = client.PostAsJsonAsync<string>("FarmerProfile/GetUser", emailId);
            postTask.Wait();
            string apiResponse = await postTask.Result.Content.ReadAsStringAsync();
            registration = JsonConvert.DeserializeObject<RegistrationModel>(apiResponse);

            farmer = registration;
            if (farmer.Image == null)
                farmer.Image = "null_image.png";
            ViewBag.Name = farmer.Name;
            ViewBag.ProfilePicture = farmer.Image;
            farmerID = farmer.RegId;

            //HttpContext.Session.SetInt32(SessionCropId,id);
            /*
                        if (farmer.Image == null)
                            farmer.Image = "null_image.png";

                        ViewBag.Name = farmer.Name;
                        ViewBag.ProfilePicture = farmer.Image;
            */
            List<FertilizerModel> fertilizers = new List<FertilizerModel>();
            //FertilizerModel fertilizerModel = new FertilizerModel();

            
            HttpResponseMessage responseMessage = await client.GetAsync("api/FarmerFertilizer/GetListOfFertilizers");

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                fertilizers = JsonConvert.DeserializeObject<List<FertilizerModel>>(result);
            }

            FertilizerModel fertilizer = fertilizers.FirstOrDefault(c => c.FertilizerId == id);


            return View(fertilizer);
        }
    }
}