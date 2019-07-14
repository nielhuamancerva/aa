using FinalADS.Application.Autores.Dtos;

namespace FinalADS.Application.Autores.Contracts
{
    public interface IAutorsApplicationService
    {
        NewAutorResponseDto Register(NewAutorDto newAutorsDto);
        
    }
}
