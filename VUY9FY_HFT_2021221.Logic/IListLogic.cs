using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Models;

namespace VUY9FY_HFT_2021221.Logic
{
    public interface IListLogic
    {
        list GetOne(int year, int score);
        IQueryable<list> GetAll();
        void Create(list list);
        void Delete(int year, int score);
    }
}
