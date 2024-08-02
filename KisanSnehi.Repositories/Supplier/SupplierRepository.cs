using System;
using System.Collections.Generic;
using System.Text;
using KisanSnehi.Entities;
using KisanSnehi.CustomExceptions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KisanSnehi.Repositories.Supplier
{
    public class SupplierRepository : ISupplierRepository
    {
        private KisanSnehiDBContext _Context;
        public SupplierRepository(KisanSnehiDBContext kisanSnehiDBContext)
        {
            _Context = kisanSnehiDBContext;
        }

        DateTime today = DateTime.Today;

        public async Task<Registration> GetSupplier(string emailId)
        {
            try
            {
                Registration supplier = await _Context.Registrations.FirstOrDefaultAsync
                    (s => s.EmailId.Equals(emailId));
                if (supplier == null)
                {
                    throw new RecordNotFoundException("Sorry!! You are not a registered user. Please register and login.");
                }
                else
                {
                    return supplier;
                }
            }
            catch (RecordNotFoundException ex)
            {
                throw new RecordNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new SqlException("Sorry!!Server error occured!", ex);
            }
        }

        public async Task<bool> EditSupplierProfile(Registration supplier)
        {
            GeneralMethods objGeneralMethods = new GeneralMethods(_Context);
            bool value = await objGeneralMethods.EditProfile(supplier);
            return value;
            
        }



        public async Task<bool> ChangeSupplierPassword(Registration supplier)
        {
            GeneralMethods objGeneralMethods = new GeneralMethods(_Context);
            bool value = await objGeneralMethods.ChangePassword(supplier);
            return value;
        }

        public async Task<bool> DeactivateSupplierProfile(Registration supplier)
        {
            GeneralMethods objGeneralMethods = new GeneralMethods(_Context);
            bool value = await objGeneralMethods.DeactivateProfile(supplier);
            return value;
        }

        public async Task<bool> UpdateSupplierProfileImage(Registration supplier)
        {
            GeneralMethods objGeneralMethods = new GeneralMethods(_Context);
            bool value = await objGeneralMethods.UpdateUserProfileImage(supplier);
            return value;
        }

        public async Task<bool> RemoveSupplierProfileImage(Registration supplier)
        {
            GeneralMethods objGeneralMethods = new GeneralMethods(_Context);
            return await objGeneralMethods.RemoveUserProfileImage(supplier);
        }

        public async Task<List<Crop>> GetListOfAllAvailableCrops()
        {
            List<Crop> crops = new List<Crop>();
            try
            {
                crops = await _Context.Crops.ToListAsync();
                if (crops == null)
                {
                    throw new RecordNotFoundException("Sorry!! No data available.");
                }
                return crops;
            }
            catch (RecordNotFoundException ex)
            {
                throw new RecordNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new SqlException("Sorry!!Server error occured!", ex);
            }
        }

        public async Task<List<Crop>> GetListOfCropsByName(string cropName)
        {
            List<Crop> allCrops = new List<Crop>();
            try
            {
                allCrops = await _Context.Crops.ToListAsync();
                List<Crop> cropsSelectedByName = (from crops in allCrops where crops.CropName.Equals(cropName)
                                                  select crops).ToList();
                if (cropsSelectedByName == null)
                {
                    throw new RecordNotFoundException("Sorry!! No data available.");
                }
                return cropsSelectedByName;
            }
            catch (RecordNotFoundException ex)
            {
                throw new RecordNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new SqlException("Sorry!!Server error occured!", ex);
            }
        }

        public async Task<List<Crop>> GetListOfCropsByPrice(float cropPriceLowerLimit, float cropPriceUpperLimit)
        {
            List<Crop> allCrops = new List<Crop>();
            try
            {
                allCrops = await _Context.Crops.ToListAsync();
                List<Crop> cropsSelectedByPrice = (from crops in allCrops
                                                  where crops.CropPrice>=cropPriceLowerLimit && crops.CropPrice<=cropPriceUpperLimit
                                                  select crops).ToList();
                if (cropsSelectedByPrice == null)
                {
                    throw new RecordNotFoundException("Sorry!! No data available.");
                }
                return cropsSelectedByPrice;
            }
            catch (RecordNotFoundException ex)
            {
                throw new RecordNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new SqlException("Sorry!!Server error occured!", ex);
            }
        }

        public async Task<List<Crop>> GetListOfCropsByLocation(string state, string city)
        {
            List<Crop> allCrops = new List<Crop>();
            try
            {
                allCrops = await _Context.Crops.ToListAsync();
                List<Crop> cropsSelectedByLocation = (from crops in allCrops                               
                                                  select crops).ToList();
                if (cropsSelectedByLocation == null)
                {
                    throw new RecordNotFoundException("Sorry!! No data available.");
                }
                return cropsSelectedByLocation;
            }
            catch (RecordNotFoundException ex)
            {
                throw new RecordNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new SqlException("Sorry!!Server error occured!", ex);
            }
        }
        public async Task<bool> AddCropPurchase(CropPurchase cropPurchase)
        {
            try
            {
                    int rowsAffected = 0;
                    _Context.Add(cropPurchase);
                    rowsAffected = await _Context.SaveChangesAsync();
                    if (rowsAffected == 0)
                    {
                        return false;
                    }
                    else
                    {
                        Crop objCrop = await _Context.Crops.FirstOrDefaultAsync
                                                          (c => c.CropId == cropPurchase.CropId);
                        if (objCrop == null)
                        {
                        throw new InvalidIdException("Sorry!! No such crop registered with this Id.");
                        }
                        else
                        {
                              objCrop.CropQuantity = objCrop.CropQuantity - cropPurchase.CropPurchaseQuantity;
                              await _Context.SaveChangesAsync();
                        }
                         return true;
                    }
            }
            catch (InvalidIdException ex)
            {
                throw new InvalidIdException(ex.Message);
            }
            catch (Exception)
            {
                throw new SqlException("Sorry!!Server error occured!");
            }
        }
        public async Task<List<CropPurchase>> GetCropPurchaseHistory()
        {
            try
            {
                List<CropPurchase> cropPurchases = new List<CropPurchase>();
                cropPurchases = await _Context.CropPurchases.ToListAsync();
                if (cropPurchases == null)
                {
                    throw new RecordNotFoundException("Sorry!! No data available.");
                }
                return cropPurchases;
            }
            catch (RecordNotFoundException ex)
            {
                throw new RecordNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new SqlException("Sorry!!Server error occured!", ex);
            }
        }
        public async Task<bool> AddSupplierFeedback(Feedback feedback)
        {
            try
            {
                GeneralMethods objGeneral = new GeneralMethods(_Context);
                return await objGeneral.AddFeedback(feedback);
            }
            catch (Exception ex)
            {
                throw new SqlException("Sorry!!Server error occured!", ex);
            }
        }

    }
}
