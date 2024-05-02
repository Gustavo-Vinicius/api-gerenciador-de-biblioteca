using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerenciador_de_biblioteca.Core.Entities;
using gerenciador_de_biblioteca.Core.Interfaces.Repositories;
using gerenciador_de_biblioteca.Core.Interfaces.Services;

namespace gerenciador_de_biblioteca.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task AdicionarUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.AdicionarUsuarioAsync(usuario);
        }

        public async Task<Usuario> BuscarUsuarioPorIdAsync(int id)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorIdAsync(id);
            return usuario;
        }
    }
}