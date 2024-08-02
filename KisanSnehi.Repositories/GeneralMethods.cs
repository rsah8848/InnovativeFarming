using KisanSnehi.CustomExceptions;
using KisanSnehi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Repositories
{
    public class GeneralMethods
    {
        private KisanSnehiDBContext _Context;
        public GeneralMethods(KisanSnehiDBContext kisanSnehiDBContext)
        {
            _Context = kisanSnehiDBContext;
        }
        DateTime today = DateTime.Today;
        public async Task<bool> EditProfile(Registration user)
        {

            try
            {
                Registration registration = await _Context.Registrations.FirstOrDefaultAsync
                    (s => s.EmailId.Equals(user.EmailId));

                if (registration == null)
                    throw new RecordNotFoundException("No such record exists with this registration Id!!");
                else
                {
                    int rowsAffected = 0;
                    if (user.Name != null || !user.Name.Equals(registration.Name))
                        registration.Name = user.Name;
                    if (user.Address != null || !user.Address.Equals(registration.Address))
                        registration.Address = user.Address;
                    if (user.LocationId != 0)
                        registration.LocationId = user.LocationId;
                    if (user.PhoneNo != 0 || !user.PhoneNo.Equals(registration.PhoneNo))
                        registration.PhoneNo = user.PhoneNo;
                    registration.UpdatedDate = today;
                    rowsAffected = await _Context.SaveChangesAsync();
                    /*if (rowsAffected > 0)*/

                    /*rowsAffected = await _Context.SaveChangesAsync();*/

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

        public async Task<bool> DeactivateProfile(Registration user)
        {
            try
            {
                Registration registration = await _Context.Registrations.FirstOrDefaultAsync
                    (s => s.EmailId == user.EmailId);
                if (registration == null)
                    throw new RecordNotFoundException("No such record exists with this registration Id!!");
                else
                {
                    int rowsAffected = 0;
                    Registration temp = await _Context.Registrations.FirstOrDefaultAsync
                        (s => s.RegId == registration.RegId);

                    temp.IsDeleted = true;

                    rowsAffected = await _Context.SaveChangesAsync();

                    if (rowsAffected == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (RecordNotFoundException ex)
            {
                throw new SqlException(ex.Message);
            }
            catch (Exception)
            {
                throw new SqlException("Sorry!!Server error occured!");
            }
        }
        public async Task<bool> ChangePassword(Registration user)
        {

            try
            {
                Registration registration = await _Context.Registrations.FirstOrDefaultAsync
                    (s => s.EmailId == user.EmailId);
                if (registration == null)
                    throw new RecordNotFoundException("No such record exists with this registration Id!!");
                else
                {
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    bool verified = BCrypt.Net.BCrypt.Verify(user.Password, registration.Password);
                    if (verified)

                    {
                        throw new PasswordNotAvailableException("this password is not available");
                    }
                    int rowsAffected = 0;
                    if (user.SecurityQue.Equals(registration.SecurityQue) &&
                        user.Answer.Equals(registration.Answer))
                    {
                        registration.Password = passwordHash;
                        registration.UpdatedDate = today;
                    }

                    rowsAffected = await _Context.SaveChangesAsync();
                    if (rowsAffected == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (PasswordNotAvailableException ex)
            {
                throw new PasswordNotAvailableException(ex.Message);
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
        public async Task<Registration> GetUser(string email)
        {
            try
            {
                Registration user = await _Context.Registrations.FirstOrDefaultAsync(r => r.EmailId == email);
                if (user == null)
                {
                    throw new RecordNotFoundException("user does not exists");
                }
                else
                {
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new SqlException("Server error occured! ", ex);

            }

        }
        public async Task<bool> UpdateUserProfileImage(Registration user)
        {
            try
            {
                Registration registeration = await _Context.Registrations.FirstOrDefaultAsync(s => s.RegId == user.RegId);

                int rows = 0;
                if (user.Image != null || !user.Image.Equals(registeration.Image))
                    registeration.Image = user.Image;

                registeration.UpdatedDate = today;
                rows = await _Context.SaveChangesAsync();

                if (rows == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        public async Task<bool> RemoveUserProfileImage(Registration user)
        {
            try
            {
                Registration registeration = await _Context.Registrations.FirstOrDefaultAsync(s => s.RegId == user.RegId);

                int rows = 0;
                registeration.Image = null;

                registeration.UpdatedDate = today;
                rows = await _Context.SaveChangesAsync();

                if (rows == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        public async Task<bool> AddFeedback(Feedback feedback)
        {
            
            try
            {
                feedback.UpdatedDate = DateTime.Today;
                feedback.RegDate = DateTime.Today;
                feedback.IsDeleted = false;
                feedback.Status = "active";

                int rowAffected = 0;
                _Context.Add(feedback);
                rowAffected = await _Context.SaveChangesAsync();
                if (rowAffected == 0)
                {
                    throw new Exception("Insertion failed");
                }
                else
                {

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new SqlException("Sql Exception", ex);
            }
        }



    }
}
