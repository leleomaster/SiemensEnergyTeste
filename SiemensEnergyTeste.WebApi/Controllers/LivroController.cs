using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using SiemensEnergyTeste.Application.Services;
using SiemensEnergyTeste.Domain.Dtos;
using SiemensEnergyTeste.Domain.Interfaces.Services;
using SiemensEnergyTeste.Domain.ViewModels;

namespace SiemensEnergyTeste.WebApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;
        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }


        [HttpGet]
        public async Task<IActionResult> Obter(Guid id)
        {
            try
            {
                var livro = await _livroService.GetByIdAsync(id);

                if (livro is not null)
                {
                    var livroViewModel = livro.Adapt<LivroViewModels>();

                    return Ok(livroViewModel);
                }
                return StatusCode(404, $"Não foi encontrato nenhum livro com o id {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("livros")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var livros = await _livroService.GetAllAsync();

                if (livros.Any())
                {
                    var livrosViewModel = livros.Adapt<List<LivroViewModels>>();
                    return Ok(livrosViewModel);
                }
                return StatusCode(404, $"Nenhum livro encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Criar(LivroViewModels livro)
        {
            try
            {
                var livroDto = livro.Adapt<LivroDto>();

                await _livroService.AddAsync(livroDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Atualizar(LivroViewModels livro)
        {
            try
            {
                var livroDto = livro.Adapt<LivroDto>();

                await _livroService.UpdateAsync(livroDto);

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
                await _livroService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
