using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Logic;
using VUY9FY_HFT_2021221.Models;


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

        // GET /artist/2
        [HttpGet("{id}")]
        public artist Get(int id)
        {
            return al.GetOne(id);
        }

        // POST /artist
        [HttpPost]
        public void Post([FromBody] artist value)
        {
            al.Create(value);
        }

        // PUT /artist
        [HttpPut]
        public void Put([FromBody] artist value)
        {
            al.Update(value);
        }

        // DELETE /artist/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            al.Delete(id);
        }
    }
}
