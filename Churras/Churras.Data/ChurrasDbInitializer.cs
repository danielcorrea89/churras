using Churras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churras.Data
{
    public class ChurrasDbInitializer : DropCreateDatabaseIfModelChanges<ChurrasDbContext>
    {
        protected override void Seed(ChurrasDbContext context)
        {
            context.Set<Churrasco>().AddRange(new List<Churrasco>()
            {
                new Churrasco()
                {
                    Quando = DateTime.Now,
                    Porque = "Aniver do Gui",
                    Obs = "Teremos ceva (vamos no Zaffari comprar os paranauês antes das 18 hrs então levem o dinheiro ao Guilherme até esse horário)",
                    ValorComBebida = 30.00,
                    ValorSemBebida = 15.00

                },
                new Churrasco()
                {
                    Quando = DateTime.Now,
                    Porque = "Final de Ano",
                    Obs = "Festejar final de ano. Teremos som ao vivo e muita cachaça. Roda de samba até altas horas.",
                    ValorComBebida = 40.00,
                    ValorSemBebida = 25.00
                },
                new Churrasco()
                {
                    Quando = DateTime.Now,
                    Porque = "Sem Motivo",
                    Obs = "Sem motivo o churrasquinho. Afinal, para que precisamos de motivo para comer um bom assado?",
                    ValorComBebida = 30.00,
                    ValorSemBebida = 15.00
                }
            });

            var c = context.Set<Churrasco>().Local.FirstOrDefault(ch => ch.Porque.Equals("Aniver do Gui"));

            context.Set<Participante>().AddRange(new List<Participante>()
            {
                new Participante()
                {
                    Nome = "Tania",
                    ValorContribuicao = 15.00,
                    Bebida = false,
                    Pago = true,
                    Obs = "",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Kahuê",
                    ValorContribuicao = 15.00,
                    Bebida = false,
                    Pago = false,
                    Obs = "",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Henery",
                    ValorContribuicao = 30.00,
                    Bebida = true,
                    Pago = false,
                    Obs = "",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Paulo",
                    ValorContribuicao = 30.00,
                    Bebida = true,
                    Pago = true,
                    Obs = "Fico só até 21h",
                    Churrasco = c
                }
            });

            c = context.Set<Churrasco>().Local.FirstOrDefault(ch => ch.Porque.Equals("Final de Ano"));

            context.Set<Participante>().AddRange(new List<Participante>()
            {
                new Participante()
                {
                    Nome = "Marcos",
                    ValorContribuicao = 25.00,
                    Bebida = false,
                    Pago = true,
                    Obs = "Levo a viola.",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Daniela",
                    ValorContribuicao = 25.00,
                    Bebida = false,
                    Pago = false,
                    Obs = "",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Douglas",
                    ValorContribuicao = 40.00,
                    Bebida = true,
                    Pago = false,
                    Obs = "Galera, vão de Uber",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Marcela",
                    ValorContribuicao = 40.00,
                    Bebida = true,
                    Pago = true,
                    Obs = "To fora da cachaça",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Karine",
                    ValorContribuicao = 25.00,
                    Bebida = false,
                    Pago = false,
                    Obs = "",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Josiel",
                    ValorContribuicao = 40.00,
                    Bebida = true,
                    Pago = false,
                    Obs = "",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Grazi",
                    ValorContribuicao = 40.00,
                    Bebida = true,
                    Pago = true,
                    Obs = "Vou pra balada depois",
                    Churrasco = c
                }
            });

            c = context.Set<Churrasco>().Local.FirstOrDefault(ch => ch.Porque.Equals("Sem Motivo"));

            context.Set<Participante>().AddRange(new List<Participante>()
            {
                new Participante()
                {
                    Nome = "Marcos",
                    ValorContribuicao = 25.00,
                    Bebida = false,
                    Pago = true,
                    Obs = "Levo a viola.",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Daniela",
                    ValorContribuicao = 25.00,
                    Bebida = false,
                    Pago = false,
                    Obs = "",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Douglas",
                    ValorContribuicao = 40.00,
                    Bebida = true,
                    Pago = false,
                    Obs = "Galera, vão de Uber",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Marcela",
                    ValorContribuicao = 40.00,
                    Bebida = true,
                    Pago = true,
                    Obs = "To fora da cachaça",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Karine",
                    ValorContribuicao = 25.00,
                    Bebida = false,
                    Pago = false,
                    Obs = "",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Josiel",
                    ValorContribuicao = 40.00,
                    Bebida = true,
                    Pago = false,
                    Obs = "",
                    Churrasco = c
                },
                new Participante()
                {
                    Nome = "Grazi",
                    ValorContribuicao = 40.00,
                    Bebida = true,
                    Pago = true,
                    Obs = "Vou pra balada depois",
                    Churrasco = c
                }
            });

            base.Seed(context);
        }
    }
}
