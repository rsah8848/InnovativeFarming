using KisanSnehi.Entities;
using KisanSnehi.Repositories.Home;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Services.Home
{
    public class HomeServices : IHomeServices
    {
        private readonly IHomeRepository _homeRepository;


        public HomeServices(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }
        public async Task<bool> AddRegistrationDetails(Registration registeration)
        {
           return await _homeRepository.AddRegistrationDetails(registeration);
        }

        public async Task<bool> ChangePassword(Registration user)
        {
            return await _homeRepository.ChangePassword(user);
        }

        public async Task<int> CheckLogin(Registration registration)
        {
            return await _homeRepository.CheckLogin(registration);
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _homeRepository.GetAllLocations();
        }

        public async Task<List<Registration>> GetRegistrationDetails()
        {
            return await _homeRepository.GetRegistrationDetails();
        }
    }
}
