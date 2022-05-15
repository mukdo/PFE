using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using PFE.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PFE.Web.Areas.Admin.Models.Categories;
using PFE.Framework;

namespace PFE.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ItemCategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ItemCategoryModel> _logger;

        public ItemCategoryController( IConfiguration configuration , 
                                   ILogger<ItemCategoryModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<ItemCategoryModel>();
            return View(model);
        }

        public IActionResult CreateCategory()
        {
            var model = new ItemCreateCategoryModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory([Bind(nameof(ItemCreateCategoryModel.Name))]
        ItemCreateCategoryModel model )
            
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Category Create Successful", ResponseType.Success);
                   
                    //logger code
                    _logger.LogInformation("Category Create Sucessfully");

                    return RedirectToAction("Index");
                }

                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    _logger.LogError("Category Name already Exist");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Category creation failued.", ResponseType.Failure);
                    _logger.LogError($"Category Create 'Failed'. Excption is : {ex.Message}");
                }
            }

            return View(model);
        }

        public IActionResult EditCategory(int id)
        {
            var model = new ItemEditCategoryModel();
            model.Load(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory([Bind(nameof(ItemEditCategoryModel.Id),
                                                nameof(ItemEditCategoryModel.Name))]
                                            ItemEditCategoryModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Category editing successful.", ResponseType.Success);
                    
                    //logger code
                    _logger.LogInformation("Category Edit Successful");
                   
                    return RedirectToAction("Index");
                    
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);

                    // error logger code
                    _logger.LogError($"Category Name Already Exist so Edit 'Failed'. Excption is : {ex.Message}");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Category Edit Failued.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError( $"Category Edit 'Failed'. Excption is : {ex.Message}");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new ItemCategoryModel();
                try
                {
                    var provider = model.Delete(id);
                    model.Response = new ResponseModel($"Category {provider} successfully deleted.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Category Delete failed.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Category Delete 'Failed'. Excption is : {ex.Message}");
                }
            }
            return RedirectToAction("index");

        }

       
        public IActionResult GetCategory()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<ItemCategoryModel>();
            var data = model.GetCategory(tableModel);
            return Json(data);
        }
    }
}