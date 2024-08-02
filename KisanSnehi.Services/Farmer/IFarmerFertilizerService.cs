using KisanSnehi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Services.Farmer
{
    public interface IFarmerFertilizerService
    {
        Task<List<Fertilizer>> GetListOfFertilizers();
        Task<bool> AddFertilizerPurchase(FertilizerPurchase fertilizerPurchase);
        Task<List<FertilizerPurchase>> GetAllPurchasedFertilizers();
    }
}
