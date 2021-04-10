using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex.Models
{
    public partial class FieldBookEntry
    {
        [Key]
        [Required]
        public int BurialId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public string PageNumber { get; set; }
        public string DataEntryExpertInitials { get; set; }
        public string DataEntryCheckerInitials { get; set; }
    }
}
