using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiemensEnergyTeste.Domain.Dtos;
using SiemensEnergyTeste.Domain.Interfaces.Services;
using SiemensEnergyTeste.Domain.ViewModels;
using Mapster;

namespace SiemensEnergyTeste.WebApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }


        [HttpGet]
        [Route("autor")]
        public async Task<IActionResult> Obter(Guid id)
        {
            try
            {
                var autor = await _autorService.GetByIdAsync(id);

                if (autor is not null)
                {
                    var autorViewModel = autor.Adapt<AutorViewModels>();

                    return Ok(autorViewModel);
                }
                return StatusCode(404, $"Não foi encontrato nenhum autor com o id {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("autores")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var autors = await _autorService.GetAllAsync();

                if (autors.Any())
                {
                    var autorsViewModel = autors.Adapt<AutorViewModels>();
                    return Ok(autorsViewModel);
                }
                return StatusCode(404, $"Nenhum autor encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Criar(AutorViewModels autor)
        {
            try
            {
                var autorDto = autor.Adapt<AutorDto>();

                await _autorService.AddAsync(autorDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Atualizar(AutorViewModels autor)
        {
            try
            {
                var autorDto = autor.Adapt<AutorDto>();

                await _autorService.UpdateAsync(autorDto);

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
                await _autorService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
