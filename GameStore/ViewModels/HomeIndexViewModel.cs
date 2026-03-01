using GameStore.Models;
using GameStore.Models.Pages;

namespace GameStore.ViewModels
{
    public record class HomeIndexViewModel(PagedList<Product> Products, IEnumerable<Category> Categories)
    {
        public InlineCreatorViewModel InlineCreatorViewModel { get; init; } = new(Categories); 
    }
}
