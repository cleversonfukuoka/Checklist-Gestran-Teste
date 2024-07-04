using System.ComponentModel.DataAnnotations;

namespace Checklist_Gestran_Teste.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O tipo é obrigatório")]
        public string Tipo { get; set; }
    }
}
