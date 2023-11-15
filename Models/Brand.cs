using System.ComponentModel.DataAnnotations;

namespace Allup_Template.Models
{
    public class Brand:BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }
    }
}
