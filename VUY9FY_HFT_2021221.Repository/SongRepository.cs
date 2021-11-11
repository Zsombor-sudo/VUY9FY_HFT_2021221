using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Data;
using VUY9FY_HFT_2021221.Models;
using static VUY9FY_HFT_2021221.Repository.IRepository;

namespace VUY9FY_HFT_2021221.Repository
{
    public class SongRepository : ISongRepository
    {
        SongDbContext ctx;
        public SongRepository(SongDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(song song)
        {
            ctx.Songs.Add(song);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var songToDelete = GetOne(id);
            ctx.Songs.Remove(songToDelete);
            ctx.SaveChanges();
        }

        public IQueryable<song> GetAll()
        {
            return ctx.Songs;
        }

        public song GetOne(int id)
        {
            return ctx.Songs.FirstOrDefault(x => x.SongId == id);
        }

        public void Update(song song)
        {
            var songToUpdate = GetOne(song.SongId);
            songToUpdate.Title = song.Title;
            songToUpdate.Release = song.Release;
            songToUpdate.ArtistId = song.ArtistId;
            ctx.SaveChanges();
        }
    }
}