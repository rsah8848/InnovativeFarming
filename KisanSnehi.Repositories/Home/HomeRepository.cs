using KisanSnehi.CustomExceptions;
using KisanSnehi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Repositories.Home
{
    public class HomeRepository : IHomeRepository
    {
        private KisanSnehiDBContext _Context;
        public HomeRepository(KisanSnehiDBContext kisanSnehiDBContext)
        {
            _Context = kisanSnehiDBContext;
        }
        public async Task<bool> AddRegistrationDetails(Registration registeration)
        {
            Registration registerationDetails = await _Context.Registrations.FirstOrDefaultAsync(s => s.EmailId == registeration.EmailId && s.UserTypeId==registeration.UserTypeId);
            if (registerationDetails != null)
            {
                throw new UserExistsException(" user already present");
            }
            try
            {
                
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(registeration.Password);
                registeration.Password = passwordHash;
                registeration.RegDate = DateTime.Today;
                registeration.IsDeleted = false;
                
                int rowAffected = 0;
                _Context.Add(registeration);
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
        public async Task<List<Registration>> GetRegistrationDetails()
        {
            try
            {
                List<Registration> registerations = await _Context.Registrations.ToListAsync();
                return registerations;
            }
            catch (Exception e)
            {
                throw new SqlException(e.Message);
            }
        }
        public async Task<List<Location>> GetAllLocations()
        {
            try
            {
                List<Location> locations = await _Context.Locations.ToListAsync();
                return locations;
            }
            catch (Exception e)
            {
                throw new SqlException(e.Message);
            }
        }
        //returns user type id if login verified
        public async Task<int> CheckLogin(Registration registration)
        {
            Registration user = await _Context.Registrations.FirstOrDefaultAsync(r => r.EmailId == registration.EmailId);
            if (user == null || user.IsDeleted==true)
            {
                throw new RecordNotFoundException("user does not exists");
            }
            try
            {
                bool verified = BCrypt.Net.BCrypt.Verify(registration.Password, user.Password);
                if (!verified)
                {
                    return 0;
                }
                else
                {
                    return user.UserTypeId;
                }
            }
            catch(Exception ex)
            {
                throw new IncorrectLoginCredentialsException("Incorrect userName or password",ex);

            }
            
        }
        public async Task<bool> ForgotPassword(Registration user)
        {
            try
            {
                Registration registeration = await _Context.Registrations.FirstOrDefaultAsync(s => s.RegId == user.RegId);
                if (registeration == null)
                {
                    throw new RecordNotFoundException("Records not found");
                }
                int rows = 0;
                if (user.SecurityQue.Equals(registeration.SecurityQue) && user.Answer.Equals(registeration.Answer))
                {
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

                    registeration.Password = passwordHash;
                    registeration.UpdatedDate = DateTime.Now.Date;
                    rows = await _Context.SaveChangesAsync();
                    if (rows == 0)
                        return false;
                    else
                        return true;
                }
                else
                {
                    throw new IncorrectLoginCredentialsException("Details does not match");
                }
                
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }

        }

        public async Task<bool> ChangePassword(Registration user)
        {
            GeneralMethods objGeneralMethods = new GeneralMethods(_Context);
            bool value = await objGeneralMethods.ChangePassword(user);
            return value;
        }
    }
}
