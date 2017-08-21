using System;
using System.Collections.Generic;
using Churras.Data;
using Churras.Models;

namespace Churras.Services
{
    internal class ChurrascoService : IChurrascoService
    {
        IRepository<Churrasco> ChurrascoRepository;
        IRepository<Participante> ParticipanteRepository;

        public ChurrascoService(IRepository<Churrasco> churrascoRepository, IRepository<Participante> participanteRepository)
        {
            ChurrascoRepository = churrascoRepository;
            ParticipanteRepository = participanteRepository;
        }

        public void DeleteParticipante(int key, int churrascoKey)
        {
            var participante = ParticipanteRepository.Get(key);

            if (participante.Churrasco.Key == churrascoKey)
                ParticipanteRepository.Delete(participante);
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
                    Participantes = c.GetTotalParticipantes(),
                    TotalArrecadado = c.GetValorPago()
                });
            }

            return ret;
        }

        public ChurrascoDetalhes GetChurrascoDetails(int key)
        {
            var ret = new ChurrascoDetalhes();

            var churrasco = ChurrascoRepository.Get(key);

            ret.Key = churrasco.Key;
            ret.Data = churrasco.Quando;
            ret.Descricao = churrasco.Porque;
            ret.Obs = churrasco.Obs;

            ret.ValorComBebida = churrasco.ValorComBebida;
            ret.ValorSemBebida = churrasco.ValorSemBebida;

            ret.TotalParticipantes = churrasco.GetTotalParticipantes();

            ret.ValorPendente = churrasco.GetValorPendente();
            ret.ValorPago = churrasco.GetValorPago();

            ret.TotalBebuns = churrasco.GetTotalBebuns();
            ret.TotalSaudaveis = churrasco.GetTotalSaudaveis();

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
                if (!Exists(churrasco))
                    ChurrascoRepository.Add(churrasco);
                else
                    ChurrascoRepository.Update(churrasco, churrasco.Key);
            }
        }

        public void SaveParticipante(Participante participante, int churrascoKey)
        {
            var churrasco = ChurrascoRepository.Get(churrascoKey);
            churrasco.Participantes.Add(participante);
            ChurrascoRepository.Update(churrasco, churrascoKey);
        }

        #region Private Methods

        private bool Exists(Churrasco churrasco)
        {
            if (ChurrascoRepository.Get(churrasco.Key) != null)
                return true;
            else
                return false;
        }

        private bool IsValid(Churrasco churrasco)
        {
            if ((churrasco != null)
                && (churrasco.Quando != null)
                && (churrasco.Porque != null)
                && (churrasco.Obs != null)
                && (churrasco.ValorComBebida > 0)
                && (churrasco.ValorSemBebida > 0))
                return true;
            else
                return false;
        }

        #endregion
    }
}