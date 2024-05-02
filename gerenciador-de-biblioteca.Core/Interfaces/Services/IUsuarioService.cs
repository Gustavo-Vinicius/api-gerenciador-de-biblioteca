using gerenciador_de_biblioteca.Core.Entities;

namespace gerenciador_de_biblioteca.Core.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task AdicionarUsuarioAsync(Usuario usuario);
        Task<Usuario> BuscarUsuarioPorIdAsync(int id);
    }
}