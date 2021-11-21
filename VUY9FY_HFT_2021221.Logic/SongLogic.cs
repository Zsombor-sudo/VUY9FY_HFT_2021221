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
            songRepository.Create(song);
        }

        public void Delete(int id)
        {
            songRepository.Delete(id);
        }

        public IQueryable<song> GetAll()
        {
            return songRepository.GetAll();
        }

        public song GetOne(int id)
        {
            return songRepository.GetOne(id);
        }

        public bool IsSongByBand(string songTitle)
        {
            artist artist = songRepository.GetAll().FirstOrDefault(x => x.Title == songTitle).Artist;
            return artist.IsBand;
        }

        public int SongsByYearCount(int year)
        {
            return songRepository.GetAll().Count(x => x.Release == year); ;
        }

        public void Update(song song)
        {
            songRepository.Update(song);
        }
    }
}
