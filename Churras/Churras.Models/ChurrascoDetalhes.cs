using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churras.Models
{
    public class ChurrascoDetalhes
    {
        public int Key { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [DisplayName("Obs")]
        public string Obs { get; set; }

        [DisplayName("Com bebida")]
        public double ValorComBebida { get; set; }

        [DisplayName("Sem bebida")]
        public double ValorSemBebida { get; set; }

        [DisplayName("Número de Participantes")]
        public int TotalParticipantes { get; set; }

        [DisplayName("Valor a ser arrecadado")]
        public double ValorPendente { get; set; }

        [DisplayName("Valor já pago")]
        public double ValorPago { get; set; }

        [DisplayName("Total de Bebuns")]
        public int TotalBebuns { get; set; }

        [DisplayName("Total de Saudáveis")]
        public int TotalSaudaveis { get; set; }
    }
}
