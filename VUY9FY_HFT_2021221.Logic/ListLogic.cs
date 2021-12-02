using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Models;
using static VUY9FY_HFT_2021221.Repository.IRepository;

namespace VUY9FY_HFT_2021221.Logic
{
    public class ListLogic : IListLogic
    {
        IListRepository listRepository;
        public ListLogic(IListRepository listRepository)
        {
            this.listRepository = listRepository;
        }

        public void Create(list list)
        {
            listRepository.Create(list);
        }

        public void Delete(int year, int score)
        {
            listRepository.Delete(year, score);
        }

        public IQueryable<list> GetAll()
        {
            return listRepository.GetAll();
        }

        public list GetOne(int year, int score)
        {
            return listRepository.GetOne(year, score);
        }
    }
}
