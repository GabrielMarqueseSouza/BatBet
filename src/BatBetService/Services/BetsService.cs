using AutoMapper;
using AutoMapper.QueryableExtensions;
using BatBetService.DTOs.Request;
using BatBetService.DTOs.Response;
using BatBetService.Entities;
using BatBetService.Interfaces.Repositories;
using BatBetService.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatBetService.Services
{
    public class BetsService(IMapper mapper, IBetsRepository betRepository, IUserRepository userRepository) : IBetsService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBetsRepository _betsRepository = betRepository;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<IList<BetDto>> GetBets(string date)
        {
            IQueryable<Bet> query = await _betsRepository.GetBets();

            if (!string.IsNullOrEmpty(date))
            {
                query = query
                        .Where(x => x.CreatedAt
                        .CompareTo(DateTime.Parse(date)
                        .ToUniversalTime()) > 0);
            }

            List<BetDto> response = await query.ProjectTo<BetDto>(_mapper.ConfigurationProvider).ToListAsync();

            return response;
        }

        public async Task<BetDto> GetBetById(int id)
        {
            return await _betsRepository.GetBetById(id);
        }

        public async Task<BetDto> CreateBet(PlaceBetDto bet, int userId)
        {
            User user = await _userRepository.GetById(userId) ?? throw new Exception("User not found.");

            await CheckValidUserBalance(user, bet.Amount);

            //create a logic to subtract the bet amount from the user balance
            //and, if the balance is lower than the bet amount, block the user from finishing the bet

            Bet placedBet = _mapper.Map<Bet>(bet);

            placedBet.PlatformFee = 0.10;
            placedBet.UserId = userId;

            await _betsRepository.Add(placedBet);

            await _betsRepository.CommitChanges();

            BetDto response = await _betsRepository.GetBetById(placedBet.Id);

            return response;
        }

        public async Task<bool> UpdateBet(int id)
        {
            return await _betsRepository.UpdateBet(id);
        }

        public async Task<bool> DeleteBet(int id)
        {
            Bet bet = await _betsRepository.GetById(id) ??
                    throw new Exception("Bet not found.");

            _betsRepository.Remove(bet);

            bool result = await _betsRepository.CommitChanges() > 0;

            return result;
        }

        private async Task CheckValidUserBalance(User user, double betAmount)
        {
            if (user.Balance < betAmount)
            {
                throw new Exception("Insufficient balance!");
            }

            user.Balance = -betAmount;

            await _userRepository.CommitChanges();
        }
    }
}
