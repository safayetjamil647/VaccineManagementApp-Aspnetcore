using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicaTeams.Controllers
{
    public class DashboardController:Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
