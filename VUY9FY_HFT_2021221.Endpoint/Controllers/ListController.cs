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
    public class ListController : ControllerBase
    {
        IListLogic ll;
        IHubContext<SignalRHub> hub;
        public ListController(IListLogic ll, IHubContext<SignalRHub> hub)
        {
            this.ll = ll;
            this.hub = hub;
        }

        // GET: /list
        [HttpGet]
        public IEnumerable<list> Get()
        {
            return ll.GetAll();
        }

        // GET /list/3, 2021
        [HttpGet("{scoreyear}")]
        public list Get(string scoreyear)
        {
            int year = int.Parse(scoreyear.Substring(scoreyear.Length - 4));
            int score = int.Parse(scoreyear.Substring(0,scoreyear.Length - 4));

            return ll.GetOne(year, score);
        }

        // POST /list
        [HttpPost]
        public void Post([FromBody] list value)
        {
            ll.Create(value);
            this.hub.Clients.All.SendAsync("ListCreated", value);
        }

        // PUT /list
        [HttpPut]
        public void Put([FromBody] list value)
        {
            //no update, no put
        }

        // DELETE list/3, 2021
        [HttpDelete("{scoreyear}")]
        public void Delete(string scoreyear)
        {
            
            int year = int.Parse(scoreyear.Substring(scoreyear.Length - 4));
            int score = int.Parse(scoreyear.Substring(0, scoreyear.Length - 4));
            var listToDelete = ll.GetOne(year, score);
            ll.Delete(year, score);
            this.hub.Clients.All.SendAsync("ListDeleted", listToDelete);
        }
    }
}
