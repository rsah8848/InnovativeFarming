using System;
using System.Collections.Generic;
using System.Text;
using KisanSnehi.Entities;
using System.Threading.Tasks;

namespace KisanSnehi.Repositories.Supplier
{
    public interface ISupplierRepository
    {
        Task<Registration> GetSupplier(string emailId);
        Task<bool> EditSupplierProfile(Registration supplier);
        Task<bool> ChangeSupplierPassword(Registration supplier);
        Task<bool> DeactivateSupplierProfile(Registration supplier);
        Task<bool> UpdateSupplierProfileImage(Registration supplier);
        Task<bool> RemoveSupplierProfileImage(Registration supplier);
        Task<List<Crop>> GetListOfAllAvailableCrops();
        Task<List<Crop>> GetListOfCropsByName(string cropName);
        Task<List<Crop>> GetListOfCropsByPrice(float cropPriceLowerLimit, float cropPriceUpperLimit);
        Task<List<Crop>> GetListOfCropsByLocation(string state, string city);
        Task<bool> AddCropPurchase(CropPurchase cropPurchase);
        Task<List<CropPurchase>> GetCropPurchaseHistory();
        Task<bool> AddSupplierFeedback(Feedback feedback);
    }
}