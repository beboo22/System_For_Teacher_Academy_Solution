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
    internal class ExamSubmissionConfig : IEntityTypeConfiguration<ExamSubmission>
    {
        public void Configure(EntityTypeBuilder<ExamSubmission> builder)
        {
            builder.Property(e => e.SubmittedAt)
                //.HasDefaultValueSql("DATETIME")
                .IsRequired();

            builder.Property(e=>e.studentId)
                .IsRequired();
            builder.Property(e => e.ExId)
                .IsRequired();
            builder.HasIndex(q => q.ID);


            builder.Property(e => e.Feedback)
                .HasMaxLength(int.MaxValue);

            builder.HasOne(e => e.exam)
                .WithMany(e => e.examSubmissions)
                .HasForeignKey(e => e.ExId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.student)
                .WithMany(e => e.examSubmissions)
                .HasForeignKey(e => e.studentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(builder => builder.Answer)
                .WithOne(q => q.examSubmission)
                .HasForeignKey(q => q.ExamSubmissionId)
                .OnDelete(DeleteBehavior.Cascade);





        }
    }
}
