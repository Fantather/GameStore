using GameStore.Models;

namespace GameStore.ViewModels
{
    public record class InlineCreatorViewModel(IEnumerable<Category> Categories)
    {
        public Product Product { get; init; } = new();
    }
}
