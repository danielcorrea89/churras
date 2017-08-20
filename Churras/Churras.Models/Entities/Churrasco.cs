using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Churras.Models
{
    public class Churrasco
    {
        public Churrasco()
        {
            Participantes = new List<Participante>();
        }

        public int Key { get; set; }

        [DisplayName("Quando?")]
        public DateTime Quando { get; set; }

        [DisplayName("Por quê?")]
        public string Porque { get; set; }

        [DisplayName("Obs")]
        public string Obs { get; set; }

        [DisplayName("Com Bebida")]
        public double ValorSemBebida { get; set; }

        [DisplayName("Sem Bebida")]
        public double ValorComBebida { get; set; }

        public virtual ICollection<Participante> Participantes { get; set; }

        public int TotalParticipantes
        {
            get { return GetTotalParticipantes(); }
        }

        public double TotalArrecadado
        {
            get { return GetTotalArrecadado(); }
        }

        public double ValorPendente { get; set; }
        public double ValorPago { get; set; }
        public int TotalBebuns { get; set; }
        public int TotalSaudaveis { get; set; }

        #region Private Methods
        private double GetTotalArrecadado()
        {
            double total = 0;

            foreach (var p in Participantes)
            {
                total += p.ValorContribuicao;
            }

            return total;
        }

        private int GetTotalParticipantes()
        {
            return Participantes.Count;
        }
        #endregion
    }
}