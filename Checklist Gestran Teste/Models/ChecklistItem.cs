namespace Checklist_Gestran_Teste.Models
{
    public class ChecklistItem
    {
        public int Id { get; set; }
        public int ChecklistId { get; set; }
        public Checklist Checklist { get; set; }
        public int ItemInspecaoId { get; set; }
        public ItemInspecao ItemInspecao { get; set; }
        public bool Conforme { get; set; }
        public string Observacao { get; set; }
    }
}
