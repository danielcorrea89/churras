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

    public class CriarViewModel
    {
        public Churrasco Churrasco { get; set; }
    }

    public class CriarParticipanteViewModel
    {
        public Participante Participante { get; set; }
        public int ChurrascoKey { get; set; }
        public double ValorSemBebida { get; set; }
        public double ValorComBebida { get; set; }
    }

    public class ListaParticipantesViewModel
    {
        public IEnumerable<Participante> Participantes { get; set; }

        public int ChurrascoKey { get; set; }
        public string ChurrascoNome { get; internal set; }      
    }
}