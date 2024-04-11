using AutoMapper;
using BatBetDomain.DTOs.Request;
using BatBetDomain.DTOs.Response;
using BatBetDomain.Entities;
using Contracts;

namespace BatBetDomain.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Bet, BetDto>()
                .IncludeMembers(x => x.Game, x => x.User)
                .ForMember(d => d.UserBalance, o => o.MapFrom(s => double.Round(s.User.Balance, 2)));
            CreateMap<Game, BetDto>();
            CreateMap<User, BetDto>()
                .ForMember(d => d.MemberSince, o => o.MapFrom(s => s.CreatedAt));

            CreateMap<PlaceBetDto, Bet>();
            CreateMap<PlaceBetDto, Game>();
            CreateMap<PlaceBetDto, User>();
            CreateMap<BetDto, BetCreated>()
                .ForMember(d => d.GameName, o => o.MapFrom(s => s.GameName));

            CreateMap<int, BetUpdated>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s));

            CreateMap<int, BetDeleted>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s));
        }
    }
}
