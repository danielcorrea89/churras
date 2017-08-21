using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Churras.Models
{
    public class Participante
    {
        public int Key { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Valor da Contribuição")]
        public double ValorContribuicao { get; set; }

        [Required]
        [DisplayName("Pago?")]
        public bool Pago { get; set; }
        
        [Required]
        [DisplayName("Com Bebida?")]
        public bool Bebida { get; set; }

        public string Obs { get; set; }

        public virtual Churrasco Churrasco { get; set; }
    }
}
