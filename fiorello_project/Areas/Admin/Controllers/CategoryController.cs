using fiorello_project.Areas.Admin.ViewModels;
using fiorello_project.Areas.Admin.ViewModels.Category;
using fiorello_project.DAL;
using fiorello_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fiorello_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new CategoryIndexViewModel
            {
                Categories = await _appDbContext.Categories.ToListAsync()
            };
            return View(model);
        }
       

        #region Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)return View(model);

            bool isExist=await _appDbContext.Categories.AnyAsync(c=>c.Title.ToLower().Trim()==model.Title.ToLower().Trim());

            if (isExist)
            {
                ModelState.AddModelError("Title", "Bu adda Kategory movcuddur");
                return View(model);
            }

            var category = new Category
            {
                Id = model.Id,
                Title = model.Title
            };
            

            await _appDbContext.Categories.AddAsync(category);

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _appDbContext.Categories.FindAsync(id);
            if (category == null) return NotFound();

            _appDbContext.Categories.Remove(category);

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion


        #region Details

        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            var category=await _appDbContext.Categories.FindAsync(id);
            if(category == null) return NotFound();

            var model = new CategoryDetailsViewModel
            {
                Id = category.Id,
                Title = category.Title
            };

            return View(model);
        }

        #endregion

        #region Update

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _appDbContext.Categories.FindAsync(id);
            if (category == null) return NotFound();

            var model = new CategoryUpdateViewModel
            {
                Title = category.Title
            };

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id,CategoryUpdateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (id != model.Id) return BadRequest();
           
            var category= await _appDbContext.Categories.FindAsync(id);
            if (category == null) return NotFound();

            bool isExist = await _appDbContext.Categories
                .AnyAsync(c => c.Title.ToLower().Trim() == model.Title.ToLower().Trim() && c.Id != model.Id);

            if (isExist) 
            {
                ModelState.AddModelError("Title", "Bu adda kategory movcuddur");
                return View(model);
            }

            category.Title = model.Title;
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion


    }
}
