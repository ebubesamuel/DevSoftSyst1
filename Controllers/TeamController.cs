using DSS_Assignment_Ebube.Repository;
using DSS_Assignment_Ebube.Models;
using DSS_Assignment_Ebube.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSS_Assignment_Ebube.Controllers
{
    public class TeamController : Controller
    {
        private DBContext db;
        private readonly ITeam Teams;
        public TeamController(DBContext _db, ITeam _Teams)
        {
            db = _db;
            Teams = _Teams;
        }

        public IActionResult Index()
        {
            var model = Teams.GetTeams;
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team model)
        {
            if (ModelState.IsValid)
            {
                Teams.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int ID)
        {
            return View(Teams.GetTeam(ID));
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var model = Teams.GetTeam(ID);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Team model)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            var model = Teams.GetTeam(ID);
            return View("Delete", model);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
            Teams.Remove(ID);
            return RedirectToAction("Index");
        }
    }
}
