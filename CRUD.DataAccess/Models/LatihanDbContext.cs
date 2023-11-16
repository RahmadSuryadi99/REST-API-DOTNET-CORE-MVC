using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DataAccess.Models;

public partial class LatihanDbContext : DbContext
{
    public LatihanDbContext()
    {
    }

    public LatihanDbContext(DbContextOptions<LatihanDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auth> Auths { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Produk> Produks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-J9DU5J54; Database=LatihanDB; user=sa; password=indocyber; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auth>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("auth");

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3213E83F7C6A3203");

            entity.ToTable("Cart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduk).HasColumnName("idProduk");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Jumlah).HasColumnName("jumlah");

            entity.HasOne(d => d.IdProdukNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.IdProduk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__idProduk__5CD6CB2B");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__idUser__5DCAEF64");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3213E83F313E5620");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Deskripsi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("deskripsi");
            entity.Property(e => e.Nama)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nama");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3213E83F2B53C0FA");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__idUser__3F466844");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3213E83FD06448A6");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Harga)
                .HasColumnType("money")
                .HasColumnName("harga");
            entity.Property(e => e.IdOrder).HasColumnName("idOrder");
            entity.Property(e => e.IdProduk).HasColumnName("idProduk");
            entity.Property(e => e.Jumlah).HasColumnName("jumlah");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.IdProdukNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdProduk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__idPro__4222D4EF");
        });

        modelBuilder.Entity<Produk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__produk__3213E83FCC9316B2");

            entity.ToTable("produk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Deskripsi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("deskripsi");
            entity.Property(e => e.Harga)
                .HasColumnType("money")
                .HasColumnName("harga");
            entity.Property(e => e.Nama)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nama");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Produks)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__produk__category__267ABA7A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83FD562E45D");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alamat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("alamat");
            entity.Property(e => e.Nama)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nama");
            entity.Property(e => e.TglLahir)
                .HasColumnType("date")
                .HasColumnName("tglLahir");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
