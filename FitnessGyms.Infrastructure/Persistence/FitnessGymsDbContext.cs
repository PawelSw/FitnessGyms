using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessGyms.Infrastructure.Persistence
{
    public class FitnessGymsDbContext : IdentityDbContext
    {
        public FitnessGymsDbContext(DbContextOptions<FitnessGymsDbContext> options) : base(options)
        {

        }
        public DbSet<Domain.Entities.FitnessGym> FitnessGyms { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Domain.Entities.FitnessGym>()
                .OwnsOne(c => c.ContactDetails);

     
        }
    }
}
