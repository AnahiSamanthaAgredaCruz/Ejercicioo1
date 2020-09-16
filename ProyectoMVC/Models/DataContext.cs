using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoMVC.Models
{
    public class Datacontext : DbContext
    {
        public Datacontext() : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<ProyectoMVC.Models.agredac> agredacs { get; set; }
    }

}