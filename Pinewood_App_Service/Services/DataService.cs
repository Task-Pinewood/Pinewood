using Pinewood_App_Service.Models;
using Newtonsoft.Json;

namespace Pinewood_App_Service.Services
{
  public class DataService
  {
    public List<Customer> GetCustomers()
    {
      HttpClient client = new HttpClient();
      List<Customer> customers = new List<Customer>();
      var task = client.GetAsync("https://localhost:7241/api/Customer");
      HttpResponseMessage message = task.Result;

      if (message.IsSuccessStatusCode)
      {
        Task<string> str = message.Content.ReadAsStringAsync();
        string jsonstring = str.Result;
        customers = Customer.FromJson(jsonstring);
      }

      return customers;
    }

 
    public async Task<Customer> GetCustomer(int id)
    {
        Customer cust = new Customer();

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://localhost:7241/api/Customer");

            //HTTP GET
            var responseTask = client.GetAsync("Customer/" + id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                cust = JsonConvert.DeserializeObject<Customer>(await result.Content.ReadAsStringAsync()) ?? new Customer();
            }
        }

        return cust;
    }

    public async Task<bool> AddCustomer(Customer cust)
    {
        bool result = false;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://localhost:7241/api/Customer");

            Pinewood_App_API.Models.Customer apiCust = MapServiceToApiCustomer(cust);

            var response = client.PostAsJsonAsync<Pinewood_App_API.Models.Customer>("Customer", apiCust);
            await response;

            var message = response.Result;
            if (message.IsSuccessStatusCode)
            {
                result = true;
            }
        }

        return result;
    }

    public async Task<bool> UpdateCustomer(Customer editedCust)
    {
        bool result = false;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://localhost:7241/api/Customer");

            Pinewood_App_API.Models.Customer apiCust = MapServiceToApiCustomer(editedCust);

            var response = client.PutAsJsonAsync<Pinewood_App_API.Models.Customer>("Customer", apiCust);
            await response;

            var message = response.Result;
            if (message.IsSuccessStatusCode)
            {
                result = true;
            }
        }

        return result;
    }

    public async Task<bool> DelteCustomer(int id)
    {
        bool result = false;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://localhost:7241/api/Customer");

            var response = client.DeleteAsync("Customer/" + id.ToString());
            await response;
            var message = response.Result;
            if (message.IsSuccessStatusCode)
            {
                result = true;
            }
        }

        return result;
    }

    private Pinewood_App_API.Models.Customer MapServiceToApiCustomer(Pinewood_App_Service.Models.Customer customer)
    {
        Pinewood_App_API.Models.Customer apiCustomer = new Pinewood_App_API.Models.Customer()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Dob = customer.Dob,
            Postcode = customer.Postcode,
            Telephone = customer.Telephone,
            Title = customer.Title,
            Id = customer.Id
        };
        return apiCustomer;
    }

    private Pinewood_App_Service.Models.Customer MapApiToServiceCustomer(Pinewood_App_API.Models.Customer customer)
    {
        Pinewood_App_Service.Models.Customer servCustomer = new Models.Customer()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Dob = customer.Dob,
            Postcode = customer.Postcode,
            Telephone = customer.Telephone,
            Title = customer.Title,
            Id = customer.Id
        };
        return servCustomer;
    }
  }
}