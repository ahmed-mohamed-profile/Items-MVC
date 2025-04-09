using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCoreApp.Data;
using TestCoreApp.Models;

namespace TestCoreApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _db;

        public ItemsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> itemList = _db.Items.ToList();
            return View(itemList);
        }

        // GET
        public IActionResult New()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if (item.Name == item.Price.ToString())
            {
                ModelState.AddModelError("CustomError", "Name can't equal to Price");
            }

            if (ModelState.IsValid)
            {
                _db.Items.Add(item);
                _db.SaveChanges();
                TempData["successData"] = "Item has been added successfully";
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (item.Name == item.Price.ToString())
            {
                ModelState.AddModelError("CustomError", "Name can't equal to Price");
            }

            if (ModelState.IsValid)
            {
                _db.Items.Update(item);
                _db.SaveChanges();
                TempData["successData"] = "Item has been edited successfully";
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Item item)
        {


            _db.Items.Remove(item);
            _db.SaveChanges();
            TempData["successData"] = "Item has been Deleted successfully";

            return RedirectToAction("Index");


        }
    }
}