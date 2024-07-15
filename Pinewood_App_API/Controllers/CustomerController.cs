using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Pinewood_App_API.Models;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinewood_App_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        //// GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {

            return Ok(_customerRepository.GetCustomers());
        }


        [HttpGet("{id}")]
        //[HttpGet("getCustomer/{id}")]
        //[HttpGet("{id}")]
        //[Route("getCustomer/{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            Customer?  cust = _customerRepository.GetCustomer(id);
            //Pinewood_App_Service.Models.Customer cust = new Pinewood_App_Service.Models.Customer();
            if (cust == null)
            {
                return NotFound();
            }

            return Ok(cust);
            
        }


        //[Route("addPerson")]
        [HttpPost]
        public ActionResult<Customer> PostNewCustomer(Customer cust)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            Customer? outcust = _customerRepository.AddCustomer(cust);

            return Ok(outcust);
        }

        [HttpPut]
        public ActionResult<Customer> PutUpdateCustomer(Customer cust)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            Customer? outcust = _customerRepository.UpdateCustomer(cust);

            return Ok(outcust);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid data.");

            bool result = _customerRepository.DeleteCustomer(id);

            return Ok(result);
        }
    }
}


//// GET: api/Car/5
//[HttpGet("{id}", Name = "Get")]
//public Car Get(int id)
//{
//    return _carService.Read(id);
//}
//// POST: api/Car
//[HttpPost]
//public void Post([FromBody] Car car)
//{
//    _carService.Create(car);
//}
//// PUT: api/Car/5
//[HttpPut("{id}")]
//public void Put(int id, [FromBody] Car car)
//{
//    _carService.Update(car);
//}
//// DELETE: api/ApiWithActions/5
//[HttpDelete("{id}")]
//public void Delete(int id)
//{
//    _carService.Delete(id);
//}