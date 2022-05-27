using DSS_Assignment_Ebube.Models;
using DSS_Assignment_Ebube.Repository;
using DSS_Assignment_Ebube.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSS_Assignment_Ebube.Controllers
{
    public class Player_LeagueController : Controller
    {
        private DBContext db;
        private readonly IPlayer_League Map;
        private readonly ILeague League;
        private readonly IPlayer Player;

        public Player_LeagueController(DBContext _db, IPlayer_League _Map, ILeague _League, IPlayer _Player)
        {
            db = _db;
            Map = _Map;
            League = _League;
            Player = _Player;
        }

        public IActionResult Index()
        {
            return View(Map.GetPlayer_Leagues.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["PID"] = new SelectList(db.Players, "ID", "LastName");
            ViewData["ID"] = new SelectList(db.Leagues, "ID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player_League model)
        {
            if (ModelState.IsValid)
            {
                Map.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            Player_League model = Map.GetPlayer_League(ID);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
            Map.Remove(ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var model = Map.GetPlayer_League(ID);
            ViewData["PID"] = new SelectList(db.Players, "ID", "LastName");
            ViewData["ID"] = new SelectList(db.Leagues, "ID", "Name");
            ViewData["MID"] = new SelectList(db.Players_Leagues, "ID", "Player_LeagueName");
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Player_League model)
        {
            if (ModelState.IsValid)
            {
                db.Players_Leagues.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int ID)
        {
            return View(Map.GetPlayer_League(ID));
        }
    }
}
