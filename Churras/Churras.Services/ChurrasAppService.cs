using System;
using System.Collections.Generic;
using Churras.Data;
using Churras.Models;

namespace Churras.Services
{
    public class ChurrasAppService : IChurrasAppService
    {
        IRepository<Churrasco> ChurrascoRepository;
        IRepository<Participante> ParticipanteRepository;

        public ChurrasAppService(IRepository<Churrasco> churrascoRepository, IRepository<Participante> participanteRepository)
        {
            ChurrascoRepository = churrascoRepository;
            ParticipanteRepository = participanteRepository;
        }

        public void DeleteParticipante(int key, int churrascoKey)
        {
            var participante = ParticipanteRepository.Get(key);

            if (participante != null)
            {
                //if (participante.Churrasco.Key == churrascoKey)
                    ParticipanteRepository.Delete(participante);
            }
        }

        public ChurrascoDashboard GetChurrascoDashboard()
        {
            var ret = new ChurrascoDashboard();

            var churrascos = ChurrascoRepository.GetAll();

            foreach (var c in churrascos)
            {
                ret.Items.Add(new ChurrascoDashboardItem()
                {
                    Key = c.Key,
                    Data = c.Quando,
                    Descricao = c.Porque,
                    Participantes = c.Participantes.Count,
                    TotalArrecadado = GetTotalArrecadado(c)
                });
            }

            return ret;
        }

        public ChurrascoDetalhes GetChurrascoDetails(int key)
        {
            var ret = new ChurrascoDetalhes();

            var churrasco = ChurrascoRepository.Get(key);

            LoadChurrascoDetails(churrasco, ref ret);

            return ret;
        }

        public IEnumerable<Participante> GetParticipanteList(int churrascoKey)
        {
            return ParticipanteRepository.FindAll(p => p.Churrasco.Key.Equals(churrascoKey));
        }

        public void SaveChurrasco(Churrasco churrasco)
        {
            if (IsValid(churrasco))
            {
                if (ChurrascoRepository.Get(churrasco.Key) == null)
                {
                    ChurrascoRepository.Add(churrasco);
                }
                else
                {
                    ChurrascoRepository.Update(churrasco, churrasco.Key);
                }
            }
        }

        public void SaveParticipante(Participante participante, int churrascoKey)
        {
            if (IsValid(participante))
            {
                var churrasco = ChurrascoRepository.Get(churrascoKey);

                if (churrasco != null)
                {
                    churrasco.Participantes.Add(participante);
                    ChurrascoRepository.Update(churrasco, churrascoKey);
                }
            }
        }

        public void UpdateParticipantePagamento(int key, int churrascoKey)
        {
            var participante = ParticipanteRepository.Get(key);

            if (participante != null)
            {
                participante.Pago = true;
                ParticipanteRepository.Update(participante, key);
            }
        }

        #region Private Methods

        private bool Exists(Churrasco churrasco)
        {
            if (ChurrascoRepository.Get(churrasco.Key) != null)
                return true;
            else
                return false;
        }

        private bool IsValid(Churrasco c)
        {
            // Check Required Fields

            if ((c != null)
                && (c.Quando != null)
                && (c.Porque != null)
                && (c.ValorComBebida > 0)
                && (c.ValorSemBebida > 0))
                return true;
            else
                return false;
        }

        private bool IsValid(Participante p)
        {
            // Check Required Fields

            if ((p != null)
                && (p.Nome != null)
                && (p.ValorContribuicao > 0))
                return true;
            else
                return false;
        }

        private ChurrascoDetalhes LoadChurrascoDetails(Churrasco c, ref ChurrascoDetalhes d)
        {
            // Bind general fields

            d.Key = c.Key;
            d.Data = c.Quando;
            d.Descricao = c.Porque;
            d.Obs = c.Obs;
            d.ValorComBebida = c.ValorComBebida;
            d.ValorSemBebida = c.ValorSemBebida;
            d.TotalParticipantes = c.Participantes.Count;

            // Calculate additional information

            double estimado = 0;

            foreach (var p in c.Participantes)
            {
                if (p.Bebida)
                {
                    d.TotalBebuns++;
                    estimado += c.ValorComBebida;
                }
                else
                {
                    d.TotalSaudaveis++;
                    estimado += c.ValorSemBebida;
                }

                if (p.Pago)
                    d.ValorPago += p.ValorContribuicao;
            }

            if (estimado - d.ValorPago > 0)
                d.ValorPendente = estimado - d.ValorPago;
            else
                d.ValorPendente = 0;

            return d;
        }

        private double GetTotalArrecadado(Churrasco c)
        {
            double valorPago = 0;

            foreach (var p in c.Participantes)
            {
                if (p.Pago)
                    valorPago += p.ValorContribuicao;
            }

            return valorPago;
        }

        private void AddParticipante(Churrasco c, Participante p)
        {
            c.Participantes.Add(p);
        }

        #endregion
    }
}