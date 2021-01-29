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
using System.Security.Claims;

namespace PFE.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = "SuperAdmin,Administrator")]
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ApplicationUser> _logger;
        private readonly ApplicationDbContext _db;
        private readonly FrameworkContext _frameworkContext;

        public DashboardController(UserManager<ApplicationUser> userManager, ILogger<ApplicationUser> logger,
                                   ApplicationDbContext db, FrameworkContext frameworkContext)
        {
            _userManager = userManager;
            _logger = logger;
            _db = db;
            _frameworkContext = frameworkContext;
        }
        //public IActionResult Index()
        //{

        //    var model = new DashBoardModel();
        //    var getTotalUser = _db.Users.Count();
        //    ViewBag.totalUser = getTotalUser-1;
        //    return View(model);

        //} 

        public IActionResult Index()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var model = new DashBoardModel();
            var budget = _frameworkContext.Budgets.Where(b => b.UserId == currentUserId).Sum( s => s.Amount);
            var expenses = _frameworkContext.Expenses.Where(e => e.UserId == currentUserId && e.Date.Month == DateTime.Now.Month).Sum( s => s.Amount);
            int remainingAmount = budget - expenses;
            ViewBag.totalBudget = budget;
            ViewBag.totalExpenses = expenses;
            ViewBag.remain = remainingAmount;

            return View(model);

        }
    }
} 