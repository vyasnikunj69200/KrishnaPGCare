using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class shopkrillContext : DbContext
    {
        //public shopkrillContext()
        //{
        //}

        public shopkrillContext(DbContextOptions<shopkrillContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BillTbl> BillTbls { get; set; }
        public virtual DbSet<BookingRequest> BookingRequests { get; set; }
        public virtual DbSet<BookingRequestTbl> BookingRequestTbls { get; set; }
        public virtual DbSet<BookingTbl> BookingTbls { get; set; }
        public virtual DbSet<EmailNotificationsLogTbl> EmailNotificationsLogTbls { get; set; }
        public virtual DbSet<FacilityTbl> FacilityTbls { get; set; }
        public virtual DbSet<FeedBackTbl> FeedBackTbls { get; set; }
        public virtual DbSet<InvoiceTbl> InvoiceTbls { get; set; }
        public virtual DbSet<MaintenanceRequestTbl> MaintenanceRequestTbls { get; set; }
        public virtual DbSet<PaymentTbl> PaymentTbls { get; set; }
        public virtual DbSet<PropertyTbl> PropertyTbls { get; set; }
        public virtual DbSet<ReviewTbl> ReviewTbls { get; set; }
        public virtual DbSet<RoomTbl> RoomTbls { get; set; }
        public virtual DbSet<TenantTbl> TenantTbls { get; set; }
        public virtual DbSet<UserLoginHistoryTbl> UserLoginHistoryTbls { get; set; }
        public virtual DbSet<UserTbl> UserTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\localhost;Database=shop-krill;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillTbl>(entity =>
            {
                entity.HasKey(e => e.BillId)
                    .HasName("PK__BillTbl__11F2FC4A845A9AE0");

                entity.ToTable("BillTbl");

                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.BillAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BillDate).HasColumnType("date");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.BillTbls)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK__BillTbl__Propert__619B8048");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.BillTbls)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK__BillTbl__TenantI__60A75C0F");
            });

            modelBuilder.Entity<BookingRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.ToTable("BookingRequest");

                entity.Property(e => e.AcceptByOwner).HasColumnName("acceptByOwner");

                entity.Property(e => e.RoomType).HasColumnName("roomType");

                entity.Property(e => e.Rquestdatetime).HasColumnName("rquestdatetime");
            });

            modelBuilder.Entity<BookingRequestTbl>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.ToTable("BookingRequestTbl");

                entity.Property(e => e.AcceptByOwner).HasColumnName("acceptByOwner");

                entity.Property(e => e.RoomType).HasColumnName("roomType");

                entity.Property(e => e.Rquestdatetime).HasColumnName("rquestdatetime");
            });

            modelBuilder.Entity<BookingTbl>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__BookingT__73951ACD247E6038");

                entity.ToTable("BookingTbl");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.CheckInDate).HasColumnType("date");

                entity.Property(e => e.CheckOutDate).HasColumnType("date");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.SpecialRequests).HasColumnType("text");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.BookingTbls)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK__BookingTb__Prope__440B1D61");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.BookingTbls)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__BookingTb__RoomI__44FF419A");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.BookingTbls)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK__BookingTb__Tenan__4316F928");
            });

            modelBuilder.Entity<EmailNotificationsLogTbl>(entity =>
            {
                entity.HasKey(e => e.NotificationId)
                    .HasName("PK__EmailNot__20CF2E32FD06CED2");

                entity.ToTable("EmailNotificationsLogTbl");

                entity.Property(e => e.NotificationId).HasColumnName("NotificationID");

                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.RecipientUserId).HasColumnName("RecipientUserID");

                entity.Property(e => e.SentDateTime).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.RecipientUser)
                    .WithMany(p => p.EmailNotificationsLogTbls)
                    .HasForeignKey(d => d.RecipientUserId)
                    .HasConstraintName("FK__EmailNoti__Recip__47DBAE45");
            });

            modelBuilder.Entity<FacilityTbl>(entity =>
            {
                entity.HasKey(e => e.FacilityId)
                    .HasName("PK__Facility__5FB08B944FC5A8B2");

                entity.ToTable("FacilityTbl");

                entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

                entity.Property(e => e.FacilityName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PricePerMonth).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.FacilityTbls)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK__FacilityT__Prope__3F466844");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.FacilityTbls)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__FacilityT__RoomI__403A8C7D");
            });

            modelBuilder.Entity<FeedBackTbl>(entity =>
            {
                entity.HasKey(e => e.FeedbackId)
                    .HasName("PK__FeedBack__6A4BEDF6831FF66A");

                entity.ToTable("FeedBackTbl");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.FeedbackDate).HasColumnType("datetime");

                entity.Property(e => e.FeedbackText).HasColumnType("text");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.ResponseText).HasColumnType("text");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.FeedBackTbls)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK__FeedBackT__Prope__5DCAEF64");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FeedBackTbls)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__FeedBackT__UserI__5CD6CB2B");
            });

            modelBuilder.Entity<InvoiceTbl>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("PK__InvoiceT__D796AAD547839534");

                entity.ToTable("InvoiceTbl");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.InvoiceTbls)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK__InvoiceTb__Prope__59FA5E80");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.InvoiceTbls)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK__InvoiceTb__Tenan__59063A47");
            });

            modelBuilder.Entity<MaintenanceRequestTbl>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__Maintena__33A8519A059A6F5D");

                entity.ToTable("MaintenanceRequestTbl");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.RequestDate).HasColumnType("date");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.MaintenanceRequestTbls)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK__Maintenan__Prope__5629CD9C");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.MaintenanceRequestTbls)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK__Maintenan__Tenan__5535A963");
            });

            modelBuilder.Entity<PaymentTbl>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__PaymentT__9B556A58A3EF4302");

                entity.ToTable("PaymentTbl");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.AmountPaid).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.PaymentNotes).HasColumnType("text");

                entity.Property(e => e.PaymentReference)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.PaymentTbls)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__PaymentTb__Booki__4E88ABD4");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.PaymentTbls)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK__PaymentTb__Tenan__4D94879B");
            });

            modelBuilder.Entity<PropertyTbl>(entity =>
            {
                entity.HasKey(e => e.PropertyId)
                    .HasName("PK__Property__70C9A75541FD7549");

                entity.ToTable("PropertyTbl");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Amenities).HasColumnType("text");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PricePerRoom).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PropertyDescription).HasColumnType("text");

                entity.Property(e => e.PropertyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.PropertyTbls)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__PropertyT__Owner__36B12243");
            });

            modelBuilder.Entity<ReviewTbl>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__ReviewTb__74BC79AE1F603104");

                entity.ToTable("ReviewTbl");

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.ReviewDate).HasColumnType("date");

                entity.Property(e => e.ReviewText).HasColumnType("text");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.ReviewTbls)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK__ReviewTbl__Prope__52593CB8");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.ReviewTbls)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK__ReviewTbl__Tenan__5165187F");
            });

            modelBuilder.Entity<RoomTbl>(entity =>
            {
                entity.HasKey(e => e.RoomId)
                    .HasName("PK__RoomTbl__3286391952417D9D");

                entity.ToTable("RoomTbl");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Amenities).HasColumnType("text");

                entity.Property(e => e.MonthlyRent).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.RoomDescription).HasColumnType("text");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.RoomTbls)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK__RoomTbl__Propert__3C69FB99");
            });

            modelBuilder.Entity<TenantTbl>(entity =>
            {
                entity.HasKey(e => e.TenantId)
                    .HasName("PK__TenantTb__2E9B4781E2081ACE");

                entity.ToTable("TenantTbl");

                entity.HasIndex(e => e.Email, "UQ__TenantTb__A9D1053495EDF86D")
                    .IsUnique();

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LeaseEndDate).HasColumnType("date");

                entity.Property(e => e.LeaseStartDate).HasColumnType("date");

                entity.Property(e => e.LeaseTerm)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MonthlyRent).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MoveInDate).HasColumnType("date");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityDeposit).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLoginHistoryTbl>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__UserLogi__5E5499A876842AC7");

                entity.ToTable("UserLoginHistoryTbl");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.FailureReason)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.LoginDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserAgent)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTbl>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserTbl__1788CCAC473CF564");

                entity.ToTable("UserTbl");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Addresss)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
