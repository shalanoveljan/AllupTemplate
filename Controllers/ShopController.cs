using Allup_Template.DataAccessLayer;
using Allup_Template.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Allup_Template.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(int? categoryId, string search)
        {
            if (categoryId == null)
            {
                if (!await _context.Categories.AnyAsync(c => c.IsDeleted == false && c.Id == categoryId))
                {
                    return BadRequest("Category Is Incorrect ");

                }
            }

            search = search.Trim().ToLower();

            List<Product> products = await _context.Products
                .Where(p => (categoryId != null ? p.CategoryId == categoryId : true) && p.IsDeleted == false &&
                 (
                p.Title.ToLower().Contains(search) ||
                p.Brand.Name.ToLower().Contains(search)
                ))
                 .ToListAsync();
            return Ok(products);










        }
    }
}
