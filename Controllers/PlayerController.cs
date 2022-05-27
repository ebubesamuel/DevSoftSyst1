using DSS_Assignment_Ebube.Repository;
using DSS_Assignment_Ebube.Models;
using DSS_Assignment_Ebube.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSS_Assignment_Ebube.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayer Player;
        private readonly ITeam Team;
        private DBContext db;

        public PlayerController(IPlayer _IPlayer, ITeam _ITeam, DBContext _db)
        {
            Player = _IPlayer;
            Team = _ITeam;
            db = _db;
        }

        public IActionResult Index()
        {
            var model = Player.GetPlayers;
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ID"] = new SelectList(db.Teams, "ID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player model)
        {
            if (ModelState.IsValid)
            {
                Player.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int ID)
        {
            Player model = Player.GetPlayer(ID);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
            Player.Remove(ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int ID)
        {
            return View(Player.GetPlayer(ID));
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            ViewData["ID"] = new SelectList(db.Teams, "ID", "Name");
            var model = Player.GetPlayer(ID);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Player model)
        {
            if (ModelState.IsValid)
            {
                db.Players.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
