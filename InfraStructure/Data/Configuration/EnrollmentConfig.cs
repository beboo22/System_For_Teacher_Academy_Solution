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
    internal class EnrollmentConfig : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasIndex(e => e.ID);
            // Setting properties for Enrollment
            builder.Property(e => e.EnrollmentDay)
                //.HasDefaultValueSql("DATETIME")
                .IsRequired();
            
            // Relationships
            builder.HasOne(e => e.Student)
                   .WithMany(s => s.enrollments)
                   .HasForeignKey(e => e.StdId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Course)
                   .WithMany(c => c.enrollments)
                   .HasForeignKey(e => e.CrsId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
