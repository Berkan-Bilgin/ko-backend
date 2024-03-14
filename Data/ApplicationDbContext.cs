using ko_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;


namespace ko_backend.Data

{


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<EpisodeCharacter> EpisodeCharacters { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>().HasData(
               new() { Id = 1, Name = "Rick", Species = "Human" },
               new() { Id = 2, Name = "Morty", Species = "Human" }
           );



            // EpisodeCharacter ara tablosunun bileşik anahtarı
            modelBuilder.Entity<EpisodeCharacter>()
                .HasKey(ec => new { ec.EpisodeId, ec.CharacterId });

            // Episode ile EpisodeCharacter arasındaki ilişki
            modelBuilder.Entity<EpisodeCharacter>()
                .HasOne(ec => ec.Episode)
                .WithMany(e => e.EpisodeCharacters)
                .HasForeignKey(ec => ec.EpisodeId);

            // Character ile EpisodeCharacter arasındaki ilişki
            modelBuilder.Entity<EpisodeCharacter>()
                .HasOne(ec => ec.Character)
                .WithMany(c => c.EpisodeCharacters)
                .HasForeignKey(ec => ec.CharacterId);
        }
    }
}
