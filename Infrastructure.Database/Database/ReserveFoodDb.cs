using Domain.Entities.AddressAggreagte;
using Domain.Entities.FoodAggregate;
using Domain.Entities.FoodCategoryAggregate;
using Domain.Entities.OperatoreAggregate;
using Domain.Entities.PersonAggregate;
using Domain.Entities.ReciveAggregate;
using Domain.Entities.ReserveAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Database
{
    public class ReserveFoodDb : DbContext
    {
        public ReserveFoodDb(DbContextOptions<ReserveFoodDb> options) : base(options) { }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<Recive> Recives { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recive>().HasKey(r=>r.ReserveId);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
