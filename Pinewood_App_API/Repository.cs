using Pinewood_App_API.Data;
using Pinewood_App_API.Models;

namespace Pinewood_App_API
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository()
        {
            //using (var context = new ApiContext())
            //{
            //    if (context.Customers.Count() <= 0)
            //    {
            //        var customers = new List<Customer>
            //        {
            //            new Customer
            //            {
            //                FirstName ="Earnest",
            //                LastName ="Hemingway",
            //                Id = 1,
            //                Dob ="12/12/1987",
            //                Postcode = "MK17 5RT",
            //                Telephone = "676544245",
            //                Title = "Mr"
            //            },
            //             new Customer
            //            {
            //                FirstName ="Pauline",
            //                LastName ="Wells",
            //                Id = 2,
            //                Dob ="08/03/1997",
            //                Postcode = "MK3 2UQ",
            //                Telephone = "86522244",
            //                Title = "Mrs"
            //            }
            //        };
            //        context.Customers.AddRange(customers);
            //        context.SaveChanges();
            //    }
            //}
        }
        public List<Customer> GetCustomers()
        {
            using (var context = new ApiContext())
            {
                var list = context.Customers
                    .ToList();
                return list;
            }
        }

        public Customer AddCustomer(Customer cust)
        {
            using (var context = new ApiContext())
            {
                //get next id
                var maxId = context.Customers.DefaultIfEmpty().Max(r => r == null ? 0 : r.Id);
                cust.Id = maxId + 1;
                context.Customers.AddRange(cust);
                context.SaveChanges();
                return cust;
            }
        }

        public Customer? GetCustomer(int id)
        {
            using (var context = new ApiContext())
            {
                Customer? customer = context.Customers.FirstOrDefault((p) => p.Id == id);
                return customer;
            }
        }

        public Customer? UpdateCustomer(Customer editedCustomer)
        {
            using (var context = new ApiContext())
            {
                Customer? curCustomer = context.Customers.FirstOrDefault((p) => p.Id == editedCustomer.Id);
                if (curCustomer != null)
                {
                    curCustomer.Title = editedCustomer.Title;
                    curCustomer.Telephone = editedCustomer.Telephone;
                    curCustomer.FirstName = editedCustomer.FirstName;
                    curCustomer.LastName = editedCustomer.LastName;
                    curCustomer.Postcode = editedCustomer.Postcode;
                    curCustomer.Dob = editedCustomer.Dob;
                }
                context.SaveChanges();
                return curCustomer;
            }
        }

        public bool DeleteCustomer(int id)
        {
            using (var context = new ApiContext())
            {
                Customer? cust = context.Customers
                    .Where(c => c.Id == id)
                    .FirstOrDefault();

                if(cust != null)
                {
                    context.Customers.Remove(cust);
                    context.SaveChanges();
                }
            }


            //var contact = await _context.Customer.FindAsync(id);

            //if (contact != null)
            //{
            //    _context.Customer.Remove(contact);
            //    await _context.SaveChangesAsync();
            //}

            return true;
        }
    }
}

public interface ICustomerRepository
{
    public List<Customer> GetCustomers();
    public Customer? GetCustomer(int id);
    public Customer? AddCustomer(Customer newCustomer);
    public Customer? UpdateCustomer(Customer newCustomer);
    public bool DeleteCustomer(int id);
}