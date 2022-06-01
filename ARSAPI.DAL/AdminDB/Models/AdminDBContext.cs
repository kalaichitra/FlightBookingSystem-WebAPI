//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace ARSAPI.DAL.Models
//{
//    public partial class AdminDBContext : DbContext
//    {
//        public AdminDBContext()
//        {
//        }

//        public AdminDBContext(DbContextOptions<AdminDBContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<AirlineMgmt> AirlineMgmt { get; set; }
//        public virtual DbSet<AirlineRegistration> AirlineRegistration{ get; set; }
//        public virtual DbSet<Coupon> Coupon { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<AirlineMgmt>(entity =>
//            {
//                //entity.HasKey(e => e.FlightNo);

//                entity.HasIndex(e => e.AirlineName)
//                    .HasName("UQ__AirlineM__4183CE818736DE67")
//                    .IsUnique();

//                entity.Property(e => e.FlightNo)
//                    .HasColumnName("Flight_No")
//                    .HasMaxLength(20)
//                    .ValueGeneratedNever();

//                entity.Property(e => e.AirlineId).HasColumnName("AirlineID");

//                entity.Property(e => e.AirlineName)
//                    .IsRequired()
//                    .HasMaxLength(20)
//                    .IsUnicode(false);

//                entity.Property(e => e.BusinessSeats).HasColumnName("Business_Seats");

//                entity.Property(e => e.EndDate)
//                    .HasColumnName("End_Date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.FromPlace)
//                    .IsRequired()
//                    .HasColumnName("From_Place")
//                    .HasMaxLength(20);

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .ValueGeneratedOnAdd();

//                entity.Property(e => e.InstrumentUsed)
//                    .IsRequired()
//                    .HasColumnName("Instrument_Used")
//                    .HasMaxLength(10);

//                entity.Property(e => e.MealType)
//                    .IsRequired()
//                    .HasColumnName("Meal_Type")
//                    .HasMaxLength(20)
//                    .IsUnicode(false);

//                entity.Property(e => e.NonBusinessSeats).HasColumnName("NonBusiness_Seats");

//                entity.Property(e => e.ScheduledDays).HasColumnName("Scheduled_Days");

//                entity.Property(e => e.StartDate)
//                    .HasColumnName("Start_Date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.TicketCost).HasColumnType("money");

//                entity.Property(e => e.ToPlace)
//                    .IsRequired()
//                    .HasColumnName("To_Place")
//                    .HasMaxLength(20);

//                entity.HasOne(d => d.Airline)
//                    .WithMany(p => p.AirlineMgmt)
//                    .HasForeignKey(d => d.AirlineId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__AirlineMg__Airli__3E52440B");
//            });

//            modelBuilder.Entity<AirlineRegistration>(entity =>
//            {
//                entity.HasKey(e => e.AirlineId);

//                entity.HasIndex(e => e.AirlineName)
//                    .HasName("UQ__AirlineR__4183CE81AF4EB09B")
//                    .IsUnique();

//                entity.Property(e => e.AirlineId).HasColumnName("AirlineID");

//                entity.Property(e => e.AirlineName)
//                    .IsRequired()
//                    .HasMaxLength(20)
//                    .IsUnicode(false);

//                entity.Property(e => e.ContactAddress)
//                    .IsRequired()
//                    .HasColumnName("Contact_Address")
//                    .HasMaxLength(100);

//                entity.Property(e => e.ContactNo)
//                    .IsRequired()
//                    .HasColumnName("Contact_No")
//                    .HasMaxLength(10);

//                entity.Property(e => e.Logo).HasMaxLength(1);
//            });

//            modelBuilder.Entity<Coupon>(entity =>
//            {
//                entity.HasIndex(e => e.DicountCode)
//                    .HasName("UQ__Coupon__C3A93FC0151A466D")
//                    .IsUnique();

//                entity.Property(e => e.CouponId).HasColumnName("CouponID");

//                entity.Property(e => e.DicountCode)
//                    .IsRequired()
//                    .HasMaxLength(20)
//                    .IsUnicode(false);
//            });
//        }
//    }
//}
