using DSS_Assignment_Ebube.Models;
using DSS_Assignment_Ebube.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_Assignment_Ebube.Repository
{
    public class TeamRepository : ITeam
    {
        private DBContext db;

        public TeamRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Team> GetTeams => db.Teams;

        public void Add(Team _Team)
        {
            db.Teams.Add(_Team);
            db.SaveChanges();
        }

        public Team GetTeam(int ID)
        {
            Team tm = db.Teams.Include(c => c.Players).SingleOrDefault(t => t.ID == ID);
            return tm;
        }

        public void Remove(int ID)
        {
            Team tm = db.Teams.Find(ID);
            db.Teams.Remove(tm);
            db.SaveChanges();
        }
    }
}
