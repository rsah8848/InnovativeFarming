using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KisanSnehi.Entities;
using Microsoft.EntityFrameworkCore;
using KisanSnehi.CustomExceptions;
using System.Linq;

namespace KisanSnehi.Repositories.Farmer
{
    public class FarmerProfileRepository :IFarmerProfileRepository
    {
        private KisanSnehiDBContext _Context;

        DateTime today = DateTime.Today;
        public FarmerProfileRepository(KisanSnehiDBContext kisanSnehiDBContext) 
        {
            _Context = kisanSnehiDBContext;
        }
        /// <summary>
        /// edit farmer details
        /// </summary>
        /// <param name="farmer"></param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> UpdateFarmerProfile(Registration farmer)
        {

            try
            {
                Registration registeration = await _Context.Registrations.FirstOrDefaultAsync(s => s.RegId == farmer.RegId);

                int rows = 0;
                if(farmer.Name!=null || !farmer.Name.Equals(registeration.Name))
                    registeration.Name = farmer.Name;
                if (farmer.Address != null || !farmer.Address.Equals(registeration.Address))
                    registeration.Address = farmer.Address;
                if (farmer.PhoneNo!=0 || !farmer.Address.Equals(registeration.Address))
                    registeration.PhoneNo = farmer.PhoneNo;
                if (farmer.LocationId!=0)
                    registeration.LocationId=farmer.LocationId;
                
                  registeration.UpdatedDate = today;
                rows = await _Context.SaveChangesAsync();
                
                if (rows == 0)
                    return false;
                else 
                    return true;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        /// <summary>
        /// retrieve user from mail id
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Registration details</returns>
        public async Task<Registration> GetUser(string email)
        {
            try
            {
                Registration user = await _Context.Registrations.FirstOrDefaultAsync(r => r.EmailId == email);
                if (user == null)
                {
                    throw new RecordNotFoundException("user does not exists");
                }
                else
                {
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new SqlException("Server error occured! ", ex);

            }

        }

        /// <summary>
        /// updating user password
        /// </summary>
        /// <param name="farmer">type=Registration</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> UpdateFarmerPassword(Registration farmer) 
        {

            try
            {
                Registration registeration = await _Context.Registrations.FirstOrDefaultAsync(s => s.RegId == farmer.RegId);

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(farmer.Password);

                int rows = 0;
                if (farmer.SecurityQue.Equals(registeration.SecurityQue) && farmer.Answer.Equals(registeration.Answer))
                {
                    registeration.Password = passwordHash;
                    registeration.UpdatedDate = today;
                }
                rows = await _Context.SaveChangesAsync();
                if (rows == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        /// <summary>
        /// add feedback
        /// </summary>
        /// <param name="feedback">type=feedback</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> AddFarmerFeedback(Feedback feedback)
        {
            try
            {
                int rows = 0;

                feedback.RegDate = today;
                feedback.IsDeleted = false;
                _Context.Add(feedback);
                rows = await _Context.SaveChangesAsync();
                if (rows == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        /// <summary>
        /// add crop details
        /// </summary>
        /// <param name="crop">type=Crop</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> AddCrop(Crop crop)
        {
            try
            {
                int rows = 0;
                crop.CropQuantityInStock = crop.CropQuantity;
                crop.CreatedDate = today;
                crop.UpdatedDate = today;
                crop.IsDeleted = false;
                _Context.Add(crop);
                rows = await _Context.SaveChangesAsync();
                if (rows == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        /// <summary>
        /// get crops list by name
        /// </summary>
        /// <param name="cropName">type=string</param>
        /// <param name="farmerId">type=int</param>
        /// <returns>type=List<Crop></returns>
        public async Task<List<Crop>> GetCropsByName(string cropName, int farmerId)
        {
            try
            {
               
                List<Crop> crops = await _Context.Crops.Where(c => c.CropName.Equals(cropName) && c.FarmerId==farmerId && c.IsDeleted == false).ToListAsync();
                if (crops == null)
                {
                    throw new RecordNotFoundException("No record found...");
                }
                return crops;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }

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
            try
            {

                List<Crop> crops = await _Context.Crops.Where(c => c.CropPrice>=MinPrice && c.CropPrice<=MaxPrice && c.FarmerId == farmerId
                 && c.IsDeleted==false).ToListAsync();
                if (crops == null)
                {
                    throw new RecordNotFoundException("No record found...");
                }
                return crops;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        /// <summary>
        /// get all crops lists by user id
        /// </summary>
        /// <param name="farmerId"></param>
        /// <returns>type=List<Crop></returns>
        public async Task<List<Crop>> GetAllCrops(int farmerId)
        {
            try
            {

                List<Crop> crops = await _Context.Crops.Where(c => c.FarmerId == farmerId).ToListAsync();
                if (crops == null)
                {
                    throw new RecordNotFoundException("No record found...");
                }
                return crops;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        /// <summary>
        /// edit crop details
        /// </summary>
        /// <param name="crop">type=Crop</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> UpdateCropDetails(Crop crop)
        {
            try
            {
                
                Crop originalCrop = await _Context.Crops.FirstOrDefaultAsync(s => s.CropId == crop.CropId);
                if (crop == null)
                {
                    throw new RecordNotFoundException("Record does not exists....");
                }
                int rows = 0;
                if (crop.CropName != null || !crop.CropName.Equals(originalCrop.CropName))
                    originalCrop.CropName = crop.CropName;
                if (crop.CropDesc != null || !crop.CropDesc.Equals(originalCrop.CropDesc))
                    originalCrop.CropDesc = crop.CropDesc;
                if (crop.CropQuantity != originalCrop.CropQuantity)
                {
                    originalCrop.CropQuantity = crop.CropQuantity;
                    originalCrop.CropQuantityInStock = crop.CropQuantityInStock;
                }
                if (crop.CropPrice != originalCrop.CropPrice && crop.CropPrice != 0)
                    originalCrop.CropPrice = crop.CropPrice;

                originalCrop.UpdatedDate = today;
                rows = await _Context.SaveChangesAsync();

                if (rows == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        /// <summary>
        /// delete crop details sets value IsDeleted=false
        /// </summary>
        /// <param name="cropId">type=int</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> DeleteCrop(int cropId)
        {
            try
            {
                int rows = 0;
                Crop crop = await _Context.Crops.FirstOrDefaultAsync(s => s.CropId == cropId);
                if (crop == null)
                {
                    throw new RecordNotFoundException("Record does not exists....");
                }
                crop.IsDeleted = true;
                rows = await _Context.SaveChangesAsync();
                if (rows == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }



        public Task<bool> UpdateCropImage(Crop crop)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Update user image 
        /// </summary>
        /// <param name="farmer">type=Registration</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> UpdateFarmerProfileImage(Registration farmer)
        {
            try
            {
                GeneralMethods general = new GeneralMethods(_Context);
                return await general.UpdateUserProfileImage(farmer);
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        /// <summary>
        /// delete user image
        /// </summary>
        /// <param name="user">type=Registration</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> RemoveFarmerProfileImage(Registration user)
        {
            try
            {
                GeneralMethods general = new GeneralMethods(_Context);
                return await general.RemoveUserProfileImage(user);
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        /// <summary>
        /// get purchased crops by user id
        /// </summary>
        /// <param name="farmerId">type=int</param>
        /// <returns>type=List<CropPurchase></returns>
        public async Task<List<CropPurchase>> GetPurchasedCrops(int farmerId) 
        {
            try
            {

                List<CropPurchase> crops = await _Context.CropPurchases.Where(c => c.FarmerId == farmerId).ToListAsync();
                if (crops == null)
                {
                    throw new RecordNotFoundException("No record found...");
                }
                return crops;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        /// <summary>
        /// add feedback
        /// </summary>
        /// <param name="feedback">type=Feedback</param>
        /// <returns>type=bool(True/False)</returns>
        public async Task<bool> AddFeedback(Feedback feedback)
        {
            try
            {
                GeneralMethods general = new GeneralMethods(_Context);
                return await general.AddFeedback(feedback);
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

    }
}
