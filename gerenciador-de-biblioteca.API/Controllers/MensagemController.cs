using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerenciador_de_biblioteca.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace gerenciador_de_biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MensagemController : ControllerBase
    {
        private readonly IGerenciamentoBibliotecaService _gerenciamentoBibliotecaService;
        public MensagemController(IGerenciamentoBibliotecaService gerenciamentoBibliotecaService)
        {
            _gerenciamentoBibliotecaService = gerenciamentoBibliotecaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> EmitirMensagemAsync(int id)
        {
            var mensagem = await _gerenciamentoBibliotecaService.EmitirMensagemAsync(id);
            return Ok(mensagem);
        }

    }
}