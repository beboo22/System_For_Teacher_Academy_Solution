using Domin.Entity;
using Domin.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data.Configuration
{
    internal class StudentConfg : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            // to table
            builder.ToTable("Students");
            //builder.HasKey(s => s.Id);
            builder.Property(s => s.FName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(s => s.LName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);
            builder.Property(s => s.DateOfBirth)
                    //.HasDefaultValueSql("DATETIME")
                    .IsRequired();

            builder.Property(s => s.SSN)
                .IsRequired();
            builder.Property(s => s.GuardianType)
                .HasConversion(
                    v => v.ToString(),
                    v => (GuardianType)Enum.Parse(typeof(GuardianType), v));
            builder.Property(s => s.SchoolYear)
                .IsRequired().HasConversion(
                    v => v.ToString(),
                    v => (SchoolYear)Enum.Parse(typeof(SchoolYear), v));

            builder.HasMany(s => s.LessonPurchases)
                .WithOne(lp => lp.student)
                .HasForeignKey(lp => lp.StdId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.examSubmissions)
                .WithOne(lp => lp.student)
                .HasForeignKey(lp => lp.studentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Progresses)
                .WithOne(lp => lp.Student)
                .HasForeignKey(lp => lp.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.enrollments)
                .WithOne(lp => lp.Student)
                .HasForeignKey(lp => lp.StdId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(s=>s.Id)
                .IsUnique();

        }
    }
}
