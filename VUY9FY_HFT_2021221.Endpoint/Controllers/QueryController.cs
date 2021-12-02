using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUY9FY_HFT_2021221.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VUY9FY_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        ISongLogic sl;
        public QueryController(ISongLogic sl)
        {
            this.sl = sl;
        }

        // GET: query/WasSongNominatedInSameYear/Speedboat
        [HttpGet("{title}")]
        public bool WasSongNominatedInSameYear(string title)
        {
            return sl.WasSongNominatedInSameYear(title);
        }

        // GET: query/WasSongsNominatedInYear/Easy On Me, 2020
        [HttpGet("{songTitle}, {year}")]
        public bool WasSongsNomininatedInYear(string title, int year)
        {
            return sl.WasSongsNomininatedInYear(title, year);
        }
        // GET: query/SongsScored5
        [HttpGet]
        public List<string> SongScored5()
        {
            return sl.SongScored5();
        }
        // GET: query/SongsByBands
        [HttpGet]
        public List<string> SongsByBands()
        {
            return sl.SongsByBands();
        }
        // GET: query/SongsByBandsCount
        [HttpGet]
        public int SongsByBandsCount()
        {
            return sl.SongsByBandsCount();
        }
        //GET: query/SongScoreAvg
        [HttpGet]
        public double SongScoreAvg()
        {
            return sl.SongScoreAvg();
        }
    }
}
