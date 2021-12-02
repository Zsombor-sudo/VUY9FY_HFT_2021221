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
    public class ListController : ControllerBase
    {
        IListLogic ll;
        public ListController(IListLogic ll)
        {
            this.ll = ll;
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
            ll.Delete(year, score);
        }
    }
}
