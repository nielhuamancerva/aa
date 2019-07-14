using AutoMapper;
using FinalADS.Application.Autores.Dtos;
using FinalADS.Domain.Autores.Entities;

namespace FinalADS.Application.Autores.Profiles
{
    public class NewAutorProfile : Profile
    {
        public NewAutorProfile(){
            CreateMap<NewAutorDto, Autors>().ReverseMap();
        }

        private class Autors
        {
        }
    }
}
