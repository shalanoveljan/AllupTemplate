using Allup_Template.DataAccessLayer;
using Allup_Template.Interfaces;
using Allup_Template.Models;
using Microsoft.EntityFrameworkCore;

namespace Allup_Template.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
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
