using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KisanSnehi.Entities;
using KisanSnehi.CustomExceptions;
using Microsoft.EntityFrameworkCore;

namespace KisanSnehi.Repositories.Farmer
{
    public class FarmerFertilizerRepository:IFarmerFertilizerRepository
    {
        private KisanSnehiDBContext _Context;

        public FarmerFertilizerRepository(KisanSnehiDBContext kisanSnehiDBContext)
        {
            _Context = kisanSnehiDBContext;
        }

        public async Task<List<Fertilizer>> GetListOfFertilizers()
        {
            List<Fertilizer> fertilizers = new List<Fertilizer>();
            try
            {
                fertilizers = await _Context.Fertilizers.ToListAsync();
                if(fertilizers == null)
                {
                    throw new RecordNotFoundException("Data not found");
                }
                return fertilizers;
            }
            catch (Exception)
            {
                throw new SqlException("Server error");
            }
        } 


        public async Task<bool> AddFertilizerPurchase(FertilizerPurchase fertilizerPurchase)
        {
           /* try
            {
                if(await _Context.Registrations.FirstOrDefaultAsync(r => r.RegId == fertilizerPurchase.FarmerId && r.RegId == fertilizerPurchase.TraderId) == null)
                {
                    throw new RecordNotFoundException("Invalid Farmer or Trader ID");
                }
                else if(await _Context.Fertilizers.FirstOrDefaultAsync(f=>f.FertilizerId == fertilizerPurchase.FertilizerId) != null)
                {
                    throw new RecordNotFoundException("Fertilizer not present");
                }
                else
                {*/
                    int rowsAffected = 0;
                    _Context.Add(fertilizerPurchase);
                    rowsAffected = await _Context.SaveChangesAsync();
                    if (rowsAffected == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                /*}
            }
            catch (Exception)
            {
                throw new SqlException("Server error");
            }*/
        }


        public async Task<List<FertilizerPurchase>> GetAllPurchasedFertilizers()
        { 
            try
            {
                List<FertilizerPurchase> fertilizerPurchases = new List<FertilizerPurchase>();
                fertilizerPurchases = await _Context.FertilizerPurchases.ToListAsync();
                if(fertilizerPurchases == null)
                {
                    throw new RecordNotFoundException("Data not found");
                }
                return fertilizerPurchases;
            }
            catch (Exception)
            {
                throw new SqlException("Server error");
            }
        }
    }
}
