using KisanSnehi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Services.Admin
{
    public interface IAdminServices
    {
        public Task<Registration> GetUser(string email);
        public Task<bool> EditAdminProfile(Registration admin);
        public Task<bool> ChangeAdminPassword(Registration admin);
        public Task<bool> DeactivateAdminProfile(Registration admin);
        public Task<List<Registration>> GetUsersByUserType(int id);
        public Task<List<Feedback>> GetFeedbacks();
        public Task<bool> ResolveFeedback(int id);
        public Task<Registration> GetUsersById(int id);
        public Task<Feedback> FeedbackDeatails(int id);
    }
}
