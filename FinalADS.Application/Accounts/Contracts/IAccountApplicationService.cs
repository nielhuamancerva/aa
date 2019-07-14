using FinalADS.Application.Accounts.Dtos;

namespace FinalADS.Application.Accounts.Contracts
{
    public interface IAccountApplicationService
    {
        NewAccountResponseDto Register(NewAccountDto newAccountDto);
        NewAccountResponseDto Delete(NewAccountDto newAccountDto);
    }
}
