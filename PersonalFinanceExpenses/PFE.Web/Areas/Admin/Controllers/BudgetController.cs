using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PFE.Framework;
using PFE.Web.Areas.Admin.Models;
using PFE.Web.Areas.Admin.Models.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BudgetController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<BudgetModel> _logger;
        private readonly FrameworkContext _frameworkContext;

        public BudgetController(IConfiguration configuration,
                                   ILogger<BudgetModel> logger,
                                   FrameworkContext frameworkContext)
        {
            _configuration = configuration;
            _logger = logger;
            _frameworkContext = frameworkContext;
        }

        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<BudgetModel>();
            return View(model);
        }

        public IActionResult CreateBudget()
        {
            var model = new CreateBudgetModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBudget([Bind(nameof(CreateBudgetModel.Title),
                                                  nameof(CreateBudgetModel.Amount),
                                                  nameof(CreateBudgetModel.CategoryId),
                                                  //nameof(CreateBudgetModel.UserId),
                                                  nameof(CreateBudgetModel.ItemCategoryId))]
                                                    CreateBudgetModel model)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
                    model.UserId = currentUserId;
                    model.Create();
                    model.Response = new ResponseModel("Budget Create Successful", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Budget Create Sucessfully");

                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Budget creation failued.", ResponseType.Failure);
                    _logger.LogError($"Budget Create 'Failed'. Excption is : {ex.Message}");
                }
            }

            return View(model);
        }

        public IActionResult EditBudget(int id)
        {
            var model = new EditBudgetModel();
            model.Load(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBudget([Bind(nameof(EditBudgetModel.Id),
                                                  //nameof(EditBudgetModel.UserId),
                                                  nameof(EditBudgetModel.Title),
                                                  nameof(EditBudgetModel.Amount),
                                                  nameof(EditBudgetModel.CategoryId),
                                                  nameof(EditBudgetModel.ItemCategoryId))]
                                                    EditBudgetModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Budget editing successful.", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Budget Edit Successful");

                    return RedirectToAction("Index");

                }                
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Budget Edit Failued.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Budget Edit 'Failed'. Excption is : {ex.Message}");
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
                var model = new BudgetModel();
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
            var model = Startup.AutofacContainer.Resolve<BudgetModel>();
            var data = model.GetBlogCompose(tableModel);
            return Json(data);
        }
    }
}

