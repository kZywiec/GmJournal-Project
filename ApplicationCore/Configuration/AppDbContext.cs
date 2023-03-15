using VTT.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace VTT.Data.Configuration
{
    internal class VTTDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<World> Worlds { get; set; }
        public virtual DbSet<Character> Characters{ get; set; }
        public virtual DbSet<Item> Items { get; set; }

        public VTTDbContext(DbContextOptions<VTTDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=VTT.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Worlds)
                .WithOne(w => w.Owner);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Characters)
                .WithOne(w => w.Owner);



            modelBuilder.Entity<World>()
                .HasMany(w => w.Users)
                .WithMany();

            modelBuilder.Entity<World>()
                .HasMany(w => w.Characters)
                .WithOne(c => c.World);



            modelBuilder.Entity<Character>()
                .HasOne(c => c.Owner)
                .WithMany(u => u.Characters);

            modelBuilder.Entity<Character>()
                .HasOne(c => c.World)
                .WithMany(w => w.Characters);
        }

    }
}
