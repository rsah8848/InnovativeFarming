using KisanSnehi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KisanSnehi.Repositories.Supplier;

namespace KisanSnehi.Services.Supplier
{
    public class SupplierServices : ISupplierServices
    {

        private ISupplierRepository _Repository;


        public SupplierServices(ISupplierRepository supplierRepository)
        {
            _Repository = supplierRepository;
        }

        public async Task<Registration> GetSupplier(string emailId)
        {
            return await _Repository.GetSupplier(emailId);
        }
        public async Task<bool> EditSupplierProfile(Registration supplier)
        {
            return await _Repository.EditSupplierProfile(supplier);
        }

        public async Task<bool> ChangeSupplierPassword(Registration supplier)
        {
            return await _Repository.ChangeSupplierPassword(supplier);
        }

        public async Task<bool> DeactivateSupplierProfile(Registration supplier)
        {
            return await _Repository.DeactivateSupplierProfile(supplier);
        }

        public async Task<List<Crop>> GetListOfAllAvailableCrops()
        {
            return await _Repository.GetListOfAllAvailableCrops();
        }

        public async Task<bool> UpdateSupplierProfileImage(Registration supplier)
        {
            return await _Repository.UpdateSupplierProfileImage(supplier);
        }

        public async Task<bool> RemoveSupplierProfileImage(Registration supplier)
        {
            return await _Repository.RemoveSupplierProfileImage(supplier);
        }

        public async Task<List<Crop>> GetListOfCropsByName(string cropName)
        {
            return await _Repository.GetListOfCropsByName(cropName);
        }

        public async Task<List<Crop>> GetListOfCropsByPrice(float cropPriceLowerLimit, float cropPriceUpperLimit)
        {
            return await _Repository.GetListOfCropsByPrice(cropPriceLowerLimit, cropPriceUpperLimit);
        }

        public async Task<List<Crop>> GetListOfCropsByLocation(string state, string city)
        {
            return await _Repository.GetListOfCropsByLocation(state, city);
        }

        public async Task<bool> AddCropPurchase(CropPurchase cropPurchase)
        {
            return await _Repository.AddCropPurchase(cropPurchase);
        }

        public async Task<List<CropPurchase>> GetCropPurchaseHistory()
        {
            return await _Repository.GetCropPurchaseHistory();
        }

        public async Task<bool> AddSupplierFeedback(Feedback feedback)
        {
            return await _Repository.AddSupplierFeedback(feedback);
        }
    }
}
