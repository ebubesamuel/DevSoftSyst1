using DSS_Assignment_Ebube.Repository;
using DSS_Assignment_Ebube.Models;
using DSS_Assignment_Ebube.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSS_Assignment_Ebube.Controllers
{
    public class LeagueController : Controller
    {
        private DBContext db;
        private readonly ILeague League;
        public LeagueController(DBContext _db, ILeague _League)
        {
            db = _db;
            League = _League;
        }

        public IActionResult Index()
        {
            var model = League.GetLeagues;
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(League model)
        {
            if (ModelState.IsValid)
            {
                League.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int ID)
        {
            return View(League.GetLeague(ID));
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var model = League.GetLeague(ID);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(League model)
        {
            if (ModelState.IsValid)
            {
                db.Leagues.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            var model = League.GetLeague(ID);
            return View("Delete", model);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
            League.Remove(ID);
            return RedirectToAction("Index");
        }
    }
}
