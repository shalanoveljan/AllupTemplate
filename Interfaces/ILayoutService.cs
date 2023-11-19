using Allup_Template.Models;
using Allup_Template.ViewModels.BasketVMs;

namespace Allup_Template.Interfaces
{
    public interface ILayoutService
    {

        Task<IDictionary<string, string>> GetSettingsAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<BasketVM>> GetBasketAsync();
    }
}
