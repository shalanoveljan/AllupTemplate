using Allup_Template.Models;
using System.Security.Policy;

namespace Allup_Template.ViewModels.HomeVMs
{
    public class HomeVM
    {
        public IEnumerable<Category> Categories { get; set; }   

        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Product> Features { get; set;}
        public IEnumerable<Product> BestSellers { get; set;}
        public IEnumerable<Product> NewArrivals { get; set; }

    }
}
