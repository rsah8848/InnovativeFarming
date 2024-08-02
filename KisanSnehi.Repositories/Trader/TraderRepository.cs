using KisanSnehi.CustomExceptions;
using KisanSnehi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Repositories.Trader
{
    public class TraderRepository: ITraderRepository
    {
        private KisanSnehiDBContext _Context;

        DateTime today = DateTime.Today;
        public TraderRepository(KisanSnehiDBContext kisanSnehiDBContext)
        {
            _Context = kisanSnehiDBContext;
        }

        //Get trader deatils 

        public async Task<Registration> GetUser(string email)
        {
            GeneralMethods obj = new GeneralMethods(_Context);
            Registration user = await obj.GetUser(email);
            return user;

        }

        //get user by id
        public async Task<Registration> GetUsersById(int id)
        {
            try
            {
                Registration registeration = await _Context.Registrations.FirstOrDefaultAsync(r => r.RegId == id && r.IsDeleted == false);
                return registeration;
            }
            catch (Exception e)
            {
                throw new SqlException(e.Message);
            }
        }

        //trader update profile details

        public async Task<bool> UpdateTraderProfile(Registration trader)
        {

            GeneralMethods obj = new GeneralMethods(_Context);
            bool value = await obj.EditProfile(trader);
            return value;
        }

        //update trader profile picture

        public async Task<bool> UpdateTraderProfileImage(Registration trader)
        {
            GeneralMethods obj = new GeneralMethods(_Context);
            bool value = await obj.UpdateUserProfileImage(trader);
            return value;
        }

        //remove profile picture

        public async Task<bool> RemoveProfilePicture(Registration user)
        {
            try
            {
                GeneralMethods general = new GeneralMethods(_Context);
                return await general.RemoveUserProfileImage(user);
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        //trader change password

        public async Task<bool> UpdateTraderPassword(Registration trader)
        {

            GeneralMethods obj = new GeneralMethods(_Context);
            bool value = await obj.ChangePassword(trader);
            return value;
        }

        //trader delete profile

        public async Task<bool> DeleteTraderProfile(Registration trader)
        {
            GeneralMethods obj = new GeneralMethods(_Context);
            bool value = await obj.DeactivateProfile(trader);
            return value;
        }


        //add fertilizers to List

        public async Task<bool> AddFertilizer(Fertilizer fertilizer)
        {
            try
            {
                int rows = 0;
                fertilizer.FertilizerQuantityInStock = fertilizer.FertilizerQuantity;
                fertilizer.CreatedDate = today;
                fertilizer.UpdatedDate = today;
                fertilizer.IsDeleted = false;
                _Context.Add(fertilizer);
                rows = await _Context.SaveChangesAsync();
                if (rows == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        
        }


        // update fertilizer data

        public async Task<bool> UpdateFertilizer(Fertilizer fertilizer)
        {
            try
            {

                Fertilizer originalFertilizer = await _Context.Fertilizers.FirstOrDefaultAsync(s => s.FertilizerId == fertilizer.FertilizerId);
                if (fertilizer == null)
                {
                    throw new RecordNotFoundException("Record does not exists....");
                }
                int rows = 0;
                if (fertilizer.FertilizerName != null || !fertilizer.FertilizerName.Equals(originalFertilizer.FertilizerName))
                    originalFertilizer.FertilizerName = fertilizer.FertilizerName;
                if (fertilizer.FertilizerDesc != null || !fertilizer.FertilizerDesc.Equals(originalFertilizer.FertilizerDesc))
                    originalFertilizer.FertilizerDesc = fertilizer.FertilizerDesc;
                if (fertilizer.FertilizerQuantity != originalFertilizer.FertilizerQuantity)
                {
                    originalFertilizer.FertilizerQuantity = fertilizer.FertilizerQuantity;
                    originalFertilizer.FertilizerQuantityInStock = fertilizer.FertilizerQuantityInStock;
                }
                if (fertilizer.FertilizerPrice != originalFertilizer.FertilizerPrice && fertilizer.FertilizerPrice != 0)
                    originalFertilizer.FertilizerPrice = fertilizer.FertilizerPrice;

                originalFertilizer.UpdatedDate = today;
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


        //delete fertilizer data

        public async Task<bool> DeleteFertilizer(int fertilizerId)
        {
            try
            {
                int rows = 0;
                Fertilizer fertilizer = await _Context.Fertilizers.FirstOrDefaultAsync(s => s.FertilizerId == fertilizerId);
                if (fertilizer == null)
                {
                    throw new RecordNotFoundException("Record does not exists....");
                }
                fertilizer.IsDeleted = true;
                rows = await _Context.SaveChangesAsync();
                if (rows == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        //filter fertilizers based on name

        public async Task<List<Fertilizer>> GetFertilizerByName(string FertlizerName, int traderId)
        {
            try
            {

                List<Fertilizer> fertilizers = await _Context.Fertilizers.Where(c => c.FertilizerName.Equals(FertlizerName)  && c.TraderId== traderId && c.IsDeleted == false).ToListAsync();
                if (fertilizers == null)
                {
                    throw new RecordNotFoundException("No record found..."); 
                }
                return fertilizers;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }

        }

        //filter fertilizers based on price

        public async Task<List<Fertilizer>> GetFertilizerByPrice(int MaxPrice, int MinPrice, int traderId)
        {
            try
            {

                List<Fertilizer> fertilizers = await _Context.Fertilizers.Where(c => c.FertilizerPrice >= MinPrice && c.FertilizerPrice <= MaxPrice && c.TraderId == traderId && c.IsDeleted == false).ToListAsync();
                if (fertilizers == null)
                {
                    throw new RecordNotFoundException("No record found...");
                }
                return fertilizers;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        //Get all fertilizers

        public async Task<List<Fertilizer>> GetAllFertilizers(int traderId)
        {
            try
            {

                List<Fertilizer> fertilizers = await _Context.Fertilizers.Where(c => c.TraderId == traderId && c.IsDeleted == false).ToListAsync();
                if (fertilizers == null)
                {
                    throw new RecordNotFoundException("No record found...");
                }
                return fertilizers;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        //fertlizer sales history

        public async Task<List<FertilizerPurchase>> GetFertilizerSalesHistory()
        {
            try
            {
                List<FertilizerPurchase> fertilizers = await _Context.FertilizerPurchases.ToListAsync();
                if (fertilizers == null)
                {
                    throw new RecordNotFoundException("Data not found");
                }
                return fertilizers;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }


        //trader adding feedback

        public async Task<bool> AddTraderFeedback(Feedback feedback)
        {
            try
            {
                int rows = 0;

                feedback.RegDate = today;
                feedback.IsDeleted = false;
                _Context.Add(feedback);
                rows = await _Context.SaveChangesAsync();
                if (rows == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

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
                GeneralMethods general = new GeneralMethods(_Context);
                return await general.AddFeedback(feedback);
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }


    }
}
