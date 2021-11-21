using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Models;

namespace VUY9FY_HFT_2021221.Repository
{
    public interface IRepository
    {
        public interface IRepository<T> where T : class
        {
            T GetOne(int id);
            IQueryable<T> GetAll();
            void Create(T copy);
            void Delete(int id);
            void Update(T copy);

        }

        public interface ISongRepository : IRepository<song>
        {
            song GetOne(int id);
            IQueryable<song> GetAll();
            void Create(song song);
            void Delete(int id);
            void Update(song song);
        }
        public interface IArtistRepository : IRepository<artist>
        {
            artist GetOne(int id);
            IQueryable<artist> GetAll();
            void Create(artist artist);
            void Delete(int id);
            void Update(artist artist);
        }
        public interface IListRepository 
        {
            list GetOne(int year, int score);
            IQueryable<list> GetAll();
            void Create(list list);
            void Delete(int year, int score);
            void Update(list list);
        }
    }
}
