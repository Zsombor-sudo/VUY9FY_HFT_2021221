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
    public class SongController : ControllerBase
    {
        ISongLogic sl;
        IHubContext<SignalRHub> hub;
        public SongController(ISongLogic sl, IHubContext<SignalRHub> hub)
        {
            this.sl = sl;
            this.hub = hub;
        }

        // GET: /song
        [HttpGet]
        public IEnumerable<song> Get()
        {
            return sl.GetAll();
        }

        // GET /song/5
        [HttpGet("{id}")]
        public song Get(int id)
        {
            return sl.GetOne(id);
        }

        // POST /song
        [HttpPost]
        public void Post([FromBody] song value)
        {
            sl.Create(value);
            this.hub.Clients.All.SendAsync("SongCreated", value);
        }

        // PUT /song
        [HttpPut]
        public void Put([FromBody] song value)
        {
            sl.Update(value);
            this.hub.Clients.All.SendAsync("SongUpdated", value);
        }

        // DELETE song/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var songToDelete = this.sl.GetOne(id);
            sl.Delete(id);
            this.hub.Clients.All.SendAsync("SongDeleted", songToDelete);
        }
    }
}
