using AutoMapper;
using FinalADS.Application.Autores.Dtos;
using FinalADS.Domain.Autores.Constants;
using FinalADS.Domain.Autores.Entities;
using System;


namespace FinalADS.Application.Autores.Assemblers
{
    public class NewAutorAssembler
    {
        private readonly IMapper _mapper;
        public NewAutorAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Autors ToEntity(NewAutorDto newAutorDto)
        {
            Autors autores = _mapper.Map<Autors>(newAutorDto);
            return autores;

        }
    }
}
