using GameStore.Models;

namespace GameStore.ViewModels
{
    public record class HomeIndexViewModel(IEnumerable<Product> Products, IEnumerable<Category> Categories);
}
