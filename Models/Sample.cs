using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex.Models
{
    public partial class Sample
    {
        [Required]
        public int BurialId { get; set; }
        [Key]
        [Required]
        public int SampleId { get; set; }
        public int? SampleRackNumber { get; set; }
        public int? SampleBagNumber { get; set; }
        public int? SampleDateYear { get; set; }
        public int? SampleDateMonth { get; set; }
        public int? SampleDateDay { get; set; }
        public bool? PreviouslySampled { get; set; }
        public string SampleNotes { get; set; }
        public string InitialsForSample { get; set; }
    }
}
