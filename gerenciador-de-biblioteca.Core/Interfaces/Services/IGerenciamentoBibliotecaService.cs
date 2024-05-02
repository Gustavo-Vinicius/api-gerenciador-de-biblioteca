using gerenciador_de_biblioteca.Core.Entities;

namespace gerenciador_de_biblioteca.Core.Interfaces.Services
{
    public interface IGerenciamentoBibliotecaService
    {
        Task EfetuarEmprestimoDoLivroAsync(Emprestimo emprestimo);
        Task RealizarDevolucaoDeLivroAsync(int id);
        Task CadastrarDataDeDevolucaoAsync(int id, DateTime dataDevolucao);
        Task<string> EmitirMensagemAsync(int id);
    }
}