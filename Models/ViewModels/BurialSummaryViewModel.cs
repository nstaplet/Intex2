using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models.ViewModels
{
    public class BurialSummaryViewModel
    {
        public IEnumerable<BasicBurial> Burials { get; set; }
        public PageNumbering pageNumbering { get; set; }
       
    }
}
