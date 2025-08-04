using Domin.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data.Configuration
{
    internal class ExamConfig : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasIndex(e => e.ID);
            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.Title)
                .HasMaxLength(500);

            builder.Property(e => e.StartDate)
                //.HasDefaultValueSql("DATETIME")
                .IsRequired();
            builder.Property(e => e.EndDate)
                //.HasDefaultValueSql("DATETIME")
                .IsRequired();
            builder.Property(e => e.ClickStart);
                //.HasDefaultValueSql("DATETIME");

            builder.HasOne(builder => builder.Courses)
                .WithMany(q => q.exams)
                .HasForeignKey(q => q.CrsId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(e => e.examSubmissions)
                .WithOne(q => q.exam)
                .HasForeignKey(q => q.ExId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(e => e.ExamQuestions)
                .WithOne(q => q.Exam)
                .HasForeignKey(q => q.ExId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
