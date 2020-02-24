using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp
{
    class CollegeContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Programs> programs{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = CollegeDataBase; Integrated Security = True; Connect Timeout = 30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Programs>(entity =>
            {
                entity.HasKey(e => e.ProgramName).HasName("Pk_ProgramName");
                entity.Property(e => e.ProgramName).IsRequired();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Pk_StudentId");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Sex).IsRequired().HasMaxLength(1);
                entity.HasOne(e => e.program).WithMany().HasForeignKey(e => e.ProgramNames);
            });

            modelBuilder.Entity<Course>(entitiy =>
            {
                entitiy.HasKey(e => e.Code).HasName("Pk_CourseCode");
                entitiy.Property(e => e.Code).ValueGeneratedOnAdd();
                entitiy.HasOne(e => e.program).WithMany().HasForeignKey(e => e.ProgramName);
            });
        }

        
    }
}
