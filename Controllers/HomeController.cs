using Allup_Template.DataAccessLayer;
using Allup_Template.Models;
using Allup_Template.ViewModels.HomeVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Allup_Template.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories=await _context.Categories.Where(c=>c.IsMain==true && c.IsDeleted==false).ToListAsync();

            HomeVM homevm = new HomeVM
            {
                Categories = categories,
                NewArrivals = await _context.Products.Where(p => p.IsDeleted == false && p.IsNewArrival == true).ToListAsync(),
                BestSellers = await _context.Products.Where(p => p.IsDeleted == false && p.IsBestSeller == true).ToListAsync(),
                Features = await _context.Products.Where(p => p.IsDeleted == false && p.IsFeatured == true).ToListAsync(),
                Sliders=await _context.Sliders.Where(s=>s.IsDeleted== false).ToListAsync()

            };
            return View(homevm);
        }
    }
}
