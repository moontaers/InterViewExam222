using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.DataAcessLayer
{
    public class MyDbContext:DbContext
    {
        public MyDbContext():base("Server=.;database=mydb;integrated security=true")
        {

        }
        public DbSet<User>Users { get; set; }
    }
}
