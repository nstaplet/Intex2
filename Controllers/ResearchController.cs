using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Controllers
{

    [Authorize(Roles = "Researcher,Admin")]
    public class ResearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
