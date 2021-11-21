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
    public class ListRepository : IListRepository
    {
        SongDbContext ctx;
        public ListRepository(SongDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(list list)
        {
            ctx.Lists.Add(list);
            ctx.SaveChanges();
        }

        public void Delete(int year, int score)
        {
            var listToDelete = GetOne(year, score);
            ctx.Lists.Remove(listToDelete);
            ctx.SaveChanges();
        }

        public IQueryable<list> GetAll()
        {
            return ctx.Lists;
        }

        public list GetOne(int year, int score)
        {
            return ctx.Lists.FirstOrDefault(x => x.Year == year && x.Score == score);
        }

        public void Update(list list)
        {
            //there are no attributes to be changed (both are keys)
        }
    }
}
