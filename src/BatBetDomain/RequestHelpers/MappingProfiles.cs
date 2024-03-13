using AutoMapper;
using BatBetDomain.DTOs.Request;
using BatBetDomain.DTOs.Response;
using BatBetDomain.Entities;

namespace BatBetDomain.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Bet, BetDto>().IncludeMembers(x => x.Game, x => x.User);
            CreateMap<Game, BetDto>();
            CreateMap<User, BetDto>()
                .ForMember(d => d.MemberSince, o => o.MapFrom(s => s.CreatedAt));

            CreateMap<PlaceBetDto, Bet>();
            CreateMap<PlaceBetDto, Game>();
            CreateMap<PlaceBetDto, User>();
        }
    }
}
