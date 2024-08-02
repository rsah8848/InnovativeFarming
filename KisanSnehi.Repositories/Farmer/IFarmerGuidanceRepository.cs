using KisanSnehi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Repositories.Farmer
{
    public interface IFarmerGuidanceRepository
    {
        Task<List<Guidance>> GetGuidance(Guidance guidance);
    }
}
