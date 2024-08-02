using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KisanSnehi.Entities;
using KisanSnehi.Repositories.Trader;

namespace KisanSnehi.Services.Trader
{
    public class TraderServices: ITraderServices
    {
        TraderRepository _traderRepository;

        public TraderServices(ITraderRepository traderRepository)
        {
            _traderRepository = (TraderRepository)traderRepository;
        }

        //Get trader deatils 
        public async Task<Registration> GetUser(string email)
        {
            return await _traderRepository.GetUser(email);
        }

        //get user by id
        public async Task<Registration> GetUsersById(int id)
        {
            return await _traderRepository.GetUsersById(id);
        }

        //trader update profile details
        public async Task<bool> UpdateTraderProfile(Registration trader)
        {
            return await _traderRepository.UpdateTraderProfile(trader);
        }

        //update trader profile picture
        public async Task<bool> UpdateTraderProfileImage(Registration trader)
        {
            return await _traderRepository.UpdateTraderProfileImage(trader);
        }

        //remove profile picture
        public async Task<bool> RemoveProfilePicture(Registration user)
        {
            return await _traderRepository.RemoveProfilePicture(user);
        }

        //trader change password
        public async Task<bool> UpdateTraderPassword(Registration trader)
        {
            return await _traderRepository.UpdateTraderPassword(trader);
        }

        //trader delete profile
        public async Task<bool> DeleteTraderProfile(Registration trader)
        {
            return await _traderRepository.DeleteTraderProfile(trader);
        }

        //add fertilizers to List
        public async Task<bool> AddFertilizer(Fertilizer fertilizer)
        {
            return await _traderRepository.AddFertilizer(fertilizer);
        }

        // update fertilizer data
        public async Task<bool> UpdateFertilizer(Fertilizer fertilizer)
        {
            return await _traderRepository.UpdateFertilizer(fertilizer);
        }

        //delete fertilizer data
        public async Task<bool> DeleteFertilizer(int fertilizerId)
        {
            return await _traderRepository.DeleteFertilizer(fertilizerId);
        }

        //filter fertilizers based on name
        public async Task<List<Fertilizer>> GetFertilizerByName(string FertlizerName, int traderId)
        {
            return await _traderRepository.GetFertilizerByName(FertlizerName, traderId);
        }

        //filter fertilizers based on price
        public async Task<List<Fertilizer>> GetFertilizerByPrice(int MaxPrice, int MinPrice, int traderId)
        {
            return await _traderRepository.GetFertilizerByPrice( MaxPrice,  MinPrice, traderId);
        }

        //Get all fertilizers
        public async Task<List<Fertilizer>> GetAllFertilizers(int traderId)
        {
            return await _traderRepository.GetAllFertilizers(traderId);
        }

        //fertlizer sales history
        public async Task<List<FertilizerPurchase>> GetFertilizerSalesHistory()
        {
            return await _traderRepository.GetFertilizerSalesHistory();
        }

        //trader adding feedback
        public async Task<bool> AddTraderFeedback(Feedback feedback)
        {
            return await _traderRepository.AddTraderFeedback(feedback);
        }

        public async Task<bool> AddFeedback(Feedback feedback)
        {
            return await _traderRepository.AddFeedback(feedback);
        }

    }
}
