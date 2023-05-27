using System;
using System.Collections.Generic;
using Infrastructure.Data.Models;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Data.DbContexts
{
    public partial class LogisticsContext : DbContext
    {
        private readonly IAppSettingsService _appSettings;

        public LogisticsContext(IAppSettingsService appSettings)
        {
            _appSettings = appSettings;
        }

        public LogisticsContext(DbContextOptions<LogisticsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<LandLogistic> LandLogistics { get; set; } = null!;
        public virtual DbSet<MaritimeLogistic> MaritimeLogistics { get; set; } = null!;
        public virtual DbSet<Port> Ports { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_appSettings.GetSQLServerSettings().ConnectionStrings);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .ValueGeneratedNever()
                    .HasColumnName("ClientID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LandLogistic>(entity =>
            {
                entity.HasKey(e => e.LandLogisticsId)
                    .HasName("PK__LandLogi__CE56AA775E775A34");

                entity.Property(e => e.LandLogisticsId)
                    .ValueGeneratedNever()
                    .HasColumnName("LandLogisticsID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.GuideNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.RegistrationDate).HasColumnType("date");

                entity.Property(e => e.ShippingPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.VehiclePlate)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.LandLogistics)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LandLogis__Clien__2E1BDC42");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.LandLogistics)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LandLogis__Produ__2C3393D0");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.LandLogistics)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LandLogis__Wareh__2D27B809");
            });

            modelBuilder.Entity<MaritimeLogistic>(entity =>
            {
                entity.HasKey(e => e.MaritimeLogisticsId)
                    .HasName("PK__Maritime__64F86AA366E3A816");

                entity.Property(e => e.MaritimeLogisticsId)
                    .ValueGeneratedNever()
                    .HasColumnName("MaritimeLogisticsID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.FleetNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GuideNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PortId).HasColumnName("PortID");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.RegistrationDate).HasColumnType("date");

                entity.Property(e => e.ShippingPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.MaritimeLogistics)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MaritimeL__Clien__32E0915F");

                entity.HasOne(d => d.Port)
                    .WithMany(p => p.MaritimeLogistics)
                    .HasForeignKey(d => d.PortId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MaritimeL__PortI__31EC6D26");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.MaritimeLogistics)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MaritimeL__Produ__30F848ED");
            });

            modelBuilder.Entity<Port>(entity =>
            {
                entity.Property(e => e.PortId)
                    .ValueGeneratedNever()
                    .HasColumnName("PortID");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.ProductTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductTypeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.Property(e => e.WarehouseId)
                    .ValueGeneratedNever()
                    .HasColumnName("WarehouseID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
