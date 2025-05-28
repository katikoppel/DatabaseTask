using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.Models;

public partial class DatabaseTaskContext : DbContext
{
    public DatabaseTaskContext()
    {
    }

    public DatabaseTaskContext(DbContextOptions<DatabaseTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Access> Accesses { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KATLAPTOP\\MSSQLSERVER01;Database=DatabaseTask;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Access>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Access__3214EC0769271DB8");

            entity.ToTable("Access");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3214EC07BB06C952");

            entity.ToTable("Address");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AdministrativeUnit)
                .HasMaxLength(30)
                .HasColumnName("administrativeUnit");
            entity.Property(e => e.ApartmentNumber).HasColumnName("apartmentNumber");
            entity.Property(e => e.BuildingPartNumber).HasColumnName("buildingPartNumber");
            entity.Property(e => e.CityDistrict)
                .HasMaxLength(30)
                .HasColumnName("cityDistrict");
            entity.Property(e => e.County)
                .HasMaxLength(50)
                .HasColumnName("county");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .HasColumnName("postalCode");
            entity.Property(e => e.RouteName)
                .HasMaxLength(30)
                .HasColumnName("routeName");
        });

        modelBuilder.Entity<Child>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Child__3214EC072D6EB93C");

            entity.ToTable("Child");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BirthDate).HasColumnName("birthDate");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("lastName");

            entity.HasOne(d => d.Employee).WithMany(p => p.Children)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Child__EmployeeI__5DCAEF64");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07638F0CAD");

            entity.ToTable("Employee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("lastName");
            entity.Property(e => e.PersonalCode)
                .HasMaxLength(30)
                .HasColumnName("personalCode");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");

            entity.HasOne(d => d.Address).WithMany(p => p.Employees)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__Employee__Addres__5AEE82B9");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Salary__3214EC07BCFE7DB6");

            entity.ToTable("Salary");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SalaryAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("salaryAmount");
            entity.Property(e => e.StartDate).HasColumnName("startDate");

            entity.HasOne(d => d.Employee).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Salary__Employee__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
