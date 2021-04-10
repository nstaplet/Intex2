using Intex.Models;
using Intex.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MummyBurialContext burialContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MummyBurialContext ctx)
        {
            _logger = logger;
            burialContext = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BurialSummaryList(int pageNum = 1)
        {
            int pageSize = 5;
            var SelectedBurials = burialContext.Burial;
            var pageBurials = SelectedBurials.Skip((pageNum - 1) * pageSize).Take(pageSize);
            List<BasicBurial> PackageBurials = new List<BasicBurial>();



            foreach (var sb in pageBurials)
            {

                PackageBurials.Add(
                    new BasicBurial
                    {
                        SingleBurial = sb,
                        SingleLocation = burialContext.Location.Where(b => b.LocationId == sb.LocationId).FirstOrDefault(),
                        SingleSublocation = burialContext.SubLocation.Where(b => b.SublocationId == sb.SublocationId).FirstOrDefault(),

                    });
            }
            

            return View(new BurialSummaryViewModel
            {
                Burials = PackageBurials,

            pageNumbering = new PageNumbering
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,

                    TotalNumItems = SelectedBurials.Count()
                }

            });
        }

        public IActionResult BurialDetails(int id) 
        {
            Burial burial = burialContext.Burial.Where(b => b.BurialId == id).FirstOrDefault();
            BasicBurial basicBurial = new BasicBurial
            {


                SingleBurial = burial,
                SingleLocation = burialContext.Location.Where(b => b.LocationId == burial.LocationId).FirstOrDefault(),
                SingleSublocation = burialContext.SubLocation.Where(b => b.SublocationId == burial.SublocationId).FirstOrDefault()
            };

            return View(basicBurial);
        }

        public IActionResult AddBurialLocation()
        {
            return View();
        }

        public IActionResult AddLocationInfo(Location lc, int burialnum, string subplot, int? areanum, string? tombnum)
        {
            if(ModelState.IsValid)
            {
                var checkLoc = burialContext.Location.Where(l =>
                l.BurialLocationNs == lc.BurialLocationNs &&
                l.LowValueNs == lc.LowValueNs &&
                l.HighValueNs == lc.HighValueNs &&
                l.BurialLocationEw == lc.BurialLocationEw &&
                l.LowValueEw == lc.LowValueEw &&
                l.HighValueEw == lc.HighValueEw).FirstOrDefault();

                int locid = 0;
                int sublocid = 0;

                if (checkLoc == null)
                {
                    burialContext.Location.Add(new Location
                    {
                        LocationId = (burialContext.Location.Max(x => x.LocationId) + 1),
                        BurialLocationNs = lc.BurialLocationNs,
                        BurialLocationEw = lc.BurialLocationEw,
                        LowValueNs = lc.LowValueNs,
                        LowValueEw = lc.LowValueEw,
                        HighValueNs = lc.HighValueNs,
                        HighValueEw = lc.HighValueEw
                    });
                    burialContext.SaveChanges();

                    //Grabs the id of the most recently added location
                    locid = burialContext.Location.Max(x => x.LocationId);
                }
                else
                {
                    locid = checkLoc.LocationId;
                }

                if (subplot == null && areanum == null && tombnum == null)
                {
                    ViewBag.SubLocationError = "You must enter a value in at least one of these fields";
                    return View("AddBurialLocation");
                }
                else
                {
                    var checkSubLoc = burialContext.SubLocation.Where(x =>
                        x.Subplot == subplot && x.AreaNumber == areanum && x.TombNumber == tombnum).FirstOrDefault();

                    if (checkSubLoc == null)
                    {
                        burialContext.SubLocation.Add(new SubLocation
                        {
                            AreaNumber = areanum,
                            Subplot = subplot,
                            TombNumber = tombnum
                        });
                        burialContext.SaveChanges();

                        sublocid = burialContext.SubLocation.Max(x => x.SublocationId);
                    }
                    else
                    {
                        sublocid = checkSubLoc.SublocationId;
                    }
                }

                //Check to see if this burial record already exists
                var burialexists = burialContext.Burial.Where(x => x.BurialId == burialnum && x.LocationId == locid && x.SublocationId == sublocid).FirstOrDefault();

                if (burialexists != null)
                {
                    ViewBag.BurialExists = "A burial record with this identification already exists";
                    return View("AddBurialLocation");
                }
                else
                {
                    ViewBag.Locid = locid;
                    ViewBag.Sublocid = sublocid;
                    ViewBag.Burialnum = burialnum;
                    return View("AddBurialEssential");
                }
            }

            return View("AddBurialLocation");
        }


        //Action for getting to form for burial essentials
        [HttpGet]
        public IActionResult AddBurialEssential()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
