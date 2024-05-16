using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerenciador_de_biblioteca.Core.DTOs;
using gerenciador_de_biblioteca.Core.Entities;
using gerenciador_de_biblioteca.Core.Interfaces.Repositories;
using gerenciador_de_biblioteca.Core.Interfaces.Services;

namespace gerenciador_de_biblioteca.Core.Services
{
    public class GerenciamentoBibliotecaService : IGerenciamentoBibliotecaService
    {
        private readonly IGerenciamentoBibliotecaRepository _gerenciamentoBibliotecaRepository;
        public GerenciamentoBibliotecaService(IGerenciamentoBibliotecaRepository gerenciamentoBibliotecaRepository)
        {
            _gerenciamentoBibliotecaRepository = gerenciamentoBibliotecaRepository;
        }


        public async Task EfetuarEmprestimoDoLivroAsync(int idUsuario, int idLivro, DateTime dataEmprestimo, DateTime? dataDevolucao)
        {
            await _gerenciamentoBibliotecaRepository.EfetuarEmprestimoDoLivroAsync(idUsuario, idLivro, dataEmprestimo, dataDevolucao);
        }

        public async Task RealizarDevolucaoDeLivroAsync(int id)
        {
            await _gerenciamentoBibliotecaRepository.RealizarDevolucaoDeLivroAsync(id);
        }
        public async Task CadastrarDataDeDevolucaoAsync(int id, DateTime dataDevolucao)
        {
           await _gerenciamentoBibliotecaRepository.CadastrarDataDeDevolucaoAsync(id, dataDevolucao);
        }

        public async Task<string> EmitirMensagemAsync(int id)
        {
           var mensagem = await _gerenciamentoBibliotecaRepository.EmitirMensagemAsync(id);
           return mensagem;
        }

        public async Task<List<EmprestimoDTO>> ObterTodosOsEmprestimosAsync()
        {
            return await _gerenciamentoBibliotecaRepository.ObterTodosOsEmprestimosAsync();
        }
    }
}