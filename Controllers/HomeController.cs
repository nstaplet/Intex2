﻿using Intex.Models;
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

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join("-", filter);

            return RedirectToAction("BurialSummaryList", new { ID = id });
        }


        public IActionResult BurialSummaryList(string id, int pageNum = 1)
        {
            //**********SETTING UP VIEWBAG TO HAVE FILTER FORM RETAIN PARAMETERS ************************
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.HairColor = burialContext.Burial.Select(b => b.HairColorCode).Where(b => b.Length > 0).Distinct();
            ViewBag.Direction = burialContext.Burial.Select(b => b.BurialDirection).Where(b => b.Length > 0).Distinct();
            ViewBag.Gender = burialContext.Burial.Select(b => b.GenderCode).Where(b => b.Length > 0).Distinct();
            ViewBag.Age = burialContext.Burial.Select(b => b.AgeCodeSingle).Where(b => b.Length > 0).Distinct();
            ViewBag.MinDepth = filters.DepthMin;
            ViewBag.MaxDepth = filters.DepthMax;
            //****************************************************************************************************8

            int pageSize = 5;
            var SelectedBurials = burialContext.Burial;
            IQueryable<Burial> query = SelectedBurials;
            //**********THIS IS THE IF STATEMENTS FOR THE FILTERING. ***************************************************8
            if (filters.HasHairColor)
            {
                query = query.Where(t => t.HairColorCode == filters.HairColor);
            }

            if (filters.HasBurialDirection)
            {
                query = query.Where(t => t.BurialDirection == filters.BurialDirection);
            }
            if (filters.HasGender)
            {
                query = query.Where(t => t.GenderCode == filters.Gender);
            }
            if (filters.HasAge)
            {
                query = query.Where(t => t.AgeCodeSingle == filters.Age);
            }
            if (filters.HasMinDepth)
            {
                query = query.Where(t => t.BurialDepthMeters >= filters.DepthMin);
            }
            if (filters.HasMaxDepth)
            {
                query = query.Where(t => t.BurialDepthMeters <= filters.DepthMax);
            }
            //**********END IF STATEMENTS *********************************************************************8

            var pageBurials = query.Skip((pageNum - 1) * pageSize).Take(pageSize);
            List<BasicBurial> PackageBurials = new List<BasicBurial>();



            foreach (var sb  in pageBurials)
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

                    TotalNumItems = query.Count()
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
                SingleSublocation = burialContext.SubLocation.Where(b => b.SublocationId == burial.SublocationId).FirstOrDefault(),
                SingleImage = burialContext.Image.Where(b => b.BurialId == burial.BurialId).FirstOrDefault()
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
                            SublocationId = (burialContext.SubLocation.Max(x => x.SublocationId) + 1),
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
                var burialexists = burialContext.Burial.Where(x => x.BurialNumber == burialnum && x.LocationId == locid && x.SublocationId == sublocid).FirstOrDefault();

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

        [HttpPost]
        public IActionResult AddBurialEssential(Burial br, int burialnum, int locid, int sublocid, string submitbtn)
        {
            ViewBag.Locid = locid;
            ViewBag.Sublocid = sublocid;
            ViewBag.Burialnum = burialnum;

            if (br.LengthOfRemains == null || br.BurialDepthMeters == null || br.SouthToHead == null || br.SouthToFeet == null ||
                br.WestToHead == null || br.WestToFeet == null || br.PhotoTaken == null || br.Goods == null)
            {
                ViewBag.NoNullFields = "All fields are required";
                return View("AddBurialEssential");
            }


            if (br.PhotoTaken != true)
            {
                ViewBag.NeedPhoto = "A photo should be taken before record is submitted";
                return View("AddBurialEssential");
            }

            if (ModelState.IsValid)
            {
                burialContext.Burial.Add(new Burial
                {
                    BurialId = (burialContext.Burial.Max(x => x.BurialId) + 1),
                    BurialNumber = ViewBag.Burialnum,
                    LocationId = ViewBag.Locid,
                    SublocationId = ViewBag.Sublocid,
                    LengthOfRemains = br.LengthOfRemains,
                    BurialDepthMeters = br.BurialDepthMeters,
                    SouthToHead = br.SouthToHead,
                    SouthToFeet = br.SouthToFeet,
                    WestToHead = br.WestToHead,
                    WestToFeet = br.WestToFeet,
                    PhotoTaken = br.PhotoTaken,
                    Goods = br.Goods
                });

                burialContext.SaveChanges();

                if (submitbtn == "finish")
                {
                    return View("BurialAddConfirmation");
                }
                else
                {
                    int currentburialid = burialContext.Burial.Max(x => x.BurialId);
                    var currentburial = burialContext.Burial.Where(x => x.BurialId == currentburialid).FirstOrDefault();

                    return View("BurialAdvancedForm", currentburial);
                }
            }
            else
            {
                return View("AddBurialEssential");
            }
        }

        public IActionResult BurialAdvancedForm(int burialid)
        {
            var currentburial = burialContext.Burial.Where(x => x.BurialId == burialid).FirstOrDefault();
            return View(currentburial);
        }

        [HttpPost]
        public IActionResult SubmitAdvancedForm(Burial br)
        {
            if (ModelState.IsValid)
            {
                burialContext.Update(br);
                burialContext.SaveChanges();

                Burial burial = burialContext.Burial.Where(b => b.BurialId == br.BurialId).FirstOrDefault();
                BasicBurial basicBurial = new BasicBurial
                {

                    SingleBurial = burial,
                    SingleLocation = burialContext.Location.Where(b => b.LocationId == burial.LocationId).FirstOrDefault(),
                    SingleSublocation = burialContext.SubLocation.Where(b => b.SublocationId == burial.SublocationId).FirstOrDefault(),
                    SingleImage = burialContext.Image.Where(b => b.BurialId == burial.BurialId).FirstOrDefault()
                };


                return View("BurialDetails", basicBurial);
            }

            return View("BurialAdvancedForm", br);
        }


        public IActionResult EditBurialLocation(int burialid)
        {
            Burial burial = burialContext.Burial.Where(b => b.BurialId == burialid).FirstOrDefault();
            BasicBurial basicBurial = new BasicBurial
            {

                SingleBurial = burial,
                SingleLocation = burialContext.Location.Where(b => b.LocationId == burial.LocationId).FirstOrDefault(),
                SingleSublocation = burialContext.SubLocation.Where(b => b.SublocationId == burial.SublocationId).FirstOrDefault(),
                SingleImage = burialContext.Image.Where(b => b.BurialId == burial.BurialId).FirstOrDefault()
            };

            ViewBag.BB = basicBurial;

            if (basicBurial.SingleSublocation.Subplot == null)
            {
                ViewBag.SubplotNull = "true";
            }
            else
            {
                ViewBag.SubplotNull = basicBurial.SingleSublocation.Subplot;
            }

            return View();
        }

        [HttpPost]
        public IActionResult SubmitBurialLocation(Location lc, int burialnum, string subplot, int? areanum, string? tombnum, int BBid)
        {
            Burial burial = burialContext.Burial.Where(b => b.BurialId == BBid).FirstOrDefault();
            BasicBurial basicBurial = new BasicBurial
            {
                SingleBurial = burial,
                SingleLocation = burialContext.Location.Where(b => b.LocationId == burial.LocationId).FirstOrDefault(),
                SingleSublocation = burialContext.SubLocation.Where(b => b.SublocationId == burial.SublocationId).FirstOrDefault(),
                SingleImage = burialContext.Image.Where(b => b.BurialId == burial.BurialId).FirstOrDefault()
            };

            ViewBag.BB = basicBurial;

            if (basicBurial.SingleSublocation.Subplot == null)
            {
                ViewBag.SubplotNull = "true";
            }
            else
            {
                ViewBag.SubplotNull = basicBurial.SingleSublocation.Subplot;
            }

            if (ModelState.IsValid)
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
                    return View("EditBurialLocation");
                }
                else
                {
                    var checkSubLoc = burialContext.SubLocation.Where(x =>
                        x.Subplot == subplot && x.AreaNumber == areanum && x.TombNumber == tombnum).FirstOrDefault();

                    if (checkSubLoc == null)
                    {
                        burialContext.SubLocation.Add(new SubLocation
                        {
                            SublocationId = (burialContext.SubLocation.Max(x => x.SublocationId) + 1),
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
                var burialexists = burialContext.Burial.Where(x => x.BurialNumber == burialnum && x.LocationId == locid && x.SublocationId == sublocid).FirstOrDefault();

                if (burialexists != null)
                {
                    ViewBag.BurialExists = "A burial record with this identification already exists";
                    return View("EditBurialLocation");
                }
                else
                {
                    Burial changeBur = burialContext.Burial.Where(x => x.BurialId == BBid).FirstOrDefault();
                    changeBur.LocationId = locid;
                    changeBur.SublocationId = sublocid;
                    changeBur.BurialNumber = burialnum;

                    burialContext.SaveChanges();

                    BasicBurial changedBurial = new BasicBurial
                    {

                        SingleBurial = changeBur,
                        SingleLocation = burialContext.Location.Where(b => b.LocationId == changeBur.LocationId).FirstOrDefault(),
                        SingleSublocation = burialContext.SubLocation.Where(b => b.SublocationId == changeBur.SublocationId).FirstOrDefault(),
                        SingleImage = burialContext.Image.Where(b => b.BurialId == changeBur.BurialId).FirstOrDefault()
                    };
                    return View("BurialDetails", changedBurial);
                }
            }
            return View("EditBurialLocation");
        }


        [HttpGet]
        public IActionResult BurialAddConfirmation()
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
