using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Models;

namespace VUY9FY_HFT_2021221.Logic
{
    public interface IArtistLogic
    {
        artist GetOne(int id);
        IQueryable<artist> GetAll();
        void Create(artist artist);
        void Delete(int id);
        void Update(artist artist);
    }
}
