﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumZawody.Models
{
    public class ChampionshipDbContext : DbContext
    {
        public DbSet<Championship> Championships { get; set; }
        public DbSet<ChampionshipTeam> ChampionshipTeams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
        public DbSet<Team> Teams { get; set; }

        public ChampionshipDbContext() { }

        public ChampionshipDbContext(DbContextOptions options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasKey(p => p.IdPlayer); //klucz główny
                opt.Property(p => p.IdPlayer)
                    .ValueGeneratedOnAdd(); //automatycznie generowany przy wstawianiu
                opt.Property(p => p.FirstName)
                    .HasMaxLength(30)
                    .IsRequired();
                opt.Property(p => p.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
                opt.HasMany(p => p.PlayerTeams)
                    .WithOne(p => p.Player)
                    .HasForeignKey(p => p.IdPlayer);
            });

            modelBuilder.Entity<PlayerTeam>(opt =>
            {
                opt.HasKey(p => new { 
                    p.IdPlayer,
                    p.IdTeam
                });
                opt.Property(p => p.Comment)
                    .HasMaxLength(300);                    
            });

            modelBuilder.Entity<Team>(opt =>
            {
                opt.HasKey(p => p.IdTeam); //klucz główny
                opt.Property(p => p.IdTeam)
                    .ValueGeneratedOnAdd(); //automatycznie generowany przy wstawianiu              
                opt.Property(p => p.TeamName)
                    .HasMaxLength(30)
                    .IsRequired();
                opt.HasMany(p => p.PlayerTeams)
                   .WithOne(p => p.Team)
                   .HasForeignKey(p => p.IdTeam);
                opt.HasMany(p => p.ChampionshipTeams)
                   .WithOne(p => p.Team)
                   .HasForeignKey(p => p.IdTeam);
            });

            modelBuilder.Entity<ChampionshipTeam>(opt =>
            {
                opt.HasKey(p => new {
                    p.IdTeam,
                    p.IdChampionship
                });

            });

            modelBuilder.Entity<Championship>(opt =>
            {
                opt.HasKey(p => p.IdChampionship); //klucz główny
                opt.Property(p => p.IdChampionship)
                    .ValueGeneratedOnAdd(); //automatycznie generowany przy wstawianiu              
                opt.Property(p => p.OfficialName)
                    .HasMaxLength(100)
                    .IsRequired();
                opt.HasMany(p => p.ChampionshipTeams)
                   .WithOne(p => p.Championship)
                   .HasForeignKey(p => p.IdChampionship);
            });

            Seed(modelBuilder);

        }

        private void Seed(ModelBuilder modelBuilder)
        {

            //championships
            List<Championship> championships = new List<Championship>();
            championships.Add(new Championship { IdChampionship = 1, OfficialName = "pilka", Year = 1990 });
            championships.Add(new Championship { IdChampionship = 2, OfficialName = "siatkowka", Year = 1994 });

            modelBuilder.Entity<Championship>().HasData(championships);

            //teams
            List<Team> teams = new List<Team>();
            teams.Add(new Team { IdTeam = 1, TeamName = "Misie", MaxAge = 12});
            teams.Add(new Team { IdTeam = 2, TeamName = "Ptysie", MaxAge = 15 });
            teams.Add(new Team { IdTeam = 3, TeamName = "Rysie", MaxAge = 18 });

            modelBuilder.Entity<Team>().HasData(teams);

            //championshipsTeams
            List<ChampionshipTeam> championshipsTeams = new List<ChampionshipTeam>();
            championshipsTeams.Add(new ChampionshipTeam
                                { IdTeam = 1, IdChampionship = 1, Score = 70 });
            championshipsTeams.Add(new ChampionshipTeam
                                { IdTeam = 2, IdChampionship = 1, Score = 60 });
            championshipsTeams.Add(new ChampionshipTeam
                                 { IdTeam = 2, IdChampionship = 2, Score = 40 });

            modelBuilder.Entity<ChampionshipTeam>().HasData(championshipsTeams);
        }

    }
}
