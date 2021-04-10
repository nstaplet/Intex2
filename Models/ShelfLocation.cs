using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex.Models
{
    public partial class ShelfLocation
    {
        [Key]
        [Required]
        public int ShelflocationId { get; set; }
        [Required]
        public int RackId { get; set; }
        [Required]
        public int BurialId { get; set; }
        [Required]
        public string ShelfNumber { get; set; }
    }
}
