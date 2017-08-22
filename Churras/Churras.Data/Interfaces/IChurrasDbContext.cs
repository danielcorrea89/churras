using Churras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churras.Data
{
    public interface IChurrasDbContext
    {
        IDbSet<Churrasco> Churrascos { get; set; }
        IDbSet<Participante> Participantes { get; set; }
    }
}
