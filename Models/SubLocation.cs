using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex.Models
{
    public partial class SubLocation
    {
        [Key]
        [Required]
        public int SublocationId { get; set; }
        public string Subplot { get; set; }
        public int? AreaNumber { get; set; }
        public string TombNumber { get; set; }
    }
}
