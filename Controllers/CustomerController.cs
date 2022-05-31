using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GenrealStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace GenrealStoreAPI.Data
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private GeneralStoreDBContext _db;
        public CustomerController(GeneralStoreDBContext db) {
            _db = db;
        }
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromForm] CustomerEdit newCustomer) {
            Customer customer = new Customer() {
                Name = newCustomer.Name,
                Email = newCustomer.Email,
            };

            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers() {
            var customers = await _db.Customers.ToListAsync();
            return Ok(customers);
        }
    }
}
