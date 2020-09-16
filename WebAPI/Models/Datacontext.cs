using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Datacontext:DbContext
    {
        public Datacontext() : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<WebAPI.Models.agreda> agredas { get; set; }
    }
}