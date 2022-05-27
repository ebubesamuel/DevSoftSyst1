using DSS_Assignment_Ebube.Models;

namespace DSS_Assignment_Ebube.Services
{
    public interface ILeague
    {
        IEnumerable<League> GetLeagues { get; }
        League GetLeague(int ID);
        void Add(League _League);
        void Remove(int ID);
    }
}
