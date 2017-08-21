using Churras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churras.Services
{
    public interface IChurrascoService
    {
        ChurrascoDashboard GetChurrascoDashboard();
        ChurrascoDetalhes GetChurrascoDetails(int key);
        void SaveChurrasco(Churrasco churrasco);
        void SaveParticipante(Participante participante, int churrascoKey);
        IEnumerable<Participante> GetParticipanteList(int key);
        void DeleteParticipante(int key, int churrascoKey);
    }
}
