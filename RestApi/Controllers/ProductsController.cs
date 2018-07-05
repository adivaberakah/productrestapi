using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Data;
using RestApi.Models;
using RestApi.Services;

namespace RestApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        IProduct _product;
        public ProductsController(IProduct product)
        {
            _product = product;
        }
        // GET: api/Products //Sorting
        //[HttpGet] 
        //public IQueryable<Product> Get(string sortPrice)
        //{
        //    IQueryable<Product> products;
        //    switch (sortPrice)
        //    {
        //        case "desc":
        //            products = _productDbContext.Products.OrderByDescending(p => p.ProductPrice);
        //            break;
        //        case "asc":
        //            products = _productDbContext.Products.OrderBy(p => p.ProductPrice);
        //            break;
        //        default:
        //            products = _productDbContext.Products;
        //            break;
        //    }
        //    return products;
        //}
        //[HttpGet] // Pagination
        //public IQueryable<Product> Get(int? pageNumber, int? pageSize)
        //{
        //    int currentPage = pageNumber ?? 1;
        //    int currentPageSize = pageSize ?? 5;

        //    var products = from p in _productDbContext.Products.OrderBy(a => a.ProductId) select p;
        //    var items = products.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize);

        //    return (items);
        //}
        //[HttpGet] // Searching
        //public IQueryable<Product> Get(string searchProduct)
        //{
        //    var products = _productDbContext.Products.Where(p => p.ProductName.StartsWith(searchProduct) || p.ProductPrice.StartsWith(searchProduct));
           
        //    return (products);
        //}

        [HttpGet]
       // Searching
        public IEnumerable<Product> Get()
        {
            var products = _product.GetProducts();

            return (products);
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {

            var product = _product.GetProduct(id);
            if (product == null)
            {
                return NotFound("No contents");
            }
            return Ok(product);
       }
        
        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _product.AddProduct(product);
            return StatusCode(StatusCodes.Status201Created);
            
        }
        
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                _product.UpdateProduct(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return NotFound("No record found for this id");
            }
            return Ok("Product Updated ...");
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _product.GetProduct(id);
            if (product == null)
            {
                return NotFound("No record found");
            }

            _product.DeleteProduct(id);
            return Ok("Product Deleted");

        }
    }
}
