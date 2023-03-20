using GmJournal.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace GmJournal.Data.Configuration
{
    public class GmJournalDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<World> Worlds { get; set; }
        public virtual DbSet<Character> Characters{ get; set; }
        public virtual DbSet<Item> Items { get; set; }

        public GmJournalDbContext(DbContextOptions<GmJournalDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=GmJournal.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Relations for User entity
            modelBuilder.Entity<User>()
                .HasMany(u => u.Worlds)
                .WithOne(w => w.Owner);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Characters)
                .WithOne(w => w.Owner);


            //Relations for World entity
            modelBuilder.Entity<World>()
                .HasMany(w => w.Users)
                .WithMany();

            modelBuilder.Entity<World>()
                .HasMany(w => w.Characters)
                .WithOne(c => c.World);


            //Relations for Character entity
            modelBuilder.Entity<Character>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Owner);

            modelBuilder.Entity<Character>()
                .HasOne(c => c.Owner)
                .WithMany();

            modelBuilder.Entity<Character>()
                .HasOne(c => c.World)
                .WithMany();


            //Relations for Item entity
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Owner)
                .WithMany();
        }
    }
}
