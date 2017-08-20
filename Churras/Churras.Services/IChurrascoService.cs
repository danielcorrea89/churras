using Churras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churras.Services
{
    public interface IChurrascoService
    {
        ChurrascoDashboard GetChurrascoDashboard();
        ChurrascoDetalhes GetChurrascoDetails(int key);
    }
}
