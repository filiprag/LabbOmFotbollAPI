using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace LabbOmFotbollAPI.Model
{
    public class ArenaDbModel : DbContext
    {
        public DbSet<Arena> Arenas { get; set; }

        //public ArenaDbModel()
        //{
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source = Arena.db");
        }

        

    }
}










