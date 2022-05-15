using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PFE.Framework;
using PFE.membership.Contexts;
using PFE.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PFE.Web.Controllers
{
    [Authorize]
    public class GenarateRepotController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly FrameworkContext _frameworkContext;
        private readonly AppDbConText _appContext;
        public GenarateRepotController(IConfiguration configuration,
                                   ApplicationDbContext db, FrameworkContext frameworkContext, AppDbConText appDbConText)
        {
            _configuration= configuration;
            _db = db;
            _frameworkContext = frameworkContext;
            _appContext = appDbConText;
        }

        public IActionResult Index()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId 
            var userName = User.FindFirstValue(ClaimTypes.Name);
           
            var budgetsum = _frameworkContext.Budgets.Where(b => b.UserId == currentUserId).Sum(s => s.Amount);
            var expensessum = _frameworkContext.Expenses.Where(e => e.UserId == currentUserId && e.Date.Month == DateTime.Now.Month).Sum(s => s.Amount);
            var emargenytask = _appContext.Tasks.Count(x => x.Time.Day < 7 && x.UserId == currentUserId);

            var budget = _frameworkContext.Budgets.Where(b => b.UserId == currentUserId).ToList();
            var expenses = _frameworkContext.Expenses.Where(e => e.UserId == currentUserId && e.Date.Month == DateTime.Now.Month).ToList();


            int remainingAmount = budgetsum - expensessum;
            ViewBag.name = userName;
            ViewBag.totalBudget = budgetsum;
            ViewBag.totalExpenses = expensessum;
            ViewBag.emargency = emargenytask;
            ViewBag.remain = remainingAmount;

            ViewBag.budget = budget;
            ViewBag.expenses = expenses;

            return View();

        }
    }
}
