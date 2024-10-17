using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSerivceReal.Models;

namespace ProductSerivceReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Phone", Price = 800 }
        };

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
    }
}
