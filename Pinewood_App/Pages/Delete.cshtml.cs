using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pinewood_App_Service.Services;

namespace Pinewood_App.Pages
{
    public class DeleteModel : PageModel
    {
        public async Task OnGetAsync(int id)
        {
            Pinewood_App_Service.Services.DataService dataService = new DataService();
            await dataService.DelteCustomer(id);
        }
    }
}
