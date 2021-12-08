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
            if (!artistRepository.GetAll().Select(x => x.Id).Contains(id))
            {
                throw new ArgumentException("The id you entered is invalid.");
            }
            artistRepository.Delete(id);
        }

        public IQueryable<artist> GetAll()
        {
            if (artistRepository.GetAll() == null)
            {
                throw new ArgumentException("This table is empty.");
            }
            return artistRepository.GetAll();
        }

        public artist GetOne(int id)
        {
            if (!artistRepository.GetAll().Select(x => x.Id).Contains(id))
            {
                throw new ArgumentException("The id you entered is invalid.");
            }
            return artistRepository.GetOne(id);
        }

        public void Update(artist artist)
        {
            artistRepository.Update(artist);
        }
    }
}
