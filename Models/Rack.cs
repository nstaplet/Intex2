using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex.Models
{
    public partial class Rack
    {
        [Key]
        [Required]
        public int RackId { get; set; }
        [Required]
        public string RackNumber { get; set; }
    }
}
