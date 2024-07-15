using Pinewood_App_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Pinewood_App_API.Data
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CustomerDb");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}