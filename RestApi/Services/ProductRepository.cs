using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Data;
using RestApi.Models;

namespace RestApi.Services
{
    public class ProductRepository : IProduct
    {

        ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public void AddProduct(Product product)
        {
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _productDbContext.Products.Find(id);
            if (product != null) _productDbContext.Remove(product);

            _productDbContext.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            var product = _productDbContext.Products.SingleOrDefault(p => p.ProductId == id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productDbContext.Products;
        }

        public void UpdateProduct(Product product)
        {
             _productDbContext.Products.Update(product);
            _productDbContext.SaveChanges();

        }
    }
}
