using gerenciador_de_biblioteca.Core.Entities;
using gerenciador_de_biblioteca.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace gerenciador_de_biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<ActionResult> BuscarTodosOsLivrosAsync()
        {
            var listaLivros = await _livroService.BuscarTodosOsLivrosAsync();
            return Ok(listaLivros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> BuscarTodosOsLivrosAsync(int id)
        {
            var livro = await _livroService.BuscarLivroPorIdAsync(id);
            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Livro livro)
        {
            await _livroService.CadastrarLivroAsync(livro);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarLivroPorIdAsync(int id)
        {
            await _livroService.DeletarLivroPorIdAsync(id);

            return Ok();
        }
    }
}