using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pinewood_App_Service.Models;
using Pinewood_App_Service.Services;

namespace Pinewood_App.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;
    public List<Customer> Customers { get; set; } = default!;
    
    public IndexModel(ILogger<IndexModel> logger)
    {
      _logger = logger;
    }

    public void OnGet()
    {
        List<Customer> customers = new List<Customer>();
        Pinewood_App_Service.Services.DataService dataService= new DataService();
        customers = dataService.GetCustomers();
        Customers = customers;
    }
  }
}

