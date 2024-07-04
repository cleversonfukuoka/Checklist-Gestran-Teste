using Checklist_Gestran_Teste.Models;

namespace Checklist_Gestran_Teste.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Usuario>>("api/Usuarios");
        }

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            await _httpClient.PostAsJsonAsync("api/Usuarios", usuario);
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            await _httpClient.PutAsJsonAsync($"api/Usuarios/{usuario.Id}", usuario);
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Usuario>($"api/Usuarios/{id}");
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Usuarios/{id}");

        }

        public async Task<List<Veiculo>> GetVeiculosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Veiculo>>("api/Veiculos");
        }

        public async Task CreateVeiculoAsync(Veiculo veiculo)
        {
            await _httpClient.PostAsJsonAsync("api/Veiculos", veiculo);
        }

        public async Task UpdateVeiculoAsync(Veiculo veiculo)
        {
            await _httpClient.PutAsJsonAsync($"api/Veiculos/{veiculo.Id}", veiculo);
        }

        public async Task<Veiculo> GetVeiculoByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Veiculo>($"api/Veiculos/{id}");
        }

        public async Task DeleteVeiculoAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Veiculos/{id}");
        }



        public async Task<List<ItemInspecao>> GetItensInspecaoAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ItemInspecao>>("api/ItensInspecao");
        }

        public async Task CreateItensInspecaoAsync(ItemInspecao itens)
        {
            await _httpClient.PostAsJsonAsync("api/ItensInspecao", itens);
        }

        public async Task UpdateItensInspecaoAsync(ItemInspecao itens)
        {
            await _httpClient.PutAsJsonAsync($"api/ItensInspecao/{itens.Id}", itens);
        }

        public async Task<ItemInspecao> GetItensInspecaoByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ItemInspecao>($"api/ItensInspecao/{id}");
        }

        public async Task DeleteItensInspecaoAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/ItensInspecao/{id}");
        }


        /* Checklist */

        public async Task<List<Checklist>> GetChecklistAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Checklist>>("api/Checklists");
        }

        public async Task CreateChecklistAsync(Checklist checklist)
        {
            await _httpClient.PostAsJsonAsync("api/Checklists", checklist);
        }

        public async Task UpdateChecklistAsync(Checklist checklist)
        {
            await _httpClient.PutAsJsonAsync($"api/Checklists/{checklist.Id}", checklist);
        }

        public async Task<Checklist> GetChecklistByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Checklist>($"api/Checklists/{id}");
        }

        public async Task DeleteChecklistAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Checklists/{id}");
        }
    }
}
