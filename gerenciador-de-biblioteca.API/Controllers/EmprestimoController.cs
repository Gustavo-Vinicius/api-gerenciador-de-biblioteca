using gerenciador_de_biblioteca.Core.Entities;
using gerenciador_de_biblioteca.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Emprestimo emprestimo)
        {
            await _gerenciamentoBibliotecaService.EfetuarEmprestimoDoLivroAsync(emprestimo);
            return Ok();
        }

        [HttpPut("{id}/Devolver")]
        public async Task<IActionResult> DevolverLivroAsync(int id)
        {
            await _gerenciamentoBibliotecaService.RealizarDevolucaoDeLivroAsync(id);

            return Ok();
        }
    }
}