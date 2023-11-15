using Allup_Template.Models;

namespace Allup_Template.ViewModels.HomeVMs
{
    public class HomeVM
    {
        public IEnumerable<Category> Categories { get; set; }   
        public IEnumerable<Product> Features { get; set;}
        public IEnumerable<Product> BestSellers { get; set;}
        public IEnumerable<Product> NewArrivals { get; set; }

    }
}
