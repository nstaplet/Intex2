using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex.Models
{
    public partial class FieldBook
    {
        [Key]
        [Required]
        public int BookId { get; set; }
        [Required]
        public string BookNumber { get; set; }
    }
}
