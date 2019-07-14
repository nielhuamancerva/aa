using FinalADS.Application.Autores.Contracts;
using FinalADS.Application.Autores.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalADS.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("autor")]
    [ApiController]
  
    public class AutorControlador :ControllerBase
    {
        private readonly IAutorsApplicationService _AutorsApplicationService;

        public AutorControlador(IAutorsApplicationService AutorApplicationService)
        {
            _AutorsApplicationService = AutorApplicationService;
        }

        [HttpPost]
        public IActionResult Register([FromBody] NewAutorDto newUserDto)
        {
            NewAutorResponseDto response = _AutorsApplicationService.Register(newUserDto);
            return StatusCode(response.HttpStatusCode, response.Response);
        }
    }
}
