using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ARSAPI.DAL.Model
{
    public partial class AdminMgmtDBContext : DbContext
    {
        public AdminMgmtDBContext()
        {
        }

        public AdminMgmtDBContext(DbContextOptions<AdminMgmtDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirlineMgmt> AirlineMgmt { get; set; }
        public virtual DbSet<AirlineRegDetails> AirlineRegDetails { get; set; }
        public virtual DbSet<Coupon> Coupon { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirlineMgmt>(entity =>
            {
                entity.HasKey(e => e.FlightNo);

                entity.HasIndex(e => e.AirlineName)
                    .HasName("UQ__AirlineM__4183CE8180B3979F")
                    .IsUnique();

                entity.Property(e => e.FlightNo)
                    .HasColumnName("Flight_No")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.AirlineName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessSeats).HasColumnName("Business_Seats");

                entity.Property(e => e.EndDate)
                    .HasColumnName("End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FromPlace)
                    .IsRequired()
                    .HasColumnName("From_Place")
                    .HasMaxLength(20);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InstrumentUsed)
                    .IsRequired()
                    .HasColumnName("Instrument_Used")
                    .HasMaxLength(10);

                entity.Property(e => e.MealType)
                    .IsRequired()
                    .HasColumnName("Meal_Type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NonBusinessSeats).HasColumnName("NonBusiness_Seats");

                entity.Property(e => e.ScheduledDays).HasColumnName("Scheduled_Days");

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketCost).HasColumnType("money");

                entity.Property(e => e.ToPlace)
                    .IsRequired()
                    .HasColumnName("To_Place")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<AirlineRegDetails>(entity =>
            {
                entity.HasKey(e => e.AirlineId);

                entity.HasIndex(e => e.AirlineName);
                    //.HasName("UQ__AirlineR__4183CE81E35CFF2D");
                   // .IsUnique();

                entity.Property(e => e.AirlineId).HasColumnName("AirlineID");

                entity.Property(e => e.AirlineName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContactAddress)
                    .IsRequired()
                    .HasColumnName("Contact_Address")
                    .HasMaxLength(100);

                entity.Property(e => e.ContactNo)
                    .IsRequired()
                    .HasColumnName("Contact_No")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.HasIndex(e => e.DicountCode)
                    .HasName("UQ__Coupon__C3A93FC05DE6E5EE")
                    .IsUnique();

                entity.Property(e => e.CouponId).HasColumnName("CouponID");

                entity.Property(e => e.DicountCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
