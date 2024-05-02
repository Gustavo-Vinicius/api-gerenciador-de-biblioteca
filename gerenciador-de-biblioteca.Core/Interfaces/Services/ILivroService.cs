using gerenciador_de_biblioteca.Core.Entities;

namespace gerenciador_de_biblioteca.Core.Interfaces.Services
{
    public interface ILivroService
    {
        Task CadastrarLivroAsync(Livro livro);
        Task <List<Livro>> BuscarTodosOsLivrosAsync();
        Task<Livro> BuscarLivroPorIdAsync(int id);
        Task DeletarLivroPorIdAsync(int id);
    }
}