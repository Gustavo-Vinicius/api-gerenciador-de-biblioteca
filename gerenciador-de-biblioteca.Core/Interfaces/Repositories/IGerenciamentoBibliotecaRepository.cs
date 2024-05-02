using gerenciador_de_biblioteca.Core.Entities;

namespace gerenciador_de_biblioteca.Core.Interfaces.Repositories
{
    public interface IGerenciamentoBibliotecaRepository
    {
        Task EfetuarEmprestimoDoLivroAsync(Emprestimo emprestimo);
        Task RealizarDevolucaoDeLivroAsync(int id);
        Task CadastrarDataDeDevolucaoAsync(int id, DateTime dataDevolucao);
        Task<string> EmitirMensagemAsync(int id);
        
    }
}