using Microsoft.EntityFrameworkCore;

namespace Tepe.Brt.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<RecommendationEntity>()
            //    .HasOne<PatientEntity>(s => s.Patient)
            //    .WithMany(g => g.Recommendations);
        }

        #region Entities
        public DbSet<UserEntity> Users { get; set; }
        #endregion

    }
}
