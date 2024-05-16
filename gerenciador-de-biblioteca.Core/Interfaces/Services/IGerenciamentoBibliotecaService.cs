using gerenciador_de_biblioteca.Core.DTOs;
using gerenciador_de_biblioteca.Core.Entities;

namespace gerenciador_de_biblioteca.Core.Interfaces.Services
{
    public interface IGerenciamentoBibliotecaService
    {
        Task EfetuarEmprestimoDoLivroAsync(int idUsuario, int idLivro, DateTime dataEmprestimo, DateTime? dataDevolucao);
        Task RealizarDevolucaoDeLivroAsync(int id);
        Task CadastrarDataDeDevolucaoAsync(int id, DateTime dataDevolucao);
        Task<string> EmitirMensagemAsync(int id);
        Task<List<EmprestimoDTO>> ObterTodosOsEmprestimosAsync();
    }
}