using fiorello_project.ViewModels.Expert;
using fiorello_project.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fiorello_project.ViewModels.Product;
using Newtonsoft.Json;

namespace fiorello_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexViewModel
            {
                Products = await _appDbContext.Products.OrderByDescending(p => p.Id).Take(8).ToListAsync(),
            };
            return View(model);
        }

    }
}
