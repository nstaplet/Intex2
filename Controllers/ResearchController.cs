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
        public string viewReturn { get; private set; }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin") == true)
            {
                viewReturn = "DeletableIndex";
            }
            else
            {
                viewReturn = "Index";
            }

            return View(viewReturn);
        }
    }
}
