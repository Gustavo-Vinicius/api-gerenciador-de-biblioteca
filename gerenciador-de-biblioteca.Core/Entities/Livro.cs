namespace gerenciador_de_biblioteca.Core.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? ISBN { get; set; }
        public int AnoPublicacao { get; set; }
    }
}