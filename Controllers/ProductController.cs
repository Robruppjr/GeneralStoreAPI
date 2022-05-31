using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GenrealStoreAPI.Data;
using GenrealStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace GenrealStoreAPI.Data
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private GeneralStoreDBContext _db;
        public ProductController(GeneralStoreDBContext db) {
            _db = db;
        }
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]ProductEdit newProduct) {
            Product product = new Product() {
                Name = newProduct.Name,
                Price = newProduct.Price,
                QuantityInStock = newProduct.Quantity,
            };

            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts() {
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }
    }
}
