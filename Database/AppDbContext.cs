using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FichePlanning> FichePlannings { get; set; }
        public DbSet<Filiale> Filiales { get; set; }
        public DbSet<Fonction> Fonctions { get; set; }
        public DbSet<Periode> Periodes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilisateur>()
                .HasOne(u => u.Fonction)
                .WithMany(f => f.Utilisateurs)
                .HasForeignKey(u => u.FkFonction)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FichePlanning>()
                .HasOne(fp => fp.Utilisateur)
                .WithMany(u => u.FichePlannings)
                .HasForeignKey(fp => fp.FkUtilisateur)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FichePlanning>()
                .HasOne(fp => fp.Filiale)
                .WithMany(f => f.FichePlannings)
                .HasForeignKey(fp => fp.FkFiliale)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Periode>()
                .HasOne(p => p.FichePlanning)
                .WithMany(fp => fp.Periodes)
                .HasForeignKey(p => p.FkPlanning)
                .OnDelete(DeleteBehavior.Cascade);
        }
    
}

}
   