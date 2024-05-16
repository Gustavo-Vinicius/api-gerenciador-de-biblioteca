using gerenciador_de_biblioteca.Core.DTOs;
using gerenciador_de_biblioteca.Core.Entities;
using gerenciador_de_biblioteca.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gerenciador_de_biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IGerenciamentoBibliotecaService _gerenciamentoBibliotecaService;
        public EmprestimoController(IGerenciamentoBibliotecaService gerenciamentoBibliotecaService)
        {
            _gerenciamentoBibliotecaService = gerenciamentoBibliotecaService;
        }
        /// <summary>
        /// Rotina utilizada para realizar emprestimo dos livros cadastrados.
        /// </summary>
        /// <param name="emprestimoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Realiza o empréstimo de um livro.")]
        [SwaggerResponse(200, "O empréstimo foi realizado com sucesso.")]
        [SwaggerResponse(400, "Os dados da requisição estão ausentes ou são inválidos.")]
        public async Task<IActionResult> Post([FromBody] EmprestimoDTO emprestimoDTO)
        {
            await _gerenciamentoBibliotecaService.EfetuarEmprestimoDoLivroAsync(emprestimoDTO.IdUsuario, emprestimoDTO.IdLivro, emprestimoDTO.DataEmprestimo, emprestimoDTO.DataDevolucao);
            return Ok();
        }

        /// <summary>
        /// Rotina para realizar a devolução para os livros. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Devolver")]
        [SwaggerOperation(Summary = "Realiza a devolução de um livro.")]
        [SwaggerResponse(200, "O livro foi devolvido com sucesso.")]
        [SwaggerResponse(400, "O ID do empréstimo não é válido ou o livro já foi devolvido.")]
        public async Task<IActionResult> DevolverLivroAsync(int id)
        {
            await _gerenciamentoBibliotecaService.RealizarDevolucaoDeLivroAsync(id);

            return Ok();
        }

        /// <summary>
        /// Obtém todos os emprestimos realizados pela biblioteca.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ObterTodosOsEmprestimosAsync()
        {
            var emprestimos = await _gerenciamentoBibliotecaService.ObterTodosOsEmprestimosAsync();
            return Ok(emprestimos);
        }
    }
}