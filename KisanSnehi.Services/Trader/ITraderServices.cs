using KisanSnehi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.Services.Trader
{
    public interface ITraderServices
    {
        //Get trader details 
        Task<Registration> GetUser(string email);

        //get user by id
        Task<Registration> GetUsersById(int id);

        //trader update profile details
        Task<bool> UpdateTraderProfile(Registration trader);

        //update trader profile picture
        Task<bool> UpdateTraderProfileImage(Registration trader);

        //remove profile picture
        Task<bool> RemoveProfilePicture(Registration user);

        //trader change password
        Task<bool> UpdateTraderPassword(Registration trader);

        //trader delete profile
        Task<bool> DeleteTraderProfile(Registration trader);

        //add fertilizers to List
        Task<bool> AddFertilizer(Fertilizer fertilizer);

        // update fertilizer data
        Task<bool> UpdateFertilizer(Fertilizer fertilizer);

        //delete fertilizer data
        Task<bool> DeleteFertilizer(int fertilizerId);

        //filter fertilizers based on name
        Task<List<Fertilizer>> GetFertilizerByName(string FertlizerName, int traderId);

        //filter fertilizers based on price
        Task<List<Fertilizer>> GetFertilizerByPrice(int MaxPrice, int MinPrice, int traderId);

        //Get all fertilizers
        Task<List<Fertilizer>> GetAllFertilizers(int traderId);

        //fertlizer sales history
        Task<List<FertilizerPurchase>> GetFertilizerSalesHistory();

        //trader adding feedback
        Task<bool> AddTraderFeedback(Feedback feedback);

        Task<bool> AddFeedback(Feedback feedback);

    }
}
