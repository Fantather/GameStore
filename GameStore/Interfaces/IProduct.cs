using GameStore.Models;

namespace GameStore.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        void UpdateProduct(Product product);
        void AddProduct(Product product);
        void UpdateAll(Product[] products);
        void DeleteProduct(Product product);
    }
}
