using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pinewood_App_Service.Models;
using Pinewood_App_Service.Services;

namespace Pinewood_App.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Pinewood_App_Service.Services.DataService dataService = new DataService();
            bool result = await dataService.AddCustomer(Customer);

            return RedirectToPage("./Index");
        }
    }
}
