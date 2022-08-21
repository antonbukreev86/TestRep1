using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;

            List<Category> newBirthDates = new List<Category>();

            
            //foreach (item in objCategory)
            foreach (var item in objCategoryList)
            {
                int currentDay = DateTime.Now.Day;
                int currentMonth = DateTime.Now.Month;

                if (currentDay <= item.BirthDate.Day && currentDay + 2  > item.BirthDate.Day && currentMonth == item.BirthDate.Month)
                {
                    newBirthDates.Add(item);
                }
            }
            
            return View(newBirthDates);
        }

        public IActionResult AllList()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;


            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        /*
        public IActionResult Edit()
        {
            return View();
            /*
            if (id == null || id == null)
                return NotFound();

            var categoryFromDB = _db.Categories.Find(id);
            //var categoryFromDBFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);

            if (categoryFromDB==null)
                return NotFound();

            return View(categoryFromDB);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("AllList");
            }

            return View(obj);
        }
        */

        public IActionResult Edit(int? id)
        {
            if (id == null || id == null)
                return NotFound();

            var categoryFromDB = _db.Categories.Find(id);
            

            if (categoryFromDB == null)
                return NotFound();

            return View(categoryFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == null)
                return NotFound();

            var categoryFromDB = _db.Categories.Find(id);


            if (categoryFromDB == null)
                return NotFound();

            return View(categoryFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);

            if (obj == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
               
            }
            return RedirectToAction("AllList");

        }


    }
}
