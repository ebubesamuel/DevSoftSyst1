using DSS_Assignment_Ebube.Models;
using DSS_Assignment_Ebube.Services;
using Microsoft.EntityFrameworkCore;


namespace DSS_Assignment_Ebube.Repository
{
    public class LeagueRepository :ILeague
    {
        private DBContext db;
        public LeagueRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<League> GetLeagues => db.Leagues;

        public void Add(League _League)
        {
            db.Leagues.Add(_League);
            db.SaveChanges();
        }

        public League GetLeague(int ID)
        {
           League le = db.Leagues.Include(t => t.Players_Leagues)
          .ThenInclude(g => g.Players)
          .SingleOrDefault(s => s.ID == ID);

            return le ;
        }

        public void Remove(int ID)
        {
            League le = db.Leagues.Find(ID);
            db.Leagues.Remove(le);
            db.SaveChanges();
        }
    }
}
