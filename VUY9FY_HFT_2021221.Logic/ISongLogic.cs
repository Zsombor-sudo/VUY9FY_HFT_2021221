using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Models;

namespace VUY9FY_HFT_2021221.Logic
{
    public interface ISongLogic
    {
        song GetOne(int id);
        IQueryable<song> GetAll();
        void Create(song song);
        void Delete(int id);
        void Update(song song);
        public bool WasSongNominatedInSameYear(string title);
        bool WasSongsNomininatedInYear(string title, int year);
        List<string> SongScored5();
        List<string> SongsByBands();
        int SongsByBandsCount();
        double SongScoreAvg();
    }
}
