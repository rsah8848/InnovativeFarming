using KisanSnehi.CustomExceptions;
using KisanSnehi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Repositories.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private KisanSnehiDBContext _Context;
        public AdminRepository(KisanSnehiDBContext kisanSnehiDBContext)
        {
            _Context = kisanSnehiDBContext;
        }

        DateTime today = DateTime.Today;
        public async Task<bool> EditAdminProfile(Registration admin)
        {
            GeneralMethods obj = new GeneralMethods(_Context);
            bool value = await obj.EditProfile(admin);
            return value;

        }
        public async Task<Registration> GetUser(string email)
        {
            GeneralMethods obj = new GeneralMethods(_Context);
            Registration user = await obj.GetUser(email);
            return user;
        }
        public async Task<bool> ChangeAdminPassword(Registration admin)
        {
            GeneralMethods obj = new GeneralMethods(_Context);
            bool value = await obj.ChangePassword(admin);
            return value;
        }

        public async Task<bool> DeactivateAdminProfile(Registration admin)
        {
            GeneralMethods obj = new GeneralMethods(_Context);
            bool value = await obj.DeactivateProfile(admin);
            return value;
        }

        public async Task<List<Registration>> GetUsersByUserType(int id)
        {
            try
            {
                List<Registration> registerations = await _Context.Registrations.Where(r => r.UserTypeId == id && r.IsDeleted == false).ToListAsync();
                foreach(Registration registration in registerations)
                {
                    Location location = new Location();
                    location = await _Context.Locations.FirstOrDefaultAsync(l => l.LocationId == registration.LocationId);
                    registration.Address =registration.Address+" "+location.City+" ";
                    registration.Address += location.State+" ";
                }
                return registerations;
            }
            catch (Exception e)
            {
                throw new SqlException(e.Message);
            }
        }
        public async Task<Registration> GetUsersById(int id)
        {
            try
            {
                 Registration registeration = await _Context.Registrations.FirstOrDefaultAsync(r=>r.RegId==id && r.IsDeleted==false);
                return registeration;
            }
            catch (Exception e)
            {
                throw new SqlException(e.Message);
            }
        }
        public async Task<List<Feedback>> GetFeedbacks()
        {
            try
            {
                List<Feedback> feedbacks = await _Context.Feedbacks.Where(r => r.Status == "active").ToListAsync();
                return feedbacks;
            }
            catch (Exception e)
            {
                throw new SqlException(e.Message);
            }
        }
        public async Task<bool> ResolveFeedback(int id)
        {
            try
            {
                Feedback feedback = await _Context.Feedbacks.FirstOrDefaultAsync(f => f.FeedbackId == id);
                if (feedback == null)
                    throw new RecordNotFoundException("No such record exists with this feedback Id!!");
                else
                {
                    int rowsAffected = 0;

                    feedback.Status = "resolved";
                    feedback.UpdatedDate = today;


                    rowsAffected = await _Context.SaveChangesAsync();
                    if (rowsAffected == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (RecordNotFoundException ex)
            {
                throw new SqlException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new SqlException("Sorry!!Server error occured!", ex);
            }
        }
        public async Task<Feedback> FeedbackDeatails(int id)
        {
            try
            {
                Feedback feedback = await _Context.Feedbacks.FirstOrDefaultAsync(f => f.FeedbackId == id);
                if (feedback == null)
                    throw new RecordNotFoundException("No such record exists with this feedback Id!!");
                else
                {
                    return feedback;
                }
            }
            catch (RecordNotFoundException ex)
            {
                throw new SqlException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new SqlException("Sorry!!Server error occured!", ex);
            }
        }
        
    }
}
