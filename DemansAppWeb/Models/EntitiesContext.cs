
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;
using DemansAppWeb.Models.Map;
using DemansAppWeb.Models;

namespace DemansAppWeb.Models
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext(DbContextOptions<EntitiesContext> options) : base(options)
        {
            //ChangeTracker.AutoDetectChangesEnabled = true;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommandsMap());
            modelBuilder.ApplyConfiguration(new CompanionsMap());
            modelBuilder.ApplyConfiguration(new LocationInformationMap());
            modelBuilder.ApplyConfiguration(new MedicinesMap());
            modelBuilder.ApplyConfiguration(new MotivationSentencesMap());
            modelBuilder.ApplyConfiguration(new PicturesMap());
            modelBuilder.ApplyConfiguration(new TracesOfLoveMap());
            modelBuilder.ApplyConfiguration(new UsersMap());

            base.OnModelCreating(modelBuilder);
        }


        //....
        public DbSet<Commands> Commands { get; set; }
        public DbSet<Companions> Companions { get; set; }
        public DbSet<LocationInformation> LocationInformation { get; set; }
        public DbSet<Medicines> Medicines { get; set; }
        public DbSet<MotivationSentences> MotivationSentences { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<TracesOfLove> TracesOfLove { get; set; }
        public DbSet<Users> Users { get; set; }
       
    }
}
