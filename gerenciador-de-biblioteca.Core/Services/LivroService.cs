using gerenciador_de_biblioteca.Core.Entities;
using gerenciador_de_biblioteca.Core.Interfaces.Repositories;
using gerenciador_de_biblioteca.Core.Interfaces.Services;

namespace gerenciador_de_biblioteca.Core.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<Livro> BuscarLivroPorIdAsync(int id)
        {
            return await _livroRepository.BuscarLivroPorIdAsync(id);
        }

        public async Task<List<Livro>> BuscarTodosOsLivrosAsync()
        {
            return await _livroRepository.BuscarTodosOsLivrosAsync();
        }

        public async Task CadastrarLivroAsync(Livro livro)
        {
            await _livroRepository.CadastrarLivroAsync(livro);
        }

        public async Task DeletarLivroPorIdAsync(int id)
        {
            await _livroRepository.DeletarLivroPorIdAsync(id);
        }
    }
}