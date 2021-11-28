using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VUY9FY_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        ISongLogic sl;
        public QueryController(ISongLogic sl)
        {
            this.sl = sl;
        }

        // GET: query/songbyyearcount
        [HttpGet("{year}")]
        public int SongByYearCount(int year)
        {
            return sl.SongsByYearCount(year);
        }

        // GET: query/issongbyband
        [HttpGet("{songTitle}")]
        public bool IsSongByBand(string songTitle)
        {
            return sl.IsSongByBand(songTitle);
        }

    }
}
