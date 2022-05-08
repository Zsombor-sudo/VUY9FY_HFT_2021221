using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;
        public ArtistController(IArtistLogic al, IHubContext<SignalRHub> hub)
        {
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("ArtistCreated", value);
        }

        // PUT /artist
        [HttpPut]
        public void Put([FromBody] artist value)
        {
            al.Update(value);
            this.hub.Clients.All.SendAsync("ArtistUpdated", value);
        }

        // DELETE /artist/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var artistToDelete = al.GetOne(id);
            al.Delete(id);

            this.hub.Clients.All.SendAsync("ArtistDeleted", artistToDelete);
        }
    }
}
