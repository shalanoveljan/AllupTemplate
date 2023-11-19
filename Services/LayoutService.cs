using Allup_Template.DataAccessLayer;
using Allup_Template.Interfaces;
using Allup_Template.Models;
using Allup_Template.ViewModels.BasketVMs;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Allup_Template.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;


        public LayoutService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<IEnumerable<BasketVM>> GetBasketAsync()
        {
            string? cookie = _contextAccessor.HttpContext.Request.Cookies["basket"];
            List<BasketVM>? basketVMs = null;

            if(!string.IsNullOrWhiteSpace(cookie))
            {
                basketVMs=JsonConvert.DeserializeObject<List<BasketVM>>(cookie);

            }

            else
            {
                basketVMs=new List<BasketVM>();
            }

            foreach (BasketVM basketVM in basketVMs)
            {
                Product? product = await _context.Products.FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == basketVM.ProductID);

                basketVM.Title = product.Title;
                basketVM.Price = product.DiscountPrice > 0 ? product.DiscountPrice : product.Price;
                basketVM.Image = product.MainImage;
                basketVM.Extax = product.ExTax;



             }
            return basketVMs;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            List<Category> categories=await _context.Categories
                .Include(c=>c.Children.Where(ch=>ch.IsDeleted==false))
                .Where(ch=>ch.IsDeleted==false && ch.IsMain==true)
                .ToListAsync();

            return categories;
        }   

        public async Task<IDictionary<string,string>> GetSettingsAsync()
        {
           Dictionary<string,string> setting= await _context.settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);

            return setting;
        }
    }
}
