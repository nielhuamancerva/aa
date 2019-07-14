using FinalADS.Domain.Accounts.Entities;
using AutoMapper;
using FinalADS.Application.Accounts.Dtos;

namespace FinalADS.Application.Accounts.Profiles
{
    public class NewAccountProfile : Profile
    {
        public NewAccountProfile()
        {
            /*CreateMap<NewAccountDto, Account>()
                .ForMember(
                    dest => dest.Customer,
                    opts => opts.MapFrom(
                        src => new Customer(src.CustomerId)
                    )
                ).ReverseMap();*/
        }
    }
}
