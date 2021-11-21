using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Models;
using static VUY9FY_HFT_2021221.Repository.IRepository;

namespace VUY9FY_HFT_2021221.Logic
{
    public class ArtistLogic : IArtistLogic
    {
        IArtistRepository artistRepository;

        public ArtistLogic(IArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }
        public void Create(artist artist)
        {
            artistRepository.Create(artist);
        }

        public void Delete(int id)
        {
            artistRepository.Delete(id);
        }

        public IEnumerable<KeyValuePair<bool, int>> ArtistCountByIsBand()
        {
            return from artist in artistRepository.GetAll() group artist by artist.IsBand into g select new KeyValuePair<bool, int>(g.Key, g.Count());
        }

        public IQueryable<artist> GetAll()
        {
            return artistRepository.GetAll();
        }

        public artist GetOne(int id)
        {
            return artistRepository.GetOne(id);
        }

        public void Update(artist artist)
        {
            artistRepository.Update(artist);
        }
    }
}
