using GameStore.Models;

namespace GameStore.ViewModels
{
    public class UpdateRangeProductsViewModel(IEnumerable<Product> products, IEnumerable<Category> categories)
    {
        public List<Product> Products { get; init; } = products.ToList();
        public IEnumerable<Category> Categories { get; init; } = categories;
    }
}
