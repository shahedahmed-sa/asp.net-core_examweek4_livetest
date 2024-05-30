/*  Exam Week -4: Live Exam
 
    Kazi Shahed Ahmed

    Asp.Net Core Batch-1
 
 */
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ostadproduct.Controllers
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> ImageUrls { get; set; }
        public string Category { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Product 1",
                Description = "Description for product 1",
                Price = 10.99M,
                ImageUrls = new List<string>
                {
                    "https://example.com/images/product1/image1.jpg",
                    "https://example.com/images/product1/image2.jpg"
                },
                Category = "Category1"
            },
            new Product
            {
                Id = 2,
                Name = "Product 2",
                Description = "Description for product 2",
                Price = 20.99M,
                ImageUrls = new List<string>
                {
                    "https://example.com/images/product2/image1.jpg",
                    "https://example.com/images/product2/image2.jpg"
                },
                Category = "Category2"
            }
          
        };

        // Endpoint with a mandatory parameter
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // Endpoint with an optional parameter
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProductsByCategory([FromQuery] string category = null)
        {
            if (string.IsNullOrEmpty(category))
            {
                return Ok(products);
            }
            var filteredProducts = products.FindAll(p => p.Category == category);
            return Ok(filteredProducts);
        }
    }
}
