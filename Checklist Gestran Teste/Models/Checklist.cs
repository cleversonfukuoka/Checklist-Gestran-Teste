namespace Checklist_Gestran_Teste.Models
{
    public class Checklist
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public int UsuarioExecutorId { get; set; }
        public Usuario UsuarioExecutor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Finalizado { get; set; }
        public bool? Aprovado { get; set; }
        public int? UsuarioSupervisorId { get; set; }
        public Usuario UsuarioSupervisor { get; set; }
    }
}
