using Microsoft.EntityFrameworkCore;

namespace FitnessGyms.Infrastructure.Persistence
{
    public class FitnessGymsDbContext : DbContext
    {
        public FitnessGymsDbContext(DbContextOptions<FitnessGymsDbContext> options) : base(options)
        {

        }
        public DbSet<Domain.Entities.FitnessGym> FitnessGyms { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; Initial Catalog = FitnessGymStorage; Integrated Security = True;Encrypt=False;" +
        //        "TrustServerCertificate=True;MultipleActiveResultSets=True");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Domain.Entities.FitnessGym>()
                .OwnsOne(c => c.ContactDetails);

     
        }
    }
}
