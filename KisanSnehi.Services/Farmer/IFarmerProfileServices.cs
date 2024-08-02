using KisanSnehi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Services.Farmer
{
    public interface IFarmerProfileServices
    {

        public Task<bool> UpdateFarmerProfile(Registration farmer);

        public Task<bool> UpdateFarmerPassword(Registration farmer);

        public Task<bool> AddFarmerFeedback(Feedback feedback);
        public Task<bool> AddCrop(Crop crop);

        public Task<List<Crop>> GetCropsByName(string cropName, int farmerId);

        public Task<List<Crop>> GetCropsByPrice(int MinPrice, int MaxPrice, int farmerId);

        public Task<List<Crop>> GetAllCrops(int farmerId);

        public Task<bool> UpdateCropDetails(Crop crop);

        public Task<bool> UpdateCropImage(Crop crop);

        public Task<bool> UpdateFarmerProfileImage(Registration farmer);

        public Task<bool> DeleteCrop(int cropId);

        public Task<Registration> GetUser(string email);

        public Task<bool> RemoveFarmerProfileImage(Registration user);
        public Task<List<CropPurchase>> GetPurchasedCrops(int farmerId);

        public Task<bool> AddFeedback(Feedback feedback);
    }
}
