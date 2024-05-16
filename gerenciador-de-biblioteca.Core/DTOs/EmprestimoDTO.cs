namespace gerenciador_de_biblioteca.Core.DTOs
{
    public class EmprestimoDTO
    {
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}