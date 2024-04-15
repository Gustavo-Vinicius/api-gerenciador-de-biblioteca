using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerenciador_de_biblioteca.Core.Entities
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }

        // Relacionamentos de navegação
        public Usuario? Usuario { get; set; }
        public Livro? Livro { get; set; }
    }
}