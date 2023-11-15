﻿using System.ComponentModel.DataAnnotations;

namespace Allup_Template.Models
{
    public class Category:BaseEntity
    {
        [StringLength(255)]

        public string Name { get; set; }
        [StringLength(255)]


        public string? Image { get; set; }

        public bool IsMain { get; set; }

        public int? ParentId { get; set; }
        public Category? Parent { get; set; }

        public IEnumerable<Category>? Children { get; set; }
    }
}
