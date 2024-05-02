using gerenciador_de_biblioteca.Core.Entities;
using gerenciador_de_biblioteca.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gerenciador_de_biblioteca.Infrastructure.Persistence.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaDbContext _dbContext;
        public LivroRepository(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Livro> BuscarLivroPorIdAsync(int id)
        {
            return await _dbContext.Livros.FindAsync(id);
        }

        public async Task<List<Livro>> BuscarTodosOsLivrosAsync()
        {
            return await _dbContext.Livros.ToListAsync();
        }

        public async Task CadastrarLivroAsync(Livro livro)
        {
            await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletarLivroPorIdAsync(int id)
        {
            var livro = await _dbContext.Livros.FindAsync(id);

            _dbContext.Livros.Remove(livro);
            await _dbContext.SaveChangesAsync();
        }
    }
}