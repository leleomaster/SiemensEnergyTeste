using Mapster;
using Microsoft.AspNetCore.Mvc;
using SiemensEnergyTeste.Application.Services;
using SiemensEnergyTeste.Domain.Dtos;
using SiemensEnergyTeste.Domain.Interfaces.Services;
using SiemensEnergyTeste.Domain.ViewModels;

namespace SiemensEnergyTeste.WebApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _generoService;
        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }


        [HttpGet]
        [Route("genero")]
        public async Task<IActionResult> Obter(Guid id)
        {
            try
            {
                var genero = await _generoService.GetByIdAsync(id);

                if (genero is not null)
                {
                    var generoViewModel = genero.Adapt<GeneroViewModels>();

                    return Ok(generoViewModel);
                }
                return StatusCode(404, $"Não foi encontrato nenhum genero com o id {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("generos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var generos = await _generoService.GetAllAsync();

                if (generos.Any())
                {
                    var generosViewModel = generos.Adapt<GeneroViewModels>();
                    return Ok(generosViewModel);
                }
                return StatusCode(404, $"Nenhum genero encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Criar(GeneroViewModels genero)
        {
            try
            {
                var generoDto = genero.Adapt<GeneroDto>();

                await _generoService.AddAsync(generoDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Atualizar(GeneroViewModels genero)
        {
            try
            {
                var generoDto = genero.Adapt<GeneroDto>();

                await _generoService.UpdateAsync(generoDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Deletar(Guid id)
        {
            try
            {
                await _generoService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
