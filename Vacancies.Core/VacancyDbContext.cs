using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Vacancies.Domain.Entities;

namespace Vacancies.Core
{
    public class VacancyDbContext : DbContext
    {
        public VacancyDbContext(DbContextOptions<VacancyDbContext> options)
        : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<Vacancy> Vacancies { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<CVFile> CVFiles { get; set; }

        public DbSet<ApplicationForm> ApplicationForms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Option>()
                .HasOne(o => o.Question)
                .WithMany(q => q.Options)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vacancy>()
                .HasMany(v => v.Users)
                .WithMany(u => u.Vacancies)
                .UsingEntity<Answer>();


            base.OnModelCreating(modelBuilder);
        }
    }
}
