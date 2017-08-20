using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Churras.Services;

namespace Churras.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // Resolve Churras.Services dependencies
            Churras.Services.UnityConfig.RegisterComponents(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}