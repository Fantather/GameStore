using GameStore.Data;
using GameStore.Interfaces;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Repositories
{
    public class ProductRepository : IProduct
    {
        private ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products
            .Where(productToUpdate => productToUpdate.Id == product.Id)
            .ExecuteUpdate(setters => setters
                .SetProperty(productToUpdate => productToUpdate.Name, product.Name)
                .SetProperty(productToUpdate => productToUpdate.Category, product.Category)
                .SetProperty(productToUpdate => productToUpdate.RetailPrice, product.RetailPrice)
                .SetProperty(productToUpdate => productToUpdate.PurchasePrice, product.PurchasePrice)
        );
        }

        public void UpdateAll(Product[] products)
        {
            Dictionary<int, Product> data = products.ToDictionary(e => e.Id);
            IEnumerable<Product> baseline = _context.Products.Where(e => data.Keys.Contains(e.Id));
            foreach (Product product in baseline)
            {
                Product requestProduct = data[product.Id];
                product.Name = requestProduct.Name;
                product.Category = requestProduct.Category;
                product.RetailPrice = requestProduct.RetailPrice;
                product.PurchasePrice = requestProduct.PurchasePrice;
            }
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

    }
}
