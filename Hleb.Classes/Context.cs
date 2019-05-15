using Hleb.Classes.Model;
using Hleb.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Classes
{
    class Context: DbContext
    {
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<User> Users { get; set; }

        public Context(): base("Hleb")
        {

        }
    }
}
