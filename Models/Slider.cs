using System.ComponentModel.DataAnnotations;

namespace Allup_Template.Models
{
    public class Slider:BaseEntity
    {
        [StringLength(1000)]
        public string Image { get; set; }
        [StringLength(1000)]


        public string Sub_Title { get; set; }
        [StringLength(1000)]

        public string Main_Title { get; set; }
        [StringLength(1000)]


        public string Description { get; set; }
        [StringLength(255)]

        public string Url { get; set; }

    }
}
