using Churras.Models;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace Churras.Data
{
    public static class UnityConfig
    {
        public static void RegisterComponents(UnityContainer container)
        {
            container.RegisterType<DbContext, ChurrasDbContext>();
            container.RegisterType<IRepository<Churrasco>, GenericRepository<Churrasco>>();
            container.RegisterType<IRepository<Participante>, GenericRepository<Participante>>();
        }
    }
}