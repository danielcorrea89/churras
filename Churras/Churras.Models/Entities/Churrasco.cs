using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Churras.Models
{
    public class Churrasco
    {
        public Churrasco()
        {
            if (Participantes == null) Participantes = new List<Participante>();
        }

        public int Key { get; set; }

        [Required]
        [DisplayName("Quando?")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Quando { get; set; }

        [Required]
        [DisplayName("Por quê?")]
        public string Porque { get; set; }

        [Required]
        [DisplayName("Obs")]
        public string Obs { get; set; }

        [Required]
        [DisplayName("Sem Bebida")]
        public double ValorSemBebida { get; set; }

        [Required]
        [DisplayName("Com Bebida")]
        public double ValorComBebida { get; set; }

        public virtual ICollection<Participante> Participantes { get; set; }

        public int GetTotalParticipantes()
        {
            return Participantes.Count;
        }

        public int GetTotalBebuns()
        {
            return GetTotalParticipantes() - GetTotalSaudaveis();
        }

        public int GetTotalSaudaveis()
        {
            int saudaveis = 0;

            foreach (var p in Participantes)
            {
                if (!p.Bebida)
                    saudaveis++;
            }

            return saudaveis;
        }

        public double GetValorPendente()
        {
            int bebuns = GetTotalBebuns();
            int saudaveis = GetTotalSaudaveis();

            double pendente = (bebuns * ValorComBebida + saudaveis * ValorSemBebida) - GetValorPago();

            if (pendente > 0)
                return pendente;
            else
                return 0;
        }

        public double GetValorPago()
        {
            double pago = 0;

            foreach (var p in Participantes)
            {
                if (p.Pago)
                    pago += p.ValorContribuicao;
            }

            return pago;
        }

        public void AddParticipante(Participante p)
        {
            Participantes.Add(p);
        }
    }
}