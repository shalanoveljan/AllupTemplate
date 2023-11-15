using System.ComponentModel.DataAnnotations;

namespace Allup_Template.Models
{
    public class Tag:BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }
    }
}
