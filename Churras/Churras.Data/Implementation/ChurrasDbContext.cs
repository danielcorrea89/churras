using System.Data.Entity;
using Churras.Models;
using System;

namespace Churras.Data
{
    public class ChurrasDbContext : DbContext, IChurrasDbContext
    {
        /*
         * Line below defines the Database Connection. Use Local or Azure.
         */

        const string conn = "ChurrasDbLocal";
        //const string conn = "ChurrasDbAzure";

        public ChurrasDbContext() :
            base(conn)
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer(new ChurrasDbInitializer());
        }

        public IDbSet<Churrasco> Churrascos { get; set; }
        public IDbSet<Participante> Participantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties()
                        .Where(p => p.Name == "Key")
                        .Configure(p => p.IsKey());
        }
    }
}