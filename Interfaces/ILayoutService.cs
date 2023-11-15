using Allup_Template.Models;

namespace Allup_Template.Interfaces
{
    public interface ILayoutService
    {

        Task<IDictionary<string, string>> GetSettingsAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
