using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Churras.Models
{
    public class ChurrascoDashboardItem
    {
        public int Key { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public int Participantes { get; set; }

        [DisplayName("Total Arrecadado")]
        public double TotalArrecadado { get; set; }
    }
}
