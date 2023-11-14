using Allup_Template.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Allup_Template.DataAccessLayer
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

      public  DbSet<Setting> settings { get; set; }
    }
}
