using Autofac;
using Autofac.Integration.Mvc;
using DijkstrasAlgorithm.Repositories;
using DijkstrasAlgorithm.Repositories.Interfaces;
using DijkstrasAlgorithm.Services;
using DijkstrasAlgorithm.Services.Interfaces;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DijkstrasAlgorithm
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterType<NodeRepository>().As<INodeRepository>();
            builder.RegisterType<CalculatorService>().As<ICalculatorService>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
