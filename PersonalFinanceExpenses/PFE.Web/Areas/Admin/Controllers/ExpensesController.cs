using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PFE.Web.Areas.Admin.Models;
using PFE.Web.Areas.Admin.Models.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ExpensesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ExpensesModel> _logger;
        public ExpensesController(IConfiguration configuration,
                                   ILogger<ExpensesModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<ExpensesModel>();
            return View(model);
        }

        public IActionResult CreateBudget()
        {
            var model = new CreateExpensesModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBudget([Bind(nameof(CreateExpensesModel.Amount),
                                                  nameof(CreateExpensesModel.DateTime),
                                                  nameof(CreateExpensesModel.BudgetId))]
                                                    CreateExpensesModel model)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
                    model.UserId = currentUserId;
                    model.Create();
                    model.Response = new ResponseModel("Expenses Create Successful", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Expenses Create Sucessfully");

                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Expenses creation failued.", ResponseType.Failure);
                    _logger.LogError($"Budget Create 'Failed'. Excption is : {ex.Message}");
                }
            }

            return View(model);
        }

        public IActionResult EditBudget(int id)
        {
            var model = new EditExpensesModel();
            model.Load(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBudget([Bind(nameof(EditExpensesModel.Id),
                                                  nameof(EditExpensesModel.Title),
                                                  nameof(EditExpensesModel.Amount),
                                                  nameof(EditExpensesModel.BudgetId),
                                                  nameof(EditExpensesModel.UserId))]
                                                    EditExpensesModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Expenses editing successful.", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Expenses Edit Successful");

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Expenses Edit Failued.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Expenses Edit 'Failed'. Excption is : {ex.Message}");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBudget(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new ExpensesModel();
                try
                {
                    var provider = model.Delete(id);
                    model.Response = new ResponseModel($"Budget {provider} successfully deleted.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Budget Delete failed.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Budget Delete 'Failed'. Excption is : {ex.Message}");
                }
            }
            return RedirectToAction("index");

        }


        public IActionResult GetCategory()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<ExpensesModel>();
            var data = model.GetBlogCompose(tableModel);
            return Json(data);
        }
    }
}

