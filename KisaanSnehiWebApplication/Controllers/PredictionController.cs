using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KisaanSnehiWebApplication.Controllers
{
    [Authorize(Roles = "Farmer")]
    public class PredictionController : Controller
    {
        static readonly HttpClient client = new HttpClient();

        public IActionResult Crop(string message = null)
        {
            ViewBag.Message = message;

            return View();
        }

        public IActionResult Plant(string message = null)
        {
            ViewBag.Message = message;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CropPrediction(CropPlannerDto planner)
        {
            var values = new Dictionary<string, string>
            {
                { "N", planner.N.ToString() }, // Example values
                { "P", planner.P.ToString() },
                { "K", planner.K.ToString() },
                { "temperature", planner.Temperature.ToString() },
                { "humidity", planner.Humidity.ToString() },
                { "ph", planner.Ph.ToString() },
                { "rainfall", planner.Rainfall.ToString() }
            };

            var content = new FormUrlEncodedContent(values);

            HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:8000/cropPlanner/predict", content);

            response.EnsureSuccessStatusCode();

            var message = "";
            // Read the response body as a string
            string responseString = await response.Content.ReadAsStringAsync();

            // Parse the JSON response
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jsonResponse = JsonSerializer.Deserialize<Dictionary<string, string>>(responseString, options);

            // Access the prediction value
            if (jsonResponse != null && jsonResponse.ContainsKey("prediction"))
            {
                message = jsonResponse["prediction"];
            }

            ViewBag.Message = message;
            return RedirectToAction("Crop", new { message = message });
        }

        [HttpPost]
        public async Task<IActionResult> PlantPrediction(IFormFile myfile)
        {
            if (myfile == null || myfile.Length == 0)
            {
                ViewBag.Message = "No file selected";
                return View("Index");
            }

            using var httpClient = new HttpClient();
            using var formData = new MultipartFormDataContent();
            using var fileStream = myfile.OpenReadStream();
            using var streamContent = new StreamContent(fileStream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(myfile.ContentType);

            formData.Add(streamContent, "file", myfile.FileName);

            string apiEndpoint = "http://127.0.0.1:8000/imgPrediction";
            HttpResponseMessage response = await httpClient.PostAsync(apiEndpoint, formData);

            var predictionResult = new ApiResponse();

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                predictionResult = JsonSerializer.Deserialize<ApiResponse>(result, options);
                ViewBag.PredictedLabel = predictionResult.PredictedLabel;
                ViewBag.Confidence = predictionResult.Confidence;
                ViewBag.Message = "Upload successful.";
            }
            else
            {
                ViewBag.Message = "Upload failed. Server response: " + response.StatusCode;
            }

            return RedirectToAction("Plant", new { message = $"The image was uploaded and it was found that the tomato has a label of {predictionResult.PredictedLabel} and {predictionResult.Confidence} % confidence." });
        }
    }

    public class CropPlannerDto
    {
        public int N { get; set; }

        public int P { get; set; }

        public int K { get; set; }

        public int Temperature { get; set; }

        public int Humidity { get; set; }

        public int Ph { get; set; }

        public int Rainfall { get; set; }
    }
    public class ApiResponse
    {
        public string PredictedLabel { get; set; }
        public double Confidence { get; set; }
    }
}