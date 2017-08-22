using Microsoft.Practices.Unity;

namespace Churras.Services
{
    public static class UnityConfig
    {
        public static void RegisterComponents(UnityContainer container)
        {
            // Resolve Churras.Data dependencies
            Churras.Data.UnityConfig.RegisterComponents(container);

            container.RegisterType<IChurrasAppService, ChurrasAppService>();
        }
    }
}