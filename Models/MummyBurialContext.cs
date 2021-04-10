using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex.Models
{
    public partial class MummyBurialContext : DbContext
    {
        public MummyBurialContext()
        {
        }

        public MummyBurialContext(DbContextOptions<MummyBurialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Burial> Burial { get; set; }
        public virtual DbSet<FieldBook> FieldBook { get; set; }
        public virtual DbSet<FieldBookEntry> FieldBookEntry { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Rack> Rack { get; set; }
        public virtual DbSet<Sample> Sample { get; set; }
        public virtual DbSet<ShelfLocation> ShelfLocation { get; set; }
        public virtual DbSet<SubLocation> SubLocation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=intex2db.copsytnjuzt1.us-east-1.rds.amazonaws.com;Database=MummyBurial;User Id=admin;Password=intex2-8;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burial>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AgeCodeSingle)
                    .HasColumnName("age_code_single")
                    .HasMaxLength(255);

                entity.Property(e => e.AgeSkull)
                    .HasColumnName("age_skull")
                    .HasMaxLength(255);

                entity.Property(e => e.AreaCategory14c)
                    .HasColumnName("area_category_14c")
                    .HasMaxLength(255);

                entity.Property(e => e.ArtifactFound).HasColumnName("artifact_found");

                entity.Property(e => e.ArtifactsDescription)
                    .HasColumnName("artifacts_description")
                    .HasMaxLength(255);

                entity.Property(e => e.BasilarSuture)
                    .HasColumnName("basilar_suture")
                    .HasMaxLength(255);

                entity.Property(e => e.BasionBregmaHeight).HasColumnName("basion_bregma_height");

                entity.Property(e => e.BasionNasion).HasColumnName("basion_nasion");

                entity.Property(e => e.BasionProsthionLength).HasColumnName("basion_prosthion_length");

                entity.Property(e => e.BizygomaticDiameter).HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.BodyAnalysis)
                    .HasColumnName("body_analysis")
                    .HasMaxLength(255);

                entity.Property(e => e.BoneLength).HasColumnName("bone_length");

                entity.Property(e => e.BoneTaken).HasColumnName("bone_taken");

                entity.Property(e => e.BurialAdultChild)
                    .HasColumnName("burial_adult_child")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialAgeMethod)
                    .HasColumnName("burial_age_method")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialDepthMeters).HasColumnName("burial_depth_meters");

                entity.Property(e => e.BurialDirection)
                    .HasColumnName("burial_direction")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialGenderMethod)
                    .HasColumnName("burial_gender_method")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.BurialNumber).HasColumnName("burial_number");

                entity.Property(e => e.BurialPreservationNotes)
                    .HasColumnName("burial_preservation_notes")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialSampleTaken).HasColumnName("burial_sample_taken");

                entity.Property(e => e.BurialSituationNotes).HasColumnName("burial_situation_notes");

                entity.Property(e => e.BurialWrapping)
                    .HasColumnName("burial_wrapping")
                    .HasMaxLength(255);

                entity.Property(e => e.ButtonOsteoma).HasColumnName("button_osteoma");

                entity.Property(e => e.Calendar14cDate)
                    .HasColumnName("calendar_14c_date")
                    .HasMaxLength(255);

                entity.Property(e => e.Calibrated95Dateavg)
                    .HasColumnName("calibrated_95_dateavg")
                    .HasMaxLength(255);

                entity.Property(e => e.Calibrated95Datemax)
                    .HasColumnName("calibrated_95_datemax")
                    .HasMaxLength(255);

                entity.Property(e => e.Calibrated95Datemin)
                    .HasColumnName("calibrated_95_datemin")
                    .HasMaxLength(255);

                entity.Property(e => e.Calibrated95Datespan)
                    .HasColumnName("calibrated_95_datespan")
                    .HasMaxLength(255);

                entity.Property(e => e.Conventional14cAge)
                    .HasColumnName("conventional_14C_age")
                    .HasMaxLength(255);

                entity.Property(e => e.CranialSuture)
                    .HasColumnName("cranial_suture")
                    .HasMaxLength(255);

                entity.Property(e => e.CribraOrbitala).HasColumnName("cribra_orbitala");

                entity.Property(e => e.DayExcavated).HasColumnName("day_excavated");

                entity.Property(e => e.DayOnSkull).HasColumnName("day_on_skull");

                entity.Property(e => e.Description14c)
                    .HasColumnName("description_14c")
                    .HasMaxLength(255);

                entity.Property(e => e.DescriptionOfTaken)
                    .HasColumnName("description_of_taken")
                    .HasMaxLength(255);

                entity.Property(e => e.Discrepency14c).HasColumnName("discrepency_14c");

                entity.Property(e => e.DorsalPitting).HasColumnName("dorsal_pitting");

                entity.Property(e => e.EpiphysealUnion)
                    .HasColumnName("epiphyseal_union")
                    .HasMaxLength(255);

                entity.Property(e => e.EstimateAgeAtDeath)
                    .HasColumnName("estimate_age_at_death")
                    .HasMaxLength(255);

                entity.Property(e => e.EstimateLivingStature).HasColumnName("estimate_living_stature");

                entity.Property(e => e.FemurDiameter).HasColumnName("femur_diameter");

                entity.Property(e => e.FemurHead).HasColumnName("femur_head");

                entity.Property(e => e.FemurLength).HasColumnName("femur_length");

                entity.Property(e => e.Foci).HasColumnName("foci");

                entity.Property(e => e.ForemanMagnum)
                    .HasColumnName("foreman_magnum")
                    .HasMaxLength(255);

                entity.Property(e => e.GeFunctionTotal).HasColumnName("ge_function_total");

                entity.Property(e => e.GenderBodyCol)
                    .HasColumnName("gender_body_col")
                    .HasMaxLength(255);

                entity.Property(e => e.GenderCode)
                    .HasColumnName("gender_code")
                    .HasMaxLength(255);

                entity.Property(e => e.GenderGe)
                    .HasColumnName("gender_GE")
                    .HasMaxLength(255);

                entity.Property(e => e.Gonian).HasColumnName("gonian");

                entity.Property(e => e.Goods).HasColumnName("goods");

                entity.Property(e => e.HairColor)
                    .HasColumnName("hair_color")
                    .HasMaxLength(255);

                entity.Property(e => e.HairColorCode)
                    .HasColumnName("hair_color_code")
                    .HasMaxLength(255);

                entity.Property(e => e.HairTaken).HasColumnName("hair_taken");

                entity.Property(e => e.Humerus).HasColumnName("humerus");

                entity.Property(e => e.HumerusHead).HasColumnName("humerus_head");

                entity.Property(e => e.HumerusLength).HasColumnName("humerus_length");

                entity.Property(e => e.IliacCrest).HasColumnName("iliac_crest");

                entity.Property(e => e.InterorbitalBreadth).HasColumnName("interorbital_breadth");

                entity.Property(e => e.LabNotes14c)
                    .HasColumnName("lab_notes_14c")
                    .HasMaxLength(255);

                entity.Property(e => e.LengthOfRemains).HasColumnName("length_of_remains");

                entity.Property(e => e.LinearHypoplasiaEnamel).HasColumnName("linear_hypoplasia_enamel");

                entity.Property(e => e.Location14c)
                    .HasColumnName("location_14c")
                    .HasMaxLength(255);

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MaximumCranialBreadth).HasColumnName("maximum_cranial_breadth");

                entity.Property(e => e.MaximumCranialLength).HasColumnName("maximum_cranial_length");

                entity.Property(e => e.MaximumNasalBreadth).HasColumnName("maximum_nasal_breadth");

                entity.Property(e => e.MedialClavicle).HasColumnName("medial_clavicle");

                entity.Property(e => e.MedialIpRamus).HasColumnName("medial_IP_ramus");

                entity.Property(e => e.MetopicSuture)
                    .HasColumnName("metopic_suture")
                    .HasMaxLength(255);

                entity.Property(e => e.MonthExcavated).HasColumnName("month_excavated");

                entity.Property(e => e.MonthOnSkull).HasColumnName("month_on_skull");

                entity.Property(e => e.NasionProsthion).HasColumnName("nasion_prosthion");

                entity.Property(e => e.NuchalCrest).HasColumnName("nuchal_crest");

                entity.Property(e => e.OrbitEdge).HasColumnName("orbit_edge");

                entity.Property(e => e.OsteologyNotes)
                    .HasColumnName("osteology_notes")
                    .HasMaxLength(255);

                entity.Property(e => e.OsteologyUnknownComment)
                    .HasColumnName("osteology_unknown_comment")
                    .HasMaxLength(255);

                entity.Property(e => e.Osteophytosis)
                    .HasColumnName("osteophytosis")
                    .HasMaxLength(255);

                entity.Property(e => e.ParietalBossing).HasColumnName("parietal_bossing");

                entity.Property(e => e.PathologyAnomalies)
                    .HasColumnName("pathology_anomalies")
                    .HasMaxLength(255);

                entity.Property(e => e.PhotoTaken).HasColumnName("photo_taken");

                entity.Property(e => e.PoroticHyperostosis)
                    .HasColumnName("porotic_hyperostosis")
                    .HasMaxLength(255);

                entity.Property(e => e.PoroticHyperostosisLocations)
                    .HasColumnName("porotic_hyperostosis_locations")
                    .HasMaxLength(255);

                entity.Property(e => e.PostcraniaAtMagazine).HasColumnName("postcrania_at_magazine");

                entity.Property(e => e.PostcraniaTrauma).HasColumnName("postcrania_trauma");

                entity.Property(e => e.PreaurSulcus).HasColumnName("preaur_sulcus");

                entity.Property(e => e.PreservationIndex)
                    .HasColumnName("preservation_index")
                    .HasMaxLength(255);

                entity.Property(e => e.PubicBone).HasColumnName("pubic_bone");

                entity.Property(e => e.PubicSymphysis)
                    .HasColumnName("pubic_symphysis")
                    .HasMaxLength(255);

                entity.Property(e => e.RackNumber14c).HasColumnName("rack_number_14c");

                entity.Property(e => e.Robust).HasColumnName("robust");

                entity.Property(e => e.SampleNumber).HasColumnName("sample_number");

                entity.Property(e => e.SciaticNotch).HasColumnName("sciatic_notch");

                entity.Property(e => e.SexBySkull)
                    .HasColumnName("sex_by_skull")
                    .HasMaxLength(255);

                entity.Property(e => e.SizeInMl).HasColumnName("size_in_ml");

                entity.Property(e => e.SkullAtMagazine).HasColumnName("skull_at_magazine");

                entity.Property(e => e.SkullTrauma).HasColumnName("skull_trauma");

                entity.Property(e => e.SoftTissueTaken).HasColumnName("soft_tissue_taken");

                entity.Property(e => e.SouthToFeet).HasColumnName("south_to_feet");

                entity.Property(e => e.SouthToHead).HasColumnName("south_to_head");

                entity.Property(e => e.SublocationId).HasColumnName("sublocation_id");

                entity.Property(e => e.SubpubicAngle).HasColumnName("subpubic_angle");

                entity.Property(e => e.SupraorbitalRidges).HasColumnName("supraorbital_ridges");

                entity.Property(e => e.TemporalMandibularJointOsteoarthritis).HasColumnName("temporal_mandibular_joint_osteoarthritis");

                entity.Property(e => e.TextileTaken).HasColumnName("textile_taken");

                entity.Property(e => e.TibiaLength).HasColumnName("tibia_length");

                entity.Property(e => e.ToBeConfirmed).HasColumnName("to_be_confirmed");

                entity.Property(e => e.ToothAttrition)
                    .HasColumnName("tooth_attrition")
                    .HasMaxLength(255);

                entity.Property(e => e.ToothEruption)
                    .HasColumnName("tooth_eruption")
                    .HasMaxLength(255);

                entity.Property(e => e.ToothTaken).HasColumnName("tooth_taken");

                entity.Property(e => e.TubeNumber).HasColumnName("tube_number");

                entity.Property(e => e.VentralArc).HasColumnName("ventral_arc");

                entity.Property(e => e.WestToFeet).HasColumnName("west_to_feet");

                entity.Property(e => e.WestToHead).HasColumnName("west_to_head");

                entity.Property(e => e.YearExcavated).HasColumnName("year_excavated");

                entity.Property(e => e.YearOnSkull).HasColumnName("year_on_skull");

                entity.Property(e => e.ZygomaticCrest).HasColumnName("zygomatic_crest");
            });

            modelBuilder.Entity<FieldBook>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.BookNumber)
                    .IsRequired()
                    .HasColumnName("book_number")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<FieldBookEntry>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.DataEntryCheckerInitials)
                    .HasColumnName("data_entry_checker_initials")
                    .HasMaxLength(255);

                entity.Property(e => e.DataEntryExpertInitials)
                    .HasColumnName("data_entry_expert_initials")
                    .HasMaxLength(255);

                entity.Property(e => e.PageNumber)
                    .IsRequired()
                    .HasColumnName("page_number")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.ImagePath)
                    .HasColumnName("image_path")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                //entity.HasNoKey();
                //entity.HasKey(e => new { e.MatchId, e.GameNumber, e.BowlerId });

                entity.HasKey(e => new { e.LocationId });

                entity.Property(e => e.BurialLocationEw)
                    .IsRequired()
                    .HasColumnName("burial_location_EW")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialLocationNs)
                    .IsRequired()
                    .HasColumnName("burial_location_NS")
                    .HasMaxLength(255);

                entity.Property(e => e.HighValueEw).HasColumnName("high_value_EW");

                entity.Property(e => e.HighValueNs).HasColumnName("high_value_NS");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.LowValueEw).HasColumnName("low_value_EW");

                entity.Property(e => e.LowValueNs).HasColumnName("low_value_NS");
            });

            modelBuilder.Entity<Rack>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.RackId).HasColumnName("rack_id");

                entity.Property(e => e.RackNumber)
                    .IsRequired()
                    .HasColumnName("rack_number")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Sample>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.InitialsForSample)
                    .HasColumnName("initials_for_sample")
                    .HasMaxLength(255);

                entity.Property(e => e.PreviouslySampled).HasColumnName("previously_sampled");

                entity.Property(e => e.SampleBagNumber).HasColumnName("sample_bag_number");

                entity.Property(e => e.SampleDateDay).HasColumnName("sample_date_day");

                entity.Property(e => e.SampleDateMonth).HasColumnName("sample_date_month");

                entity.Property(e => e.SampleDateYear).HasColumnName("sample_date_year");

                entity.Property(e => e.SampleId).HasColumnName("sample_id");

                entity.Property(e => e.SampleNotes)
                    .HasColumnName("sample_notes")
                    .HasMaxLength(255);

                entity.Property(e => e.SampleRackNumber).HasColumnName("sample_rack_number");
            });

            modelBuilder.Entity<ShelfLocation>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.RackId).HasColumnName("rack_id");

                entity.Property(e => e.ShelfNumber)
                    .HasColumnName("shelf_number")
                    .HasMaxLength(255);

                entity.Property(e => e.ShelflocationId).HasColumnName("shelflocation_id");
            });

            modelBuilder.Entity<SubLocation>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AreaNumber).HasColumnName("area_number");

                entity.Property(e => e.SublocationId).HasColumnName("sublocation_id");

                entity.Property(e => e.Subplot)
                    .HasColumnName("subplot")
                    .HasMaxLength(255);

                entity.Property(e => e.TombNumber)
                    .HasColumnName("tomb_number")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
