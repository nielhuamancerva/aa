using FinalADS.Application.Autores.Assemblers;
using FinalADS.Application.Autores.Constansts;
using FinalADS.Application.Autores.Contracts;
using FinalADS.Application.Autores.Dtos;
using FinalADS.Domain.Autores.Constants;
using FinalADS.Domain.Autores.Entities;
using Microsoft.AspNetCore.Http;
using Common;
using System;

namespace FinalADS.Application.Autores.Services
{
    public class AutorsApplicationService : IAutorsApplicationService
    {
        private readonly NewAutorAssembler _newAutorAssembler;
        public AutorsApplicationService(NewAutorAssembler newUserAssembler)
        {
            _newAutorAssembler = newUserAssembler;
        }

        public NewAutorResponseDto Register(NewAutorDto newAutorDto)
        {
            try
            {
                return new NewAutorResponseDto
                {
                    HttpStatusCode = StatusCodes.Status201Created,
                    Response = new ApiStringResponse(AutorsAppContants.AutorsCreated)
                };
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new NewAutorResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    Response = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }
    }
}
