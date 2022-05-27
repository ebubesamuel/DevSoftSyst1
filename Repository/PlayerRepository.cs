using DSS_Assignment_Ebube.Models;
using DSS_Assignment_Ebube.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_Assignment_Ebube.Repository
{
    public class PlayerRepository : IPlayer
    {
        private DBContext db;

        public PlayerRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Player> GetPlayers => db.Players.Include(x => x.Team);

        public void Add(Player _Player)
        {
            db.Players.Add(_Player);
            db.SaveChanges();
        }

        public Player GetPlayer(int ID)
        {
            Player pl = db.Players
                 .Include(x => x.Team)
                 .Include(s => s.Players_Leagues)
                 .ThenInclude(t => t.Leagues)
                 .SingleOrDefault(v => v.ID == ID);

            return pl;
        }

        public void Remove(int ID)
        {
            Player pl = db.Players.Find(ID);
            db.Players.Remove(pl);
            db.SaveChanges();
        }
    }
}
