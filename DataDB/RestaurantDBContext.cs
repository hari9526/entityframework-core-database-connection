using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatabaseConnectionEntityFrameworkCore.DataDB
{
    public partial class RestaurantDBContext : DbContext
    {
        public RestaurantDBContext()
        {
        }

        public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<FoodItem> FoodItems { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderMaster> OrderMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-50007OQ;Initial Catalog=RestaurantDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerName).HasMaxLength(100);
            });

            modelBuilder.Entity<FoodItem>(entity =>
            {
                entity.Property(e => e.FoodItemName).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasIndex(e => e.FoodItemId, "IX_OrderDetails_FoodItemId");

                entity.HasIndex(e => e.OrderMasterId, "IX_OrderDetails_OrderMasterId");

                entity.Property(e => e.FoodItemPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.FoodItem)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.FoodItemId);

                entity.HasOne(d => d.OrderMaster)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderMasterId);
            });

            modelBuilder.Entity<OrderMaster>(entity =>
            {
                entity.ToTable("orderMasters");

                entity.HasIndex(e => e.CustomerId, "IX_orderMasters_CustomerId");

                entity.Property(e => e.Gtotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("GTotal");

                entity.Property(e => e.OrderNumber).HasMaxLength(50);

                entity.Property(e => e.Pmethod)
                    .HasMaxLength(10)
                    .HasColumnName("PMethod");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderMasters)
                    .HasForeignKey(d => d.CustomerId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
