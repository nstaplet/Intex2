using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex.Models
{
    public partial class Location
    {
        public int LocationId { get; set; }
        public string BurialLocationNs { get; set; }
        public int LowValueNs { get; set; }
        public int HighValueNs { get; set; }
        public string BurialLocationEw { get; set; }
        public int LowValueEw { get; set; }
        public int HighValueEw { get; set; }
    }
}
