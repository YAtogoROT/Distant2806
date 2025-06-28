using Dist2806.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dist2806.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly ApiService _apiService;
    public List<Materialss> Material { get; set; } = new();

    public IndexModel(ApiService apiService) => _apiService = apiService;

    public async Task OnGetAsync() => Material = await _apiService.GetMaterialssAsync();

}
