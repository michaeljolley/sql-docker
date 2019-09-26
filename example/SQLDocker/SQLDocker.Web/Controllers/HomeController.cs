using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLDocker.Data;
using SQLDocker.Web.Models;

namespace SQLDocker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly OMGContext _omgContext;

        public HomeController(OMGContext omgContext)
        {
            _omgContext = omgContext;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _omgContext.Clients.AsNoTracking()
                                             .Include(i => i.Addresses)
                                             //.Include(i => i.Employees)
                                             .ToListAsync();

            return View(clients);
        }

        public IActionResult Privacy()
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
