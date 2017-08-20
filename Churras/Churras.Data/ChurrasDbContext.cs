using System.Data.Entity;
using Churras.Models;
using System;

namespace Churras.Data
{
    public class ChurrasDbContext : DbContext
    {
        //const string conn = "ChurrasDbLocal";
        const string conn = "ChurrasDbAzure";

        public ChurrasDbContext() :
            base(conn)
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer(new ChurrasDbInitializer());
        }

        DbSet<Churrasco> Churrascos { get; set; }
        DbSet<Participante> Participantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties()
                        .Where(p => p.Name == "Key")
                        .Configure(p => p.IsKey());

            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));
        }
    }
}