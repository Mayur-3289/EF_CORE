using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmsDbFirst.Models
{
    public partial class AssignmentDbContext : DbContext
    {
        public AssignmentDbContext()
        {
        }

        public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Table1> Table1s { get; set; }
        public virtual DbSet<Table2> Table2s { get; set; }
        public virtual DbSet<VEmp> VEmps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-TS30HT6O\\SQLEXPRESS;Database=AssignmentDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("DepartmentID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Number)
                    .HasName("PK__Employee__78A1A19CBE427BEC");

                entity.Property(e => e.Commission).HasColumnType("money");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateOfJoining).HasColumnType("date");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.DepartmentNoNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Dept");

                entity.HasOne(d => d.ReportingToNavigation)
                    .WithMany(p => p.InverseReportingToNavigation)
                    .HasForeignKey(d => d.ReportingTo)
                    .HasConstraintName("FK__Employees__Repor__267ABA7A");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Table1>(entity =>
            {
                entity.ToTable("Table1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Mobileno).HasColumnName("mobileno");
            });

            modelBuilder.Entity<Table2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Table2");
            });

            modelBuilder.Entity<VEmp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Emp");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Number).ValueGeneratedOnAdd();

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
