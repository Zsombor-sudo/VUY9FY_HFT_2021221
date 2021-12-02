using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Models;

namespace VUY9FY_HFT_2021221.Data
{
    public partial class SongDbContext : DbContext
    {
        //tables
        public virtual DbSet<song> Songs { get; set; }
        public virtual DbSet<artist> Artists { get; set; }
        public virtual DbSet<list> Lists { get; set; }

        public SongDbContext()
        {
            //tudom hogy nem fut le de egyszerűen ötletem sincs mi a hiba
            this.Database.EnsureCreated();
        }

        public SongDbContext(DbContextOptions<SongDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SongDB.mdf;Integrated Security=True";
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<song>(entity =>
            {
                entity.HasOne(song => song.Artist)
                    .WithMany(artist => artist.Songs)
                    .HasForeignKey(song => song.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<list>(entity =>
            {
                entity.HasOne(list => list.Song)
                    .WithOne(song => song.Score)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<list>().HasKey(list => new { list.Year, list.Score });

            artist denzelCurry = new artist() { Id = 1, Name = "Denzel Curry", IsBand = false};
            artist kanyeWest = new artist() { Id = 2, Name = "Kanye West", IsBand = false };
            artist adele = new artist() { Id = 3, Name = "Adele", IsBand = false };
            artist leanderKills = new artist() { Id = 4, Name = "Leander Kills", IsBand = true };

            song denzelCurry1 = new song() { SongId = 1, ArtistId = denzelCurry.Id, Title = "Wig Split", Release = 2021 };
            song denzelCurry2 = new song() { SongId = 2, ArtistId = denzelCurry.Id, Title = "Speedboat", Release = 2019 };
            song kanyeWest1 = new song() { SongId = 3, ArtistId = kanyeWest.Id, Title = "Off The Grid", Release = 2021 };
            song kanyeWest2 = new song() { SongId = 4, ArtistId = kanyeWest.Id, Title = "Gold Digger", Release = 2005 };
            song adele1 = new song() { SongId = 5, ArtistId = adele.Id, Title = "Easye On Me", Release = 2021 };
            song adele2 = new song() { SongId = 6, ArtistId = adele.Id, Title = "Someone Like You", Release = 2011 };
            song leanderKills1 = new song() { SongId = 7, ArtistId = leanderKills.Id, Title = "Szeresd Bennem", Release = 2016 };
            song leanderKills2 = new song() { SongId = 8, ArtistId = leanderKills.Id, Title = "Luxusnyomor", Release = 2019 };

            list list1 = new list() { Year = 2021, Score = 3, SongId = kanyeWest1.SongId };
            list list2 = new list() { Year = 2020, Score = 1, SongId = adele1.SongId };
            list list3 = new list() { Year = 2005, Score = 1, SongId = kanyeWest2.SongId };

            modelBuilder.Entity<artist>().HasData(denzelCurry, kanyeWest, adele, leanderKills);
            modelBuilder.Entity<song>().HasData(denzelCurry1, denzelCurry2, kanyeWest1, kanyeWest2, adele1, adele2, leanderKills1, leanderKills2);
            modelBuilder.Entity<list>().HasData(list1, list2, list3);
        }
    }
}
