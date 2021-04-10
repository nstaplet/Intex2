using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models
{
    public class Filters
    {


        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all";
            string[] filters = FilterString.Split('-');
            HairColor = filters[0];
            //BurialDirection = filters[1];



        }

        public string FilterString { get; }
        public string HairColor { get; }
       // public string BurialDirection { get; }



        public bool HasHairColor => HairColor.ToLower() != "all";
      //  public bool HasBurialDirection => BurialDirection.ToLower() != "all";

    }
}
