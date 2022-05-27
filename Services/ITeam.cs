using DSS_Assignment_Ebube.Models;

namespace DSS_Assignment_Ebube.Services
{
    public interface ITeam
    {
        IEnumerable<Team> GetTeams { get; }
        Team GetTeam(int ID);
        void Add(Team _Team);
        void Remove(int ID);
    }
}
