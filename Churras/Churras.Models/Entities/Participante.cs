using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Churras.Models
{
    public class Participante
    {
        public int Key { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Valor da Contribuição?")]
        public double ValorContribuicao { get; set; }

        [DisplayName("Pago?")]
        public bool Pago { get; set; }

        public bool Bebida { get; set; }

        public string Obs { get; set; }

        [Required]
        public Churrasco Churrasco { get; set; }
    }
}
