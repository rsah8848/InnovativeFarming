using KisanSnehi.Entities;
using KisanSnehi.Repositories.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Services.Admin
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepository _adminRepository;
        public AdminServices(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<bool> ChangeAdminPassword(Registration admin)
        {
            return await _adminRepository.ChangeAdminPassword(admin);
        }

        public async Task<bool> DeactivateAdminProfile(Registration admin)
        {
            return await _adminRepository.DeactivateAdminProfile(admin);
        }

        public async Task<bool> EditAdminProfile(Registration admin)
        {
            return await _adminRepository.EditAdminProfile(admin);
        }

        public async Task<Feedback> FeedbackDeatails(int id)
        {
            return await _adminRepository.FeedbackDeatails(id);
        }

        public async Task<List<Feedback>> GetFeedbacks()
        {
            return await _adminRepository.GetFeedbacks();
        }

        public async Task<Registration> GetUser(string email)
        {
            return await _adminRepository.GetUser(email);
        }

        public async Task<Registration> GetUsersById(int id)
        {
            return await _adminRepository.GetUsersById(id);
        }

        public async Task<List<Registration>> GetUsersByUserType(int id)
        {
            return await _adminRepository.GetUsersByUserType(id);
        }

        public async Task<bool> ResolveFeedback(int id)
        {
            return await _adminRepository.ResolveFeedback(id);
        }
    }
}
