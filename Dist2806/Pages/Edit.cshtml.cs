using Dist2806.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dist2806.Pages
{
    public class EditModel : PageModel
    {

        private readonly ApiService _apiService;
        [BindProperty]
        public Materialss Material { get; set; }
        public EditModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult OnGet(int id)
        {
            Material = _apiService.GetMaterialssAsync(id).Result;
            if (Material == null)
                return NotFound();

            return Page();
        }
        
        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
                return Page();
            _apiService.UpdateMaterialssAsync(id, Material);
            return RedirectToPage("./Index");
        }
    }
}
