using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PFE.Framework;
using PFE.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PFE.membership.Entities;
using Microsoft.AspNetCore.Identity;
using PFE.membership.Contexts;

namespace PFE.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = "SuperAdmin,Administrator")]
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ApplicationUser> _logger;
        private readonly ApplicationDbContext _db;

        public DashboardController(UserManager<ApplicationUser> userManager, ILogger<ApplicationUser> logger,
                                   ApplicationDbContext db)
        {
            _userManager = userManager;
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            
            var model = new DashBoardModel();
            var getTotalUser = _db.Users.Count();
            ViewBag.totalUser = getTotalUser-1;
            return View(model);

        } 
    }
}