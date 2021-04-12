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
            FilterString = filterstring ?? "all-all-all-all-0-10-all-null-all";
            string[] filters = FilterString.Split('-');
            HairColor = filters[6];
            BurialDirection = filters[1];
            Gender = filters[2];
            Age = filters[3];
            DepthMin = Convert.ToDouble(filters[4]);
            DepthMax = Convert.ToDouble(filters[5]);
            Location = filters[0];
            if (filters[7] == "True" || filters[7] == "False")
            {
                Sample = Convert.ToBoolean(filters[7]);

            }









        }

        public string FilterString { get; }
        public string HairColor { get; }
        public string BurialDirection { get; }
        public string Gender { get; }
        public string Age { get; }
        public double DepthMax { get; }
        public double DepthMin {get; }
        public string Location { get; }
        public bool? Sample { get; }






        public bool HasHairColor => HairColor.ToLower() != "all";

        public bool HasBurialDirection => BurialDirection.ToLower() != "all";
        public bool HasGender => Gender.ToLower() != "all";
        public bool HasAge => Age.ToLower() != "all";
        public bool HasMinDepth => DepthMin != 0;
        public bool HasMaxDepth => DepthMax != 10;
        public bool HasLocation => Location.ToLower() != "all";
        public bool HasSample => Sample != null;





    }
}
