using KisanSnehi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Services.Farmer
{
    public interface IFarmerGuidanceService
    {
        Task<List<Guidance>> GetGuidance(Guidance guidance);
    }
}
