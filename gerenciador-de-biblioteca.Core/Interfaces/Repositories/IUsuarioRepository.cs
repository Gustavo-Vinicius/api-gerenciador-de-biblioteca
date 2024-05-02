using gerenciador_de_biblioteca.Core.Entities;

namespace gerenciador_de_biblioteca.Core.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuarioAsync(Usuario usuario);
        Task<Usuario> BuscarUsuarioPorIdAsync(int id);
    }
}