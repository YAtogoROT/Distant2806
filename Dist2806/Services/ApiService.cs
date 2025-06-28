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

        public async Task<List<Materialss>> GetMaterialssAsync() =>
            await _httpClient.GetFromJsonAsync<List<Materialss>>("api/materials") ?? new();
        public async Task<Materialss?> GetMaterialssAsync(int id) =>
            await _httpClient.GetFromJsonAsync<Materialss>($"api/materials/{id}");
        public async Task AddMaterialssAsync(Materialss material) =>
            await _httpClient.PostAsJsonAsync("api/materials", material);
        public async Task UpdateMaterialssAsync(int id, Materialss material) =>
            await _httpClient.PutAsJsonAsync($"api/materials/{id}", material);
        public async Task DeleteMaterialssAsync(int id) =>
            await _httpClient.DeleteAsync($"api/materials/{id}");

    }
}
