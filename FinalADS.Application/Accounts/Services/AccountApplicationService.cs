using FinalADS.Application.Accounts.Assemblers;
using FinalADS.Application.Accounts.Constants;
using FinalADS.Application.Accounts.Contracts;
using FinalADS.Application.Accounts.Dtos;
using FinalADS.Domain.Accounts.Contracts;
using FinalADS.Domain.Accounts.Entities;
using Microsoft.AspNetCore.Http;
using Common;
using System;
using FinalADS.Application.Accounts.ViewModels;

namespace FinalADS.Application.Accounts.Services
{
    public class AccountApplicationService : IAccountApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;
        private readonly NewAccountAssembler _newAccountAssembler;

        public AccountApplicationService(
            IUnitOfWork unitOfWork,
            IAccountRepository accountRepository,
            NewAccountAssembler newAccountAssembler)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
            _newAccountAssembler = newAccountAssembler;
        }

        public NewAccountResponseDto Register(NewAccountDto newAccountDto)
        {
            try
            {
                Account account = _newAccountAssembler.ToEntity(newAccountDto);
                _accountRepository.SaveOrUpdate(account);
                return new NewAccountResponseDto
                {
                    HttpStatusCode = StatusCodes.Status201Created,
                    Response = new ApiStringResponse(AccountAppConstants.AccountCreated)
                };
            }
            catch (Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new NewAccountResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    Response = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }



        public NewAccountResponseDto Delete(NewAccountDto newAccountDto)
        {
            try
            {
                Account account = _newAccountAssembler.ToEntity(newAccountDto);
                _accountRepository.Delete(account);
                return new NewAccountResponseDto
                {
                    HttpStatusCode = StatusCodes.Status201Created,
                    Response = new ApiStringResponse(AccountAppConstants.AccountCreated)
                };
            }
            catch (Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new NewAccountResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    Response = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }
    }
}
