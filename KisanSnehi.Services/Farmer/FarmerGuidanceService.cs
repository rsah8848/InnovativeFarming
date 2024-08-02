using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KisanSnehi.Entities;
using KisanSnehi.Repositories.Farmer;

namespace KisanSnehi.Services.Farmer
{
    public class FarmerGuidanceService:IFarmerGuidanceService
    {
        private IFarmerGuidanceRepository _farmerGuidanceRepository;

        public FarmerGuidanceService(IFarmerGuidanceRepository farmerGuidanceRepository)
        {
            _farmerGuidanceRepository = farmerGuidanceRepository;
        }

        public async Task<List<Guidance>> GetGuidance(Guidance guidance)
        {
            return await _farmerGuidanceRepository.GetGuidance(guidance);
        }
    }
}
