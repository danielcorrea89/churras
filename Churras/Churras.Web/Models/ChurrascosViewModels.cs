using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Churras.Models;

namespace Churras.Web.Models.Churrascos
{
    public class IndexViewModel
    {
        public ChurrascoDashboard ChurrascoDashboard { get; set; }
    }

    public class DetalhesViewModel
    {
        public ChurrascoDetalhes ChurrascoDetalhes { get; set; }
    }
}