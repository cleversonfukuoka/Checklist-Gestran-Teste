using System.ComponentModel.DataAnnotations;

namespace Checklist_Gestran_Teste.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A placa é obrigatória")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "O modelo é obrigatório")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O ano é obrigatório")]
        public int Ano { get; set; }
    }
}
