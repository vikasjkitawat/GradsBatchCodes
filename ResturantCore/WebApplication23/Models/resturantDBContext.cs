using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication23.Models
{
    public partial class resturantDBContext : DbContext
    {
        public resturantDBContext()
        {
        }

        public resturantDBContext(DbContextOptions<resturantDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Resturant> Resturant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SAIRAJ-PC\\SQLEXPRESS; Initial Catalog=resturantDB; Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__addresse__26A1118D3D19E326");

                entity.ToTable("addresses");

                entity.HasIndex(e => e.ResturantId)
                    .HasName("UQ__addresse__D92AD0962BA4F0C0")
                    .IsUnique();

                entity.Property(e => e.AddressId)
                    .HasColumnName("addressID")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ResturantId).HasColumnName("resturantID");

                entity.Property(e => e.States)
                    .IsRequired()
                    .HasColumnName("states")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Resturant)
                    .WithOne(p => p.Addresses)
                    .HasForeignKey<Addresses>(d => d.ResturantId)
                    .HasConstraintName("FK__addresses__restu__276EDEB3");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__items__56A1284A78521C55");

                entity.ToTable("items");

                entity.Property(e => e.ItemId)
                    .HasColumnName("itemID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("itemName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnName("itemPrice");

                entity.Property(e => e.ResturantId).HasColumnName("resturantID");

                entity.HasOne(d => d.Resturant)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ResturantId)
                    .HasConstraintName("FK__items__resturant__2A4B4B5E");
            });

            modelBuilder.Entity<Resturant>(entity =>
            {
                entity.ToTable("resturant");

                entity.Property(e => e.ResturantId)
                    .HasColumnName("resturantID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ResturantName)
                    .IsRequired()
                    .HasColumnName("resturantName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
