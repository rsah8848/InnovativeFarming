using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KisaanSnehiWebApplication.HttpHelper;
using KisaanSnehiWebApplication.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace KisaanSnehiWebApplication.Controllers
{
    public class FarmerGuidanceController : Controller
    {
        static List<GuidanceModel> guidances = new List<GuidanceModel>();
        KisanSnehiApi _kisanSnehiApi = new KisanSnehiApi();
        static RegistrationModel farmer = new RegistrationModel();
        static int farmerID = 0;
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetGuidance()
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
        public async Task<IActionResult> GetGuidance(GuidanceModel guidance)
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
           
            HttpResponseMessage responseMessage;


            responseMessage = client.PostAsJsonAsync<GuidanceModel>("api/FarmerGuidance/GetGuidance", guidance).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                guidances = JsonConvert.DeserializeObject<List<GuidanceModel>>(result);

                return RedirectToAction("DisplayCropNames");
            }
            ModelState.AddModelError("", "Server Error!");
            return View(new GuidanceModel());
        }

        [HttpGet]
        public async Task<IActionResult> DisplayCropNames()
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
            return View(guidances);
        }
    }
}