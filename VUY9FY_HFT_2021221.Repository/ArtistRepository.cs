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
    public class ArtistRepository : IArtistRepository
    {
        SongDbContext ctx;
        public ArtistRepository(SongDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(artist artist)
        {
            ctx.Artists.Add(artist);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            artist artistToDelete = GetOne(id);
            ctx.Artists.Remove(artistToDelete);
            ctx.SaveChanges();
        }

        public IQueryable<artist> GetAll()
        {
            return ctx.Artists;
        }

        public artist GetOne(int id)
        {
            return ctx.Artists.FirstOrDefault(x => x.Id == id);
        }

        public void Update(artist artist)
        {
            var artistToUpdate = GetOne(artist.Id);
            artistToUpdate.Name = artist.Name;
            artistToUpdate.IsBand = artist.IsBand;
            ctx.SaveChanges();
        }
    }
}
