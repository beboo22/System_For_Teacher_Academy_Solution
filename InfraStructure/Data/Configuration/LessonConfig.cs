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
    internal class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.ID);
            builder.HasIndex(l => l.ID);
            builder.Property(l => l.Description).IsRequired().HasMaxLength(500);
            builder.Property(l => l.Title).IsRequired().HasMaxLength(200);
            builder.Property(l => l.URL).IsRequired().HasMaxLength(500);
            builder.Property(l => l.Duration).IsRequired();
            builder.Property(l => l.Order).IsRequired();
            builder.Property(l => l.ContentUrl).IsRequired().HasMaxLength(500);
            builder.Property(l => l.Price).HasColumnType("decimal(18,2)").IsRequired();
            // Relationships
            builder.HasOne(l => l.course)
                   .WithMany(c => c.lessons)
                   .HasForeignKey(l => l.CrsId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(l => l.Progresses)
                   .WithOne(p => p.lesson)
                   .HasForeignKey(p => p.LessonId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
