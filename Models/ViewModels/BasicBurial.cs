using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models.ViewModels
{
    public class BasicBurial
    {
        public Burial SingleBurial { get; set; }
        public Location SingleLocation { get; set; }

        public SubLocation SingleSublocation { get; set; }

        public Image? SingleImage { get; set; }
        
    }
}
