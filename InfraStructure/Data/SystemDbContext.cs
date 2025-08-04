using Domin.Entity;
using Domin.Entity.identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Data
{
    internal class SystemDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        // DbSet properties for your entities
        //public DbSet<AppUser> appUsers { get; set; }
        public DbSet<Students> students { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<Exam> exams { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Question> questions { get; set; }

        public DbSet<Answer> answers { get; set; }
        public DbSet<ExamSubmission> examSubmissions { get; set; }
        public DbSet<Progress> progresses { get; set; }
        public DbSet<Message> messages { get; set; }

        public DbSet<LessonPurchase> lessonPurchases { get; set; }



        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(SystemDbContext).Assembly);
        }
    }
}
