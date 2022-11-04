using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace database_first_example.Models
{
    public partial class UniversityDBContext : DbContext
    {
        public UniversityDBContext()
        {
        }

        public UniversityDBContext(DbContextOptions<UniversityDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Enrolled> Enrolleds { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversityDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("course_name");

                entity.Property(e => e.Credits).HasColumnName("credits");
            });

            modelBuilder.Entity<Enrolled>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Enrolled");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.StudentId).HasColumnName("student_id");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StudentId).HasColumnName("student_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
