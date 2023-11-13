using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JustClean.Web.Models.db;

public partial class JustcleanContext : DbContext
{
    public JustcleanContext()
    {
    }

    public JustcleanContext(DbContextOptions<JustcleanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Audit> Audits { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Deal> Deals { get; set; }

    public virtual DbSet<Dealstatus> Dealstatuses { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=justclean;user=root;password=password", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("audit");

            entity.HasIndex(e => e.IdOffice, "FK_Office_Audit");

            entity.HasIndex(e => e.IdUser, "FK_User_Audit");

            entity.Property(e => e.Event).HasMaxLength(255);
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.IdOfficeNavigation).WithMany(p => p.Audits)
                .HasForeignKey(d => d.IdOffice)
                .HasConstraintName("FK_Office_Audit");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Audits)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_User_Audit");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("client");

            entity.HasIndex(e => e.IdOffice, "FK_Office_Client");

            entity.HasIndex(e => e.IdUser, "FK_User_Client");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Login).HasMaxLength(45);
            entity.Property(e => e.Mail).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.Patronymic).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.Surname).HasMaxLength(255);

            entity.HasOne(d => d.IdOfficeNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdOffice)
                .HasConstraintName("FK_Office_Client");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_User_Client");
        });

        modelBuilder.Entity<Deal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("deal");

            entity.HasIndex(e => e.IdClient, "FK_Client_Deal");

            entity.HasIndex(e => e.IdOffice, "FK_Office_Deal");

            entity.HasIndex(e => e.IdService, "FK_Service_Deal");

            entity.HasIndex(e => e.IdStatus, "FK_Status_Deal");

            entity.HasIndex(e => e.IdUser, "FK_User_Deal");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ProvisionDate).HasColumnType("datetime");
            entity.Property(e => e.Street).HasMaxLength(255);

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Deals)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK_Client_Deal");

            entity.HasOne(d => d.IdOfficeNavigation).WithMany(p => p.Deals)
                .HasForeignKey(d => d.IdOffice)
                .HasConstraintName("FK_Office_Deal");

            entity.HasOne(d => d.IdServiceNavigation).WithMany(p => p.Deals)
                .HasForeignKey(d => d.IdService)
                .HasConstraintName("FK_Service_Deal");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Deals)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK_Status_Deal");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Deals)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_User_Deal");
        });

        modelBuilder.Entity<Dealstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dealstatus");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("good");

            entity.HasIndex(e => e.IdOffice, "FK_Office_Good");

            entity.HasIndex(e => e.IdProvider, "FK_Provider_Good");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.IdOfficeNavigation).WithMany(p => p.Goods)
                .HasForeignKey(d => d.IdOffice)
                .HasConstraintName("FK_Office_Good");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.Goods)
                .HasForeignKey(d => d.IdProvider)
                .HasConstraintName("FK_Provider_Good");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("office");

            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Region).HasMaxLength(255);
            entity.Property(e => e.Street).HasMaxLength(255);
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("provider");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Mail).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sale");

            entity.HasIndex(e => e.IdGood, "FK_Good_Sale");

            entity.HasIndex(e => e.IdOffice, "FK_Office_Sale");

            entity.HasIndex(e => e.IdUser, "FK_User_Sale");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");

            entity.HasOne(d => d.IdGoodNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdGood)
                .HasConstraintName("FK_Good_Sale");

            entity.HasOne(d => d.IdOfficeNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdOffice)
                .HasConstraintName("FK_Office_Sale");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_User_Sale");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("services");

            entity.HasIndex(e => e.OfficeId, "FK_Office_Services");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.OfficeId).HasColumnName("OfficeID");

            entity.HasOne(d => d.Office).WithMany(p => p.Services)
                .HasForeignKey(d => d.OfficeId)
                .HasConstraintName("FK_Office_Services");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.IdOffice, "FK_Office_User");

            entity.HasIndex(e => e.IdUserRole, "FK_UserRole_User");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.IdOfficeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdOffice)
                .HasConstraintName("FK_Office_User");

            entity.HasOne(d => d.IdUserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdUserRole)
                .HasConstraintName("FK_UserRole_User");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("userrole");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
