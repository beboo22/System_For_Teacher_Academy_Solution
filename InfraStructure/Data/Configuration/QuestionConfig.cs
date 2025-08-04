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
    internal class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.ID);
            builder.HasIndex(q => q.ID);
            builder.Property(q => q.Text).IsRequired().HasMaxLength(500);
            builder.Property(q => q.Type).IsRequired().HasMaxLength(50);
            builder.Property(q => q.Options).IsRequired().HasMaxLength(1000);
            builder.Property(q => q.Marks).IsRequired();
            builder.Property(q => q.CorrectAnswer).IsRequired().HasMaxLength(500);
            builder.Property(q => q.Order).IsRequired();
            
            // Relationships
            builder.HasOne(q => q.Exam)
                   .WithMany(e => e.ExamQuestions)
                   .HasForeignKey(q => q.ExId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
