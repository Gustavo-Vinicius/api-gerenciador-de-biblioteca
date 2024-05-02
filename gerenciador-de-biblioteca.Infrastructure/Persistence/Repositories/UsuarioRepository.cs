using gerenciador_de_biblioteca.Core.Entities;
using gerenciador_de_biblioteca.Core.Interfaces.Repositories;

namespace gerenciador_de_biblioteca.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BibliotecaDbContext _dbContext;
        public UsuarioRepository(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AdicionarUsuarioAsync(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Usuario> BuscarUsuarioPorIdAsync(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            
            return usuario;
        }
    }
}