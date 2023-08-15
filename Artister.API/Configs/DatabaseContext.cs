using Artister.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Artister.API.Configs
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Subgenre> Subgenres { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArtistModelConfigure(modelBuilder);
            GenreModelConfigure(modelBuilder);
            NotificationsModelConfigure(modelBuilder);
            SubgenreModelConfigure(modelBuilder);
            UserModelConfigure(modelBuilder);
        }
        private void ArtistModelConfigure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Artist>()
                .Property(x => x.YearOfOrigin)
                .IsRequired();

            modelBuilder.Entity<Artist>()
                .Property(x => x.UserAddedId)
                .IsRequired();
        }
        private void GenreModelConfigure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .Property(x => x.Name)
                .IsRequired();
        }
        private void SubgenreModelConfigure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subgenre>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Subgenre>()
                .Property(x => x.GenreId)
                .IsRequired();
        }
        private void NotificationsModelConfigure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>()
                .HasNoKey();
        }
        private void UserModelConfigure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Name)
                .IsRequired();
        }
    }
}
