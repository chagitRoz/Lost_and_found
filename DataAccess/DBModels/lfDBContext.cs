using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.DBModels
{
    public partial class LfDBContext : DbContext
    {
        public LfDBContext()
        {
        }

        public LfDBContext(DbContextOptions<LfDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<CityByAd> CityByAds { get; set; } = null!;
        public virtual DbSet<LostAndFound> LostAndFounds { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<SubCategory> SubCategories { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=LfDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .HasColumnName("cityName");
            });

            modelBuilder.Entity<CityByAd>(entity =>
            {
                entity.ToTable("CityByAd");

                entity.Property(e => e.CityByAdId).HasColumnName("cityByAdId");

                entity.Property(e => e.AdId).HasColumnName("adId");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.HasOne(d => d.Ad)
                    .WithMany(p => p.CityByAds)
                    .HasForeignKey(d => d.AdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CityByAd_LostAndFound");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.CityByAds)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CityByAd_City");
            });

            modelBuilder.Entity<LostAndFound>(entity =>
            {
                entity.ToTable("LostAndFound");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Common).HasColumnName("common");

                entity.Property(e => e.DatePublished)
                    .HasColumnType("datetime")
                    .HasColumnName("datePublished");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.GetEmail).HasColumnName("getEmail");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .HasColumnName("image");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("startDate");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.SubCategoryId).HasColumnName("subCategoryId");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.LostAndFounds)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_LostAndFound_Category");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.LostAndFounds)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LostAndFound_Status");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.LostAndFounds)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK_LostAndFound_SubCategory");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.LostAndFounds)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LostAndFound_Type");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LostAndFounds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LostAndFound_User");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(10)
                    .HasColumnName("statusName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("SubCategory");

                entity.Property(e => e.SubCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("subCategoryId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.SubCategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("subCategoryName");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCategory_Category");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(10)
                    .HasColumnName("typeName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
