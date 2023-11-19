using Allup_Template.DataAccessLayer;
using Allup_Template.Models;
using Allup_Template.ViewModels.ShopVMs;
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

        public async Task<IActionResult> Index(int? categoryId,int pageIndex=1)
        {
            Category category = null;
            if (categoryId != null)
            {
                 category = await _context.Categories.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == categoryId);
                if (category==null)
                {
                    categoryId= null;
                }
            }


            ShopVM shopVM = new ShopVM
            {
                Categories = await _context.Categories.Include(c => c.Children.Where(ch => ch.IsDeleted == false))
                .Where(c => c.IsMain == true && c.IsDeleted == false)
                .ToListAsync(),

                Products = await _context.Products
                .Where(p => (categoryId != null ? p.CategoryId == categoryId : true) && p.IsDeleted == false)
                .OrderByDescending(c => c.Id)
                .Skip((pageIndex - 1) * 12)
                .Take(12)
                .ToListAsync(),

                SelectedCategory = category

            };
            return View(shopVM);
        }

        public async Task<IActionResult> Search(int? categoryId, string search)
        {
            if (categoryId != null)
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
            return PartialView("_SearchPartial",products);









        }

        public async Task<IActionResult> Modal(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Product? product=await _context.Products
                .Include(p => p.productImages.Where(pi=>pi.IsDeleted==false))
                .FirstOrDefaultAsync(p=>p.IsDeleted==false && p.Id==id);

            if(product == null)
            {
                return BadRequest();

            }

                
            return PartialView("_ModalPartial",product);
        }
    }
}
