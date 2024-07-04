using Checklist_Gestran_Teste.Models;
using Checklist_Gestran_Teste.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace Checklist_Gestran_Teste.Pages.Checklists
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;
        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public Checklist Checklist { get; set; }
        public List<Checklist> ChecklistList { get; set; }

        [BindProperty]
        public List<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();

        public List<Veiculo> Veiculos { get; set; }
        public List<Usuario> UsuariosExecutores { get; set; }
        public List<Usuario> UsuariosSupervisores { get; set; }
        public List<ItemInspecao> ItemInspecoes { get; set; }

        public string ButtonText => Checklist.Id == 0 ? "Criar" : "Editar";

        public async Task<IActionResult> OnGetAsync()
        {
            Veiculos = await _apiService.GetVeiculosAsync();

            UsuariosExecutores = await _apiService.GetUsuariosAsync();
            UsuariosSupervisores = await _apiService.GetUsuariosAsync();

            UsuariosExecutores.Where(s => s.Tipo.Equals("Executor", StringComparison.Ordinal));
            UsuariosSupervisores.Where(s => s.Tipo.Equals("Supervisor", StringComparison.Ordinal));

            ItemInspecoes = await _apiService.GetItensInspecaoAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ChecklistList = await _apiService.GetChecklistAsync();
                Checklist = new Checklist();
                await OnGetAsync(); // Para repopular os dropdowns em caso de erro
                return Page();
            }

            if (Checklist.Id == 0)
            {
                await _apiService.CreateChecklistAsync(Checklist);
            }
            else
            {
                await _apiService.UpdateChecklistAsync(Checklist);
            }
            return RedirectToPage();            
        }
    }
}
