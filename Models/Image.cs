using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex.Models
{
    public partial class Image
    {
        [Key]
        [Required]
        public int ImageId { get; set; }
        [Required]
        public int BurialId { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
