using gerenciador_de_biblioteca.Core.Entities;
using gerenciador_de_biblioteca.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        /// <summary>
        /// Obtém todos os livros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os livros.")]
        [SwaggerResponse(200, "Lista de todos os livros.")]
        public async Task<ActionResult<IEnumerable<Livro>>> BuscarTodosOsLivrosAsync()
        {
            var listaLivros = await _livroService.BuscarTodosOsLivrosAsync();
            return Ok(listaLivros);
        }

        /// <summary>
        /// Obtém um livro por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um livro por ID.")]
        [SwaggerResponse(200, "O livro encontrado.", typeof(Livro))]
        [SwaggerResponse(404, "Livro não encontrado.")]
        public async Task<ActionResult<Livro>> BuscarLivroPorIdAsync(int id)
        {
            var livro = await _livroService.BuscarLivroPorIdAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        /// <summary>
        /// Cadastra um novo livro.
        /// </summary>
        /// <param name="livro"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo livro.")]
        [SwaggerResponse(200, "Livro cadastrado com sucesso.")]
        [SwaggerResponse(400, "Os dados da requisição estão ausentes ou são inválidos.")]
        public async Task<IActionResult> Post([FromBody] Livro livro)
        {
            await _livroService.CadastrarLivroAsync(livro);
            return Ok();
        }

        /// <summary>
        /// Exclui um livro por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um livro por ID.")]
        [SwaggerResponse(200, "Livro excluído com sucesso.")]
        [SwaggerResponse(404, "Livro não encontrado.")]
        public async Task<IActionResult> DeletarLivroPorIdAsync(int id)
        {
            await _livroService.DeletarLivroPorIdAsync(id);
            return Ok();
        }
    }
}