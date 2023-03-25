using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MVProjectt.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCategoryList()
        {
            var categoryvalues = categoryManager.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category) 
        {
            //categoryManager.CategoryAddBL(category);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.CategoryAddBL(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {

                ModelState.Clear();
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
