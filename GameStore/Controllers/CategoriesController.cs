using GameStore.Interfaces;
using GameStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class CategoriesController(ICategory _categories) : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_categories.GetAllCategories());
        }

        [HttpGet]
        public ActionResult UpdateRange()
        {
            return View(_categories.GetAllCategories().ToList());
        }

        [HttpPost]
        public async Task<ActionResult> UpdateRange(Category[] categories)
        {
            await _categories.UpdateRangeAsync(categories);
            return RedirectToAction("Index");
        }
    }
}
