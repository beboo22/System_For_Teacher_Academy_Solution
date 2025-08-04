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
    internal class LessonPurchaseConfig : IEntityTypeConfiguration<LessonPurchase>
    {
        public void Configure(EntityTypeBuilder<LessonPurchase> builder)
        {
            builder.HasKey(lp => lp.ID);
            builder.HasIndex(q => q.ID);

            // Setting properties for LessonPurchase
            builder.Property(lp => lp.PaymentStatus).IsRequired().HasMaxLength(50);
            // Setting default values for PurchaseDate and AccessExpireDate
            builder.Property(lp => lp.PurchaseDate)
                //.HasDefaultValueSql("DATETIME")
                .IsRequired();

            builder.Property(lp => lp.AccessExpireDate)
                //.HasDefaultValueSql("GETDATE")
                .IsRequired();

            builder.Property(lp=>lp.PaymentStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (PaymentStatus)Enum.Parse(typeof(PaymentStatus), v))
                .IsRequired();


            // Relationships
            builder.HasOne(lp => lp.student)
                   .WithMany(s => s.LessonPurchases)
                   .HasForeignKey(lp => lp.StdId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(lp => lp.lesson)
                   .WithMany(l => l.LessonPurchases)
                   .HasForeignKey(lp => lp.LessonId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
