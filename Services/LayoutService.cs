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
        public async Task<IDictionary<string,string>> GetSettingsAsync()
        {
           Dictionary<string,string> setting= await _context.settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);

            return setting;
        }
    }
}
