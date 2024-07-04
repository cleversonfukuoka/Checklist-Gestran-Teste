using Checklist_Gestran_Teste.Models;
using Checklist_Gestran_Teste.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Checklist_Gestran_Teste.Pages.ItensInspecao
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public ItemInspecao ItemInspecao { get; set; } = new ItemInspecao();

        public List<ItemInspecao> ItensInspecao { get; set; }

        public string ButtonText => ItemInspecao.Id == 0 ? "Criar" : "Editar";


        public async Task OnGetAsync()
        {
            ItensInspecao = await _apiService.GetItensInspecaoAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ItensInspecao = await _apiService.GetItensInspecaoAsync();
                ItemInspecao = new ItemInspecao();
                return Page();
            }

            if (ItemInspecao.Id == 0)
            {
                await _apiService.CreateItensInspecaoAsync(ItemInspecao);
            }
            else
            {
                await _apiService.UpdateItensInspecaoAsync(ItemInspecao);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetEditAsync(int id)
        {
            ItemInspecao = await _apiService.GetItensInspecaoByIdAsync(id);
            ItensInspecao = await _apiService.GetItensInspecaoAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _apiService.DeleteItensInspecaoAsync(id);
            return RedirectToPage();
        }
    }
}
