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
      public  DbSet<Category> Categories { get; set; }
      public  DbSet<Brand> Brands { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductImage> ProductImages  { get; set; }



    }
}
