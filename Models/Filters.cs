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
            FilterString = filterstring ?? "all-all-all-all";
            string[] filters = FilterString.Split('-');
            HairColor = filters[0];
            BurialDirection = filters[1];
            Gender = filters[2];
            Age = filters[3];



        }

        public string FilterString { get; }
        public string HairColor { get; }
        public string BurialDirection { get; }
        public string Gender { get; }
        public string Age { get; }
        



        public bool HasHairColor => HairColor.ToLower() != "all";
       // public bool HasBurialDepth => BurialDepth.ToLower() != "all";

        public bool HasBurialDirection => BurialDirection.ToLower() != "all";
        public bool HasGender => Gender.ToLower() != "all";
        public bool HasAge => Age.ToLower() != "all";



    }
}
