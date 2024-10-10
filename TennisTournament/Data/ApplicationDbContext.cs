using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using TennisTournament.DTO;
using TennisTournament.Models;
using TennisTournament.Services;

namespace TennisTournament.Data
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public Microsoft.EntityFrameworkCore.DbSet<Player> Players { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Tournament> Tournaments { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<TournamentDTO> TournamentResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Player>();
            modelBuilder.Entity<Man>().ToTable("Men");
            modelBuilder.Entity<Woman>().ToTable("Women");

            modelBuilder.Entity<Tournament>()
                .HasKey(t => t.Id); 

           

            modelBuilder.Entity<Man>()
            .HasKey(m => m.Id);

            modelBuilder.Entity<Woman>()
                .HasKey(w => w.Id);
        }
    }
}
