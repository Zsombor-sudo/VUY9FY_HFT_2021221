using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Logic;
using VUY9FY_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VUY9FY_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        IArtistLogic al;
        public ArtistController(IArtistLogic al)
        {
            this.al = al;
        }

        // GET: /artist
        [HttpGet]
        public IEnumerable<artist> Get()
        {
            return al.GetAll();
        }

        // GET /song/5
        [HttpGet("{id}")]
        public artist Get(int id)
        {
            return al.GetOne(id);
        }

        // POST /car
        [HttpPost]
        public void Post([FromBody] artist value)
        {
            al.Create(value);
        }

        // PUT /song
        [HttpPut]
        public void Put([FromBody] artist value)
        {
            al.Update(value);
        }

        // DELETE artist/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            al.Delete(id);
        }
    }
}
