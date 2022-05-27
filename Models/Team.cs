using System;
using System.ComponentModel.DataAnnotations;

namespace DSS_Assignment_Ebube.Models
{
    public class Team
    {
        [Key]
        public int ID { get; set; }

        public string? Name { get; set; }
        public DateTime YearCreated { get; set; }
        public string? Logo { get; set; }


        // Connections
        public List<Player>? Players { get; set; }
    }
}