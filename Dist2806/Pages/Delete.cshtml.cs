using Dist2806.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dist2806.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ApiService _apiService;
        public Materialss Material { get; set; }

        public DeleteModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            Material = await _apiService.GetMaterialssAsync(id);
            if (Material == null)
                return NotFound();
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            _apiService.DeleteMaterialssAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
