using Dist2806.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dist2806.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public Materialss Material { get; set; } = new();

        public CreateModel(ApiService apiService) => _apiService = apiService;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            await _apiService.AddMaterialssAsync(Material);
            return RedirectToPage("./Index");
        }
    }
}
