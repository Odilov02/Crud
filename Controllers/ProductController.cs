using Crud2.Data;
using Crud2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Crud2.Controllers
{
	public class ProductController : Controller
	{
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbcontext) 
		{
			_appDbContext = appDbcontext;
		}
		public IActionResult Index()
		{
			var products = _appDbContext.products.ToList();
			return View(products);
		}

		public IActionResult Create() 
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product product) 
		{
			_appDbContext.products.Add(product);
			_appDbContext.SaveChanges();
			return RedirectToAction("Index"); 
		}

		public IActionResult Update(int id)
		{
			var product = _appDbContext.products.Find(id);

			return View(product);
		}

		[HttpPost]
		public IActionResult Update(Product product)
		{
			_appDbContext.Update(product);
			_appDbContext.SaveChanges();

			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
		    var product = _appDbContext.products.Find(id);
			_appDbContext.products.Remove(product);
			_appDbContext.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
