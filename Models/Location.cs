using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex.Models
{
    public partial class Location
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }
        [Required]
        public string BurialLocationNs { get; set; }
        [Required]
        public int LowValueNs { get; set; }
        [Required]
        public int HighValueNs { get; set; }
        [Required]
        public string BurialLocationEw { get; set; }
        [Required]
        public int LowValueEw { get; set; }
        [Required]
        public int HighValueEw { get; set; }
    }
}
