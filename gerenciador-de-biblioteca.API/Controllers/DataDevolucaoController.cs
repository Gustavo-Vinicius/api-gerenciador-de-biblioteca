using gerenciador_de_biblioteca.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPut("{id}")]
        public async Task<IActionResult> CadastrarDataDevolucaoAsync(int id, DateTime dataDevolucao)
        {
            await _gerenciamentoBibliotecaService.CadastrarDataDeDevolucaoAsync(id, dataDevolucao);
            return Ok();
        }
    }
}