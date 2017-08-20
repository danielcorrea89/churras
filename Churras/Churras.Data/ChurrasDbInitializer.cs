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
                    Obs = "Festejar final de ano",
                    ValorComBebida = 40.00,
                    ValorSemBebida = 25.00
                },
                new Churrasco()
                {
                    Quando = DateTime.Now,
                    Porque = "Sem Motivo",
                    Obs = "Sem motivo o churrasquinho.",
                    ValorComBebida = 30.00,
                    ValorSemBebida = 15.00
                }
            });

            context.Set<Participante>().AddRange(new List<Participante>()
            {
                new Participante()
                {
                    Nome = "Tania",
                    ValorContribuicao = 15.00,
                    Bebida = false,
                    Pago = true,
                    Obs = "",
                    Churrasco = context.Set<Churrasco>().Local.FirstOrDefault(c => c.Porque.Equals("Aniver do Gui"))
                },
                new Participante()
                {
                    Nome = "Kahuê",
                    ValorContribuicao = 15.00,
                    Bebida = false,
                    Pago = false,
                    Obs = "",
                    Churrasco = context.Set<Churrasco>().Local.FirstOrDefault(c => c.Porque.Equals("Aniver do Gui"))
                },
                new Participante()
                {
                    Nome = "Henery",
                    ValorContribuicao = 30.00,
                    Bebida = true,
                    Pago = false,
                    Obs = "",
                    Churrasco = context.Set<Churrasco>().Local.FirstOrDefault(c => c.Porque.Equals("Aniver do Gui"))
                },
                new Participante()
                {
                    Nome = "Paulo",
                    ValorContribuicao = 25.00,
                    Bebida = true,
                    Pago = true,
                    Obs = "Fico só até 21h",
                    Churrasco = context.Set<Churrasco>().Local.FirstOrDefault(c => c.Porque.Equals("Aniver do Gui"))
                }
            });


            base.Seed(context);
        }
    }
}
