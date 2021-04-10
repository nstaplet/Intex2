using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models
{
    public class JoinedDataViewModel
    {
        public int BurialId { get; set; }
        public int LocationId { get; set; }
        public int SublocationId { get; set; }
        public int BurialNumber { get; set; }
        public double? BurialDepthMeters { get; set; }
        public double? SouthToHead { get; set; }
        public double? SouthToFeet { get; set; }
        public double? WestToHead { get; set; }
        public double? WestToFeet { get; set; }
        public string BurialSituationNotes { get; set; }
        public string BurialPreservationNotes { get; set; }
        public string BurialWrapping { get; set; }
        public double? LengthOfRemains { get; set; }
        public int? SampleNumber { get; set; }
        public string SexBySkull { get; set; }
        public string GenderCode { get; set; }
        public string BurialGenderMethod { get; set; }
        public string GenderGe { get; set; }
        public double? GeFunctionTotal { get; set; }
        public string GenderBodyCol { get; set; }
        public string BasilarSuture { get; set; }
        public int? VentralArc { get; set; }
        public int? SubpubicAngle { get; set; }
        public int? SciaticNotch { get; set; }
        public int? PubicBone { get; set; }
        public int? PreaurSulcus { get; set; }
        public int? MedialIpRamus { get; set; }
        public int? DorsalPitting { get; set; }
        public string ForemanMagnum { get; set; }
        public double? FemurHead { get; set; }
        public double? HumerusHead { get; set; }
        public string Osteophytosis { get; set; }
        public string PubicSymphysis { get; set; }
        public double? BoneLength { get; set; }
        public double? MedialClavicle { get; set; }
        public double? IliacCrest { get; set; }
        public double? FemurDiameter { get; set; }
        public double? Humerus { get; set; }
        public double? FemurLength { get; set; }
        public double? HumerusLength { get; set; }
        public double? TibiaLength { get; set; }
        public int? Robust { get; set; }
        public int? SupraorbitalRidges { get; set; }
        public int? OrbitEdge { get; set; }
        public int? ParietalBossing { get; set; }
        public int? Gonian { get; set; }
        public int? NuchalCrest { get; set; }
        public int? ZygomaticCrest { get; set; }
        public string CranialSuture { get; set; }
        public double? MaximumCranialLength { get; set; }
        public double? MaximumCranialBreadth { get; set; }
        public double? BasionBregmaHeight { get; set; }
        public double? BasionNasion { get; set; }
        public double? BasionProsthionLength { get; set; }
        public double? BizygomaticDiameter { get; set; }
        public double? NasionProsthion { get; set; }
        public double? MaximumNasalBreadth { get; set; }
        public double? InterorbitalBreadth { get; set; }
        public string ArtifactsDescription { get; set; }
        public string HairColorCode { get; set; }
        public string HairColor { get; set; }
        public string PreservationIndex { get; set; }
        public bool? HairTaken { get; set; }
        public bool? SoftTissueTaken { get; set; }
        public bool? BoneTaken { get; set; }
        public bool? ToothTaken { get; set; }
        public bool? TextileTaken { get; set; }
        public string DescriptionOfTaken { get; set; }
        public bool? ArtifactFound { get; set; }
        public string EstimateAgeAtDeath { get; set; }
        public string BurialAgeMethod { get; set; }
        public string AgeCodeSingle { get; set; }
        public string BurialAdultChild { get; set; }
        public string AgeSkull { get; set; }
        public double? EstimateLivingStature { get; set; }
        public string ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathologyAnomalies { get; set; }
        public string EpiphysealUnion { get; set; }
        public int? YearExcavated { get; set; }
        public int? MonthExcavated { get; set; }
        public int? DayExcavated { get; set; }
        public string BurialDirection { get; set; }
        public int? YearOnSkull { get; set; }
        public int? MonthOnSkull { get; set; }
        public int? DayOnSkull { get; set; }
        public bool? SkullTrauma { get; set; }
        public bool? PostcraniaTrauma { get; set; }
        public bool? CribraOrbitala { get; set; }
        public string PoroticHyperostosis { get; set; }
        public string PoroticHyperostosisLocations { get; set; }
        public string MetopicSuture { get; set; }
        public bool? ButtonOsteoma { get; set; }
        public string OsteologyUnknownComment { get; set; }
        public bool? TemporalMandibularJointOsteoarthritis { get; set; }
        public bool? LinearHypoplasiaEnamel { get; set; }
        public string OsteologyNotes { get; set; }
        public bool? SkullAtMagazine { get; set; }
        public bool? PostcraniaAtMagazine { get; set; }
        public bool? BurialSampleTaken { get; set; }
        public string BodyAnalysis { get; set; }
        public bool? ToBeConfirmed { get; set; }
        public bool? Goods { get; set; }
        public int? RackNumber14c { get; set; }
        public int? TubeNumber { get; set; }
        public string Description14c { get; set; }
        public double? SizeInMl { get; set; }
        public double? Foci { get; set; }
        public string Location14c { get; set; }
        public string Conventional14cAge { get; set; }
        public string Calendar14cDate { get; set; }
        public string Calibrated95Datemax { get; set; }
        public string Calibrated95Datemin { get; set; }
        public string Calibrated95Datespan { get; set; }
        public string Calibrated95Dateavg { get; set; }
        public string AreaCategory14c { get; set; }
        public bool? Discrepency14c { get; set; }
        public string LabNotes14c { get; set; }
        public bool? PhotoTaken { get; set; }
        //location
        public string BurialLocationNs { get; set; }
        
        public int LowValueNs { get; set; }
        
        public int HighValueNs { get; set; }
        
        public string BurialLocationEw { get; set; }
        
        public int LowValueEw { get; set; }
        
        public int HighValueEw { get; set; }

        //sub location
        public string Subplot { get; set; }
        public int? AreaNumber { get; set; }
        public string TombNumber { get; set; }
    }
}
