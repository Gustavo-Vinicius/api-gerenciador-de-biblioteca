using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerenciador_de_biblioteca.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        /// <summary>
        /// Emite uma mensagem para um determinado ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Emite uma mensagem para um determinado ID.")]
        [SwaggerResponse(200, "Mensagem emitida com sucesso.", typeof(string))]
        [SwaggerResponse(404, "ID não encontrado.")]
        public async Task<ActionResult<string>> EmitirMensagemAsync(int id)
        {
            var mensagem = await _gerenciamentoBibliotecaService.EmitirMensagemAsync(id);
            return Ok(mensagem);
        }

    }
}