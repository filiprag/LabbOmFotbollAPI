using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LabbOmFotbollAPI.Model
{
    public class Arena
    {
        public int Id { get; set; }
        public string arenaNamn { get; set; }
        public string Stad { get; set; }
        public string landsKod { get; set; }
        public int Kapacitet { get; set; }


    }
}
