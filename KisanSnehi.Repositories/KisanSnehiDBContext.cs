using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KisanSnehi.Entities;

#nullable disable

namespace KisanSnehi.Repositories
{
    public partial class KisanSnehiDBContext : DbContext
    {
        public KisanSnehiDBContext()
        {
        }

        public KisanSnehiDBContext(DbContextOptions<KisanSnehiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crop> Crops { get; set; }
        public virtual DbSet<CropPurchase> CropPurchases { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Fertilizer> Fertilizers { get; set; }
        public virtual DbSet<FertilizerPurchase> FertilizerPurchases { get; set; }
        public virtual DbSet<Guidance> Guidances { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer("Server=localhost;Database=InnovateFarming.Database;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Crop>(entity =>
            {
                entity.ToTable("Crop");

                entity.Property(e => e.CropId).HasColumnName("Crop_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.CropDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Crop_Desc");

                entity.Property(e => e.CropName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Crop_Name");

                entity.Property(e => e.CropPrice).HasColumnName("Crop_Price");

                entity.Property(e => e.CropQuantity).HasColumnName("Crop_Quantity");

                entity.Property(e => e.CropQuantityInStock).HasColumnName("Crop_Quantity_InStock");

                entity.Property(e => e.FarmerId).HasColumnName("Farmer_Id");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("Updated_Date");

               /* entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.Crops)
                    .HasForeignKey(d => d.FarmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Crop_Registeration");*/
            });

            modelBuilder.Entity<CropPurchase>(entity =>
            {
                entity.ToTable("Crop_Purchase");

                entity.Property(e => e.CropPurchaseId).HasColumnName("Crop_Purchase_Id");

                entity.Property(e => e.CropBillAmount).HasColumnName("Crop_Bill_Amount");

                entity.Property(e => e.CropId).HasColumnName("Crop_Id");

                entity.Property(e => e.CropPurchaseDate)
                    .HasColumnType("date")
                    .HasColumnName("Crop_Purchase_Date");

                entity.Property(e => e.CropPurchaseQuantity).HasColumnName("Crop_Purchase_Quantity");

                entity.Property(e => e.FarmerId).HasColumnName("Farmer_Id");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");

                /*entity.HasOne(d => d.Crop)
                    .WithMany(p => p.CropPurchases)
                    .HasForeignKey(d => d.CropId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Crop_Purchase_Crop");

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.CropPurchaseFarmers)
                    .HasForeignKey(d => d.FarmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Crop_Purchase_Registeration");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.CropPurchaseSuppliers)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Crop_Purchase_Registeration1");*/
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("Feedback_Id");

                entity.Property(e => e.FeedbackDesc)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Feedback_Desc");

                entity.Property(e => e.RegDate)
                    .HasColumnType("date")
                    .HasColumnName("Reg_Date");

                entity.Property(e => e.RegId).HasColumnName("Reg_Id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("Updated_Date");

               /* entity.HasOne(d => d.Reg)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.RegId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Registeration");*/
            });

            modelBuilder.Entity<Fertilizer>(entity =>
            {
                entity.ToTable("Fertilizer");

                entity.Property(e => e.FertilizerId).HasColumnName("Fertilizer_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.FertilizerDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Fertilizer_Desc");

                entity.Property(e => e.FertilizerName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Fertilizer_Name");

                entity.Property(e => e.FertilizerPrice).HasColumnName("Fertilizer_Price");

                entity.Property(e => e.FertilizerQuantity).HasColumnName("Fertilizer_Quantity");

                entity.Property(e => e.FertilizerQuantityInStock).HasColumnName("Fertilizer_Quantity_InStock");

                entity.Property(e => e.TraderId).HasColumnName("Trader_Id");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("Updated_Date");
/*
                entity.HasOne(d => d.Trader)
                    .WithMany(p => p.Fertilizers)
                    .HasForeignKey(d => d.TraderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fertilizer_Registeration");*/
            });

            modelBuilder.Entity<FertilizerPurchase>(entity =>
            {
                entity.ToTable("Fertilizer_Purchase");

                entity.Property(e => e.FertilizerPurchaseId).HasColumnName("Fertilizer_Purchase_Id");

                entity.Property(e => e.FarmerId).HasColumnName("Farmer_Id");

                entity.Property(e => e.FertilizerBillAmount).HasColumnName("Fertilizer_Bill_Amount");

                entity.Property(e => e.FertilizerId).HasColumnName("Fertilizer_Id");

                entity.Property(e => e.FertilizerPurchaseDate)
                    .HasColumnType("date")
                    .HasColumnName("Fertilizer_Purchase_Date");

                entity.Property(e => e.FertilizerPurchaseQuantity).HasColumnName("Fertilizer_Purchase_Quantity");

                entity.Property(e => e.TraderId).HasColumnName("Trader_Id");

              /*  entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.FertilizerPurchases)
                    .HasForeignKey(d => d.FarmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fertilizer_Purchase_Fertilizer");

                entity.HasOne(d => d.FarmerNavigation)
                    .WithMany(p => p.FertilizerPurchaseFarmerNavigations)
                    .HasForeignKey(d => d.FarmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fertilizer_Purchase_Registeration");

                entity.HasOne(d => d.Trader)
                    .WithMany(p => p.FertilizerPurchaseTraders)
                    .HasForeignKey(d => d.TraderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fertilizer_Purchase_Registeration1");*/
            });

            modelBuilder.Entity<Guidance>(entity =>
            {
                entity.ToTable("Guidance");

                entity.Property(e => e.GuidanceId).HasColumnName("Guidance_Id");

                entity.Property(e => e.CropDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Crop_Desc");

                entity.Property(e => e.CropName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Crop_Name");

                entity.Property(e => e.FromMonth).HasColumnName("From_Month");

                entity.Property(e => e.ToMonth).HasColumnName("To_Month");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId).HasColumnName("Location_Id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.RegId)
                    .HasName("PK_Registeration");

                entity.ToTable("Registration");

                entity.Property(e => e.RegId).HasColumnName("Reg_Id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("Location_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegDate)
                    .HasColumnType("date")
                    .HasColumnName("Reg_Date");

                entity.Property(e => e.SecurityQue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Security_Que");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.Property(e => e.UserTypeId).HasColumnName("User_Type_Id");

                //entity.HasOne(d => d.Location)
                //    .WithMany(p => p.Registrations)
                //    .HasForeignKey(d => d.LocationId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Registeration_Location");

                //entity.HasOne(d => d.UserType)
                //    .WithMany(p => p.Registrations)
                //    .HasForeignKey(d => d.UserTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Registeration_UserType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.Property(e => e.UserTypeId).HasColumnName("User_Type_Id");

                entity.Property(e => e.UserType1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("User_Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
