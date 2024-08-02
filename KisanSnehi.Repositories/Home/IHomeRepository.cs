using KisanSnehi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Repositories.Home
{
    public interface IHomeRepository
    {
        public Task<bool> AddRegistrationDetails(Registration registeration);
        public Task<List<Registration>> GetRegistrationDetails();
        public  Task<int> CheckLogin(Registration registration);
        public Task<List<Location>> GetAllLocations();
        public Task<bool> ChangePassword(Registration user);
    }
}
