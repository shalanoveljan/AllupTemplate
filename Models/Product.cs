using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Allup_Template.Models
{
    public class Product:BaseEntity
    {
        [StringLength(255)]
        public string Title { get; set; }
        [Column(TypeName ="money")]

        public double Price { get; set; }
        [Column(TypeName = "smallmoney")]


        public double DiscountPrice { get; set; }
        [Column(TypeName = "money")]


        public double ExTax { get; set; }
        [Range(0,int.MaxValue)]
        public int Count { get; set; }
        [StringLength(255)]

        public string SmallDescription { get; set; }
        [StringLength(10000)]

        public string Description { get; set; }
        [StringLength(10000)]


        public string MainImage { get; set; }
        [StringLength(255)]

        public string HoverImage { get; set; }
        [StringLength(4, MinimumLength = 4)]

        public string Seria { get; set; }
            [Range(1, int.MaxValue)]
            public int Code { get; set; }

        public bool IsNewArrival { get; set; }

        public bool IsBestSeller { get; set; }

        public bool IsFeatured { get; set; }

        public int? BrandId { get; set; }

        public Brand? Brand { get; set; }

        public int? CategoryId { get; set; }

        public Category? Category { get; set;}


    }
}
