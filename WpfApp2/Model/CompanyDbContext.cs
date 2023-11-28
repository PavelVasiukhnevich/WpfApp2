using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext():base("DBConnection")
        {  }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
