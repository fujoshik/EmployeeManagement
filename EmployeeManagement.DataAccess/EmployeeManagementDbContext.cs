using EmployeeManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace EmployeeManagement.DataAccess
{
    public class EmployeeManagementDbContext : DbContext
    {
        public EmployeeManagementDbContext()
            : base()
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-V8J7KQR\\SQLEXPRESS;Database=EmployeeManagementDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e =>
            {
                e.Property(x => x.FullName).IsRequired();
                e.Property(x => x.Email).IsRequired();
                e.HasIndex(x => x.Email).IsUnique();
                e.Property(x => x.DateOfBirth).IsRequired();
                e.Property(x => x.PhoneNumber).IsRequired();
                e.Property(x => x.MonthlySalary).IsRequired();
            });

            modelBuilder.Entity<Entities.Task>(t =>
            {
                t.Property(x => x.Title).IsRequired();
                t.Property(x => x.Description).IsRequired();
                t.Property(x => x.DueDate).IsRequired();

                t.HasOne(t => t.Assignee).WithMany(a => a.Tasks).HasForeignKey(t => t.AssigneeId);
            });

            modelBuilder.Entity<Department>(d =>
            {
                d.Property(x => x.Name).IsRequired();
                d.HasIndex(x => x.Name).IsUnique();
                d.Property(x => x.Description).IsRequired();

                d.HasMany(d => d.Employees).WithOne(e => e.Department).HasForeignKey(e => e.DepartmentId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
