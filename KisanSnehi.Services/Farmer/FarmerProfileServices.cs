using KisanSnehi.Entities;
using KisanSnehi.Repositories.Farmer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace KisanSnehi.Services.Farmer
{
    public class FarmerProfileServices : IFarmerProfileServices
    {

        IFarmerProfileRepository _Repository;

        /// <summary>
        /// dependency injection
        /// </summary>
        /// <param name="farmerProfileRepository"></param>
        public FarmerProfileServices(IFarmerProfileRepository farmerProfileRepository)
        {
            _Repository = farmerProfileRepository;
        }

        /// <summary>
        /// add crop details
        /// </summary>
        /// <param name="crop">type Crop</param>
        /// <returns>type=bool (true/ false)</returns>
        public async Task<bool> AddCrop(Crop crop)
        {
            return await _Repository.AddCrop(crop);
        }

        /// <summary>
        /// get purchased crop list by user id
        /// </summary>
        /// <param name="farmerId">type=int</param>
        /// <returns>type=List<CropPurchase></returns>
        public async Task<List<CropPurchase>> GetPurchasedCrops(int farmerId)
        {
            return await _Repository.GetPurchasedCrops(farmerId);
        }

        /// <summary>
        /// add feedback
        /// </summary>
        /// <param name="feedback">type Feedback</param>
        /// <returns>type=bool (true/ false)</returns>
        public async Task<bool> AddFarmerFeedback(Feedback feedback)
        {
            return await _Repository.AddFarmerFeedback(feedback);
        }
        /// <summary>
        /// updating user password
        /// </summary>
        /// <param name="farmer">type=Registration</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> UpdateFarmerPassword(Registration farmer)
        {
            return await _Repository.UpdateFarmerPassword(farmer);
        }

        /// <summary>
        /// edit farmer details
        /// </summary>
        /// <param name="farmer"></param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> UpdateFarmerProfile(Registration farmer)
        {
            return await _Repository.UpdateFarmerProfile(farmer);
        }


        /// <summary>
        /// get crops list by name
        /// </summary>
        /// <param name="cropName">type=string</param>
        /// <param name="farmerId">type=int</param>
        /// <returns>type=List<Crop></returns>
        public async Task<List<Crop>> GetCropsByName(string cropName, int farmerId)
        {
            return await _Repository.GetCropsByName(cropName, farmerId);
        }

        /// <summary>
        /// get crops list by price & id
        /// </summary>
        /// <param name="MinPrice"></param>
        /// <param name="MaxPrice"></param>
        /// <param name="farmerId"></param>
        /// <returns>type=List<Crop></returns>
        public async Task<List<Crop>> GetCropsByPrice(int MinPrice, int MaxPrice, int farmerId)
        {
            return await _Repository.GetCropsByPrice(MinPrice, MaxPrice, farmerId);
        }

        /// <summary>
        /// get all crops lists by user id
        /// </summary>
        /// <param name="farmerId"></param>
        /// <returns>type=List<Crop></returns>
        public async Task<List<Crop>> GetAllCrops(int farmerId)
        {
            return await _Repository.GetAllCrops(farmerId);
        }

        /// <summary>
        /// edit crop details
        /// </summary>
        /// <param name="crop">type=Crop</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> UpdateCropDetails(Crop crop)
        {
            return await _Repository.UpdateCropDetails(crop);
        }

        public async Task<bool> UpdateCropImage(Crop crop)
        {
            return await _Repository.UpdateCropImage(crop);
        }

        /// <summary>
        /// Update user image 
        /// </summary>
        /// <param name="farmer">type=Registration</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> UpdateFarmerProfileImage(Registration farmer)
        {
            return await _Repository.UpdateFarmerProfileImage(farmer);
        }

        /// <summary>
        /// delete crop details sets value IsDeleted=false
        /// </summary>
        /// <param name="cropId">type=int</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> DeleteCrop(int cropId)
        {
            return await _Repository.DeleteCrop(cropId);
        }

        public async Task<Registration> GetUser(string email)
        {
            return await _Repository.GetUser(email);
        }

        /// <summary>
        /// add feedback
        /// </summary>
        /// <param name="feedback">type=Feedback</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> RemoveFarmerProfileImage(Registration user)
        {
            return await _Repository.RemoveFarmerProfileImage(user);
        }

        /// <summary>
        /// add feedback
        /// </summary>
        /// <param name="feedback">type Feedback</param>
        /// <returns>type=bool (true/ false)</returns>
        public async Task<bool> AddFeedback(Feedback feedback)
        {
            return await _Repository.AddFeedback(feedback);
        }
    }
}
