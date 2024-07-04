using Checklist_Gestran_Teste.Models;
using Checklist_Gestran_Teste.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Checklist_Gestran_Teste.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = new Usuario();

        public List<Usuario> Usuarios { get; set; }

        public string ButtonText => Usuario.Id == 0 ? "Criar" : "Editar";


        public async Task OnGetAsync()
        {
            Usuarios = await _apiService.GetUsuariosAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Usuarios = await _apiService.GetUsuariosAsync();
                Usuario = new Usuario();
                return Page();
            }

            if (Usuario.Id == 0)
            {
                await _apiService.CreateUsuarioAsync(Usuario);
            }
            else
            {
                await _apiService.UpdateUsuarioAsync(Usuario);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetEditAsync(int id)
        {
            Usuario = await _apiService.GetUsuarioByIdAsync(id);
            Usuarios = await _apiService.GetUsuariosAsync();            
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _apiService.DeleteUsuarioAsync(id);
            return RedirectToPage();
        }
    }
}
