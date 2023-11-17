using Allup_Template.Models;

namespace Allup_Template.ViewModels.ShopVMs
{
    public class ShopVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public Category? SelectedCategory { get; set; }  

    }
}
