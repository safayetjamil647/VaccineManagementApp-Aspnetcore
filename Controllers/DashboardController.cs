using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MedicaTeams.Controllers
{
    [Authorize(Roles = "Administrator,Volunteer")]
    public class DashboardController:Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
