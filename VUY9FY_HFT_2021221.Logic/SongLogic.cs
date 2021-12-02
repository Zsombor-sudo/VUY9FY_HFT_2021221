using System;
using System.Collections.Generic;
using System.Linq;
using VUY9FY_HFT_2021221.Models;
using VUY9FY_HFT_2021221.Repository;
using static VUY9FY_HFT_2021221.Repository.IRepository;

namespace VUY9FY_HFT_2021221.Logic
{
    public class SongLogic : ISongLogic
    {
        ISongRepository songRepository;

        public SongLogic(ISongRepository songRepository)
        {
            this.songRepository = songRepository;
        }

        public void Create(song song)
        {
            if (song.Release < 0)
            {
                throw new ArgumentException("Negative release year is invalid.");
            }
            songRepository.Create(song);
        }

        public void Delete(int id)
        {
            if (!songRepository.GetAll().Select(x => x.SongId).Contains(id))
            {
                throw new ArgumentException("The id you entered is invalid.");
            }
            songRepository.Delete(id);
        }

        public IQueryable<song> GetAll()
        {
            if (songRepository.GetAll() == null)
            {
                throw new ArgumentException("This table is empty.");

            }
            return songRepository.GetAll();
        }

        public song GetOne(int id)
        {
            if (!songRepository.GetAll().Select(x => x.SongId).Contains(id))
            {
                throw new ArgumentException("The id you entered is invalid.");
            }
            return songRepository.GetOne(id);
        }

        public void Update(song song)
        {
            if (song.Release < 0)
            {
                throw new ArgumentException("Negative release year is invalid.");
            }
            songRepository.Update(song);
        }

        public bool WasSongNominatedInSameYear(string title)
        {
            int year = songRepository.GetAll().Where(x => x.Title == title).Select(x => x.Release).First();
            if (songRepository.GetAll().Where(x => x.Title == title).Select(x => x.Score.Year).First() == year)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool WasSongsNomininatedInYear(string title, int year)
        {
            foreach (list list in songRepository.GetAll().Where(x => x.Title == title).Select(x => x.Score))
            {
                if (list.Year == year)
                {
                    return true;
                }
            }
            return false;
          
        }
        public List<string> SongScored5()
        {
            return songRepository.GetAll().Where(x => x.Score.Score == 5).Select(x => x.Title).ToList();
        }
        public double SongScoreAvg()
        {
            return songRepository.GetAll().Select(x => x.Score.Score).Average();
        }
        public List<string> SongsByBands()
        {
            List<string> list = songRepository.GetAll().Where(x => x.Artist.IsBand == true).Select(x => x.Title).ToList();
            return list;
        }
        public int SongsByBandsCount()
        {
            int count = songRepository.GetAll().Where(x => x.Artist.IsBand == true).Count();
            return count;
        }

        
    }
}
