using System;
using DSS_Assignment_Ebube.Models;
using Microsoft.EntityFrameworkCore;

namespace DSS_Assignment_Ebube.Repository
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Player_League> Players_Leagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}