using System.Net.Http.Json;

namespace Dist2806.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
            _httpClient.BaseAddress = new Uri("http://localhost:7275");
        }

        public async Task<List<Materialss>> GetMaterialssAsync()
        {
            var res = await _httpClient.GetFromJsonAsync<List<Materialss>>("api/MaterialsData");
            return res ?? new List<Materialss>();
        }
        public async Task<Materialss?> GetMaterialssAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Materialss>($"api/MaterialsData/GetMaterial/{id}");
        }
        public async Task<bool> AddMaterialssAsync(Materialss material)
        {
            var res = await _httpClient.PostAsJsonAsync("api/MaterialsData/material", material);
            return res.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateMaterialssAsync(int id, Materialss material)
        {
            var res = await _httpClient.PutAsJsonAsync($"api/MaterialsData/{id}", material);
            return res.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteMaterialssAsync(int id)
        {
            var res = await _httpClient.DeleteAsync($"api/MaterialsData/{id}");
            return res.IsSuccessStatusCode;
        }

    }
}
