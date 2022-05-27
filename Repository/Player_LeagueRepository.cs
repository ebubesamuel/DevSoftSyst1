using DSS_Assignment_Ebube.Models;
using DSS_Assignment_Ebube.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_Assignment_Ebube.Repository
{
    public class Player_LeagueRepository : IPlayer_League
    {
        private DBContext db;
        public Player_LeagueRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Player_League> GetPlayer_Leagues => db.Players_Leagues
            .Include(c => c.Players)
            .Include(d => d.Leagues);

        public void Add(Player_League _PL)
        {
            db.Players_Leagues.Add(_PL);
            db.SaveChanges();
        }

        public Player_League GetPlayer_League(int ID)
        {
            return db.Players_Leagues
                .Include(c => c.Players)
                .Include(d => d.Leagues)
                .SingleOrDefault(e => e.ID == ID);
        }

        public void Remove(int ID)
        {
            Player_League PL = db.Players_Leagues.Find(ID);
            db.Players_Leagues.Remove(PL);
            db.SaveChanges();

        }
    }
}
