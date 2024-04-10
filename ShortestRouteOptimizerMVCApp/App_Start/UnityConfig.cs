using ShortestPathCalculatorApplication;
using ShortestPathCalculatorApplication.IServices;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace ShortestRouteOptimizerMVCApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<INodeDataService, NodeDataService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IShortestPathCalculator, ShortestPathCalculator>(new ContainerControlledLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}