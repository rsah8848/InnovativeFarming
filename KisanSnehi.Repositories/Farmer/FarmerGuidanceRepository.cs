using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KisanSnehi.Entities;
using KisanSnehi.CustomExceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KisanSnehi.Repositories.Farmer
{
    public class FarmerGuidanceRepository:IFarmerGuidanceRepository
    {
        private KisanSnehiDBContext _Context;

        public FarmerGuidanceRepository(KisanSnehiDBContext kisanSnehiDBContext)
        {
            _Context = kisanSnehiDBContext;
        }

        public async Task<List<Guidance>> GetGuidance(Guidance guidance)
        {
            try
            {
                List<Guidance> cropNames = new List<Guidance>();
                cropNames = await _Context.Guidances.Where(g => g.FromMonth == guidance.FromMonth && g.ToMonth==guidance.ToMonth).ToListAsync();
                if(cropNames == null)
                {
                    throw new RecordNotFoundException("Data not found");
                }
                return cropNames;
            }
            catch(Exception)
            {
                throw new SqlException("Server error");
            }
        }
    }
}
