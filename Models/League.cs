using System;
using System.ComponentModel.DataAnnotations;

namespace DSS_Assignment_Ebube.Models
{
    public class League
    {
        [Key]
        public int ID { get; set; }

        public string? Name { get; set; }
        public string? Cup { get; set; }


        // Connections
        public List<Player_League>? Players_Leagues { get; set; }
    }
}