using gerenciador_de_biblioteca.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gerenciador_de_biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataDevolucaoController : ControllerBase
    {
        private readonly IGerenciamentoBibliotecaService _gerenciamentoBibliotecaService;
        public DataDevolucaoController(IGerenciamentoBibliotecaService gerenciamentoBibliotecaService)
        {
            _gerenciamentoBibliotecaService = gerenciamentoBibliotecaService;
        }

        /// <summary>
        /// Cadastra data de devolução para os livros cadastrados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataDevolucao"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Realiza o empréstimo de um livro.")]
        [SwaggerResponse(200, "O empréstimo foi realizado com sucesso.")]
        [SwaggerResponse(400, "Os dados da requisição estão ausentes ou são inválidos.")]
        public async Task<IActionResult> CadastrarDataDevolucaoAsync(int id, DateTime dataDevolucao)
        {
            await _gerenciamentoBibliotecaService.CadastrarDataDeDevolucaoAsync(id, dataDevolucao);
            return Ok();
        }
    }
}