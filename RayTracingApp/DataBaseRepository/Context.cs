using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseRepository
{
    public class Context : DbContext
    {
		public DbSet<Figure> Figures { get; set; }

		public Context() : base("RayTraicingAppDB") { }
    }
}
