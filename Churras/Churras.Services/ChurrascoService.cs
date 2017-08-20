using System;
using Churras.Data;
using Churras.Models;

namespace Churras.Services
{
    internal class ChurrascoService : IChurrascoService
    {
        IRepository<Churrasco> ChurrascoRepository;

        public ChurrascoService(IRepository<Churrasco> churrascoRepository)
        {
            ChurrascoRepository = churrascoRepository;
        }

        public ChurrascoDashboard GetChurrascoDashboard()
        {
            var ret = new ChurrascoDashboard();

            var churrascos = ChurrascoRepository.GetAll();

            foreach(var c in churrascos)
            {
                ret.Items.Add(new ChurrascoDashboardItem()
                {
                    Key = c.Key,
                    Data = c.Quando,
                    Descricao = c.Porque,
                    Participantes = c.TotalParticipantes,
                    TotalArrecadado = c.TotalArrecadado
                });
            }

            return ret;
        }

        public ChurrascoDetalhes GetChurrascoDetails(int key)
        {
            var ret = new ChurrascoDetalhes();

            var churrasco = ChurrascoRepository.Get(key);

            ret.Data = churrasco.Quando;
            ret.Descricao = churrasco.Porque;
            ret.Obs = churrasco.Obs;

            ret.ValorComBebida = churrasco.ValorComBebida;
            ret.ValorSemBebida = churrasco.ValorSemBebida;

            ret.TotalParticipantes = churrasco.TotalParticipantes;

            ret.ValorPendente = churrasco.ValorPendente;
            ret.ValorPago = churrasco.ValorPago;

            ret.TotalBebuns = churrasco.TotalBebuns;
            ret.TotalSaudaveis = churrasco.TotalSaudaveis;

            return ret;                  
        }
    }
}