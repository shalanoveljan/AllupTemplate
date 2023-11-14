using System.ComponentModel.DataAnnotations;

namespace Allup_Template.Models
{
    public class Setting
    {

        public int Id { get; set; }
        [StringLength(10000)]
        public string Key { get; set; }
        [StringLength(10000)]

        public string Value { get; set; }

    }
}
