using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSS_Assignment_Ebube.Models
{
    public class Player_League
    {
        public int ID { get; set; }

        public int PlayerId { get; set; }
        public Player? Players { get; set; }


        public int LeagueId { get; set; }
        public League? Leagues { get; set; }
    }
}