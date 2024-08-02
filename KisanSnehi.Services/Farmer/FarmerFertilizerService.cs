using System;
using System.Collections.Generic;
using System.Text;
using KisanSnehi.Repositories;
using KisanSnehi.Entities;
using KisanSnehi.Repositories.Farmer;
using System.Threading.Tasks;

namespace KisanSnehi.Services.Farmer
{
    public class FarmerFertilizerService:IFarmerFertilizerService
    {
        private IFarmerFertilizerRepository _farmerFertilizerRepository;

        public FarmerFertilizerService(IFarmerFertilizerRepository farmerFertilizerRepository)
        {
            _farmerFertilizerRepository = farmerFertilizerRepository;
        }

        public async Task<List<Fertilizer>> GetListOfFertilizers()
        {
            return await _farmerFertilizerRepository.GetListOfFertilizers();
        }


        public async Task<bool> AddFertilizerPurchase(FertilizerPurchase fertilizerPurchase)
        {
            return await _farmerFertilizerRepository.AddFertilizerPurchase(fertilizerPurchase);
        }


        public async Task<List<FertilizerPurchase>> GetAllPurchasedFertilizers()
        {
            return await _farmerFertilizerRepository.GetAllPurchasedFertilizers();
        }
    }
}
