using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pinewood_App_Service.Models;
using Pinewood_App_Service.Services;

namespace Pinewood_App.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public void OnGet(int id)
        {
            Pinewood_App_Service.Services.DataService dataService = new DataService();
            Customer = dataService.GetCustomer(id).Result;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Pinewood_App_Service.Services.DataService dataService = new DataService();
            bool result = await dataService.UpdateCustomer(Customer);

            return RedirectToPage("./Index");
        }
    }
}
