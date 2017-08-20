using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Churras.Models
{
    public class ChurrasDbContext : DbContext
    {
        DbSet<Churras> Churras { get; set; }
    }
}