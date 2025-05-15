using ArbiTrack.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ArbiTrack.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={ApplicationDbContextFactory.GetFullDatabasePath()}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CategoryModel>()
            //    .HasMany(f => f.Tasks)
            //    .WithOne(f => f.Category)
            //    .HasForeignKey(f => f.CategoryId)
            //    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ImpossibleFutureAppModel> ImpossibleFutureApps { get; set; }
        public DbSet<LogModel> Logs { get; set; }
    }
}
