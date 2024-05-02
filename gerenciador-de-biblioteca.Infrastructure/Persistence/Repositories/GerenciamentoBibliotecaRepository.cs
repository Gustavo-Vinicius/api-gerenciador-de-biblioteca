using gerenciador_de_biblioteca.Core.Entities;
using gerenciador_de_biblioteca.Core.Interfaces.Repositories;

namespace gerenciador_de_biblioteca.Infrastructure.Persistence.Repositories
{
    public class GerenciamentoBibliotecaRepository : IGerenciamentoBibliotecaRepository
    {
        private readonly BibliotecaDbContext _dbContext;
        public GerenciamentoBibliotecaRepository(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task EfetuarEmprestimoDoLivroAsync(Emprestimo emprestimo)
        {
            var livro = await _dbContext.Livros.FindAsync(emprestimo.IdLivro);
            var usuario = await _dbContext.Usuarios.FindAsync(emprestimo.IdUsuario);
            // if (livro == null || usuario == null)
            // {
            //     return BadRequest("Livro ou usuário não encontrados.");
            // }
            emprestimo.DataEmprestimo = DateTime.Now;

            await _dbContext.Emprestimos.AddAsync(emprestimo);

            await _dbContext.SaveChangesAsync();
        }

        public async Task RealizarDevolucaoDeLivroAsync(int id)
        {
            var emprestimo = await _dbContext.Emprestimos.FindAsync(id);

            _dbContext.Emprestimos.Remove(emprestimo);

            await _dbContext.SaveChangesAsync();

        }
        public async Task CadastrarDataDeDevolucaoAsync(int id, DateTime dataDevolucao)
        {
            var emprestimo = await _dbContext.Emprestimos.FindAsync(id);
            emprestimo.DataDevolucao = dataDevolucao;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> EmitirMensagemAsync(int id)
        {
            var emprestimo = await _dbContext.Emprestimos.FindAsync(id);

            // if (emprestimo == null)
            // {
            //     return NotFound();
            // }

            // Calcular dias de atraso (se houver)
            var dataDevolucao = emprestimo.DataDevolucao.Value;
            var hoje = DateTime.Now;
            int diasAtraso = (hoje > dataDevolucao) ? (hoje - dataDevolucao).Days : 0;

            if (diasAtraso > 0)
            {
                return $"Livro em atraso! {diasAtraso} dias de atraso.";
            }
            else
            {
                return "Livro devolvido em dia.";
            }
        }
    }
}