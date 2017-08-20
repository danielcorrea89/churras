using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churras.Models
{
    public class ChurrascoDashboard
    {
        public List<ChurrascoDashboardItem> Items { get; set; }

        public ChurrascoDashboard()
        {
            Items = new List<ChurrascoDashboardItem>();
        }
    }
}
