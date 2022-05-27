using DSS_Assignment_Ebube.Models;

namespace DSS_Assignment_Ebube.Services
{
    public interface IPlayer
    {
        IEnumerable<Player> GetPlayers { get; }
        Player GetPlayer(int ID);
        void Add(Player _Player);
        void Remove(int ID);
    }
}
