using System;
using System.ComponentModel.DataAnnotations;

namespace DSS_Assignment_Ebube.Models
{
    public class Player
    {
        [Key]
        public int ID { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? JerseyNumber { get; set; }
        public string? Picture { get; set; }

        // Connections
        public int? TeamID { get; set; }
        public Team? Team { get; set; }

        public List<Player_League>? Players_Leagues { get; set; }
    }
}