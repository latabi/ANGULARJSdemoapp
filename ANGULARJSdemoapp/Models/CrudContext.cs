using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ANGULARJSdemoapp.Models
{
    public class CrudContext:DbContext
    {
        public DbSet<ANGULARJSdemoapp.Models.Player> Players { get; set; }
    }
}