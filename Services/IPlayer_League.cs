using DSS_Assignment_Ebube.Models;

namespace DSS_Assignment_Ebube.Services
{
    public interface IPlayer_League
    {
        IEnumerable<Player_League> GetPlayer_Leagues { get; }
        Player_League GetPlayer_League(int ID);
        void Add(Player_League _Player_League);
        void Remove(int ID);
    }
}
