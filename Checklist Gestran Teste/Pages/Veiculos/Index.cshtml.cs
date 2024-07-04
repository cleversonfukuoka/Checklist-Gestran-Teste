using Checklist_Gestran_Teste.Models;
using Checklist_Gestran_Teste.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Checklist_Gestran_Teste.Pages.Veiculos
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]

        public Veiculo Veiculo { get; set; } = new Veiculo();

        public List<Veiculo> Veiculos { get; set; }

        public string ButtonText => Veiculo.Id == 0 ? "Criar" : "Editar";

        public async Task<IActionResult> OnGetAsync()
        {
            Veiculos = await _apiService.GetVeiculosAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Veiculos = await _apiService.GetVeiculosAsync();
                Veiculo = new Veiculo();
                return Page();
            }

            if (Veiculo.Id == 0)
            {
                await _apiService.CreateVeiculoAsync(Veiculo);
            }
            else
            {
                await _apiService.UpdateVeiculoAsync(Veiculo);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetEditAsync(int id)
        {
            Veiculo = await _apiService.GetVeiculoByIdAsync(id);
            Veiculos = await _apiService.GetVeiculosAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _apiService.DeleteVeiculoAsync(id);
            return RedirectToPage();
        }

    }
}
