using Newtonsoft.Json;

namespace Pinewood_App_API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dob { get; set; }
        public string Postcode { get; set; }
        public string Telephone { get; set; }
    }
}
