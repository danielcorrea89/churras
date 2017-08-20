using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Churras.Models
{
    public class Churras
    {
        public int Id { get; set; }
        public DateTime Quando { get; set; }
        public string Obs { get; set; }

        public decimal ValorSemBebida { get; set; }
        public decimal ValorComBebida { get; set; }
    }
}