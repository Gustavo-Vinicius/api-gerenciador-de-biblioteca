using gerenciador_de_biblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerenciador_de_biblioteca.Infrastructure.Persistence
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
       : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir chaves estrangeiras para o relacionamento entre Emprestimo e Usuario/Livro
            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.IdUsuario);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Livro)
                .WithMany()
                .HasForeignKey(e => e.IdLivro);
        }
    }
}