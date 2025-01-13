using HrManagement.Core.ModelEntities.Candidate;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Infrastructure.DBContext
{
    public class EntityFrameworkDbContext(DbContextOptions<EntityFrameworkDbContext> options) : DbContext(options)
    {
        public DbSet<CandidateInfo> CandidateInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateInfo>()
           .HasIndex(r => r.Email)
           .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
