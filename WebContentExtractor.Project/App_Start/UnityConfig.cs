using System.Web.Mvc;
using Microsoft.Owin;
using Unity;
using Unity.Mvc5;
using WebContentExtractor.Project.Mediator;

[assembly: OwinStartup(typeof(WebContentExtractor.Project.UnityConfig))]

namespace WebContentExtractor.Project
{
    public class UnityConfig
    {
        public static void ConfigureServices()
        {
            var container = new UnityContainer();
            container.RegisterType<IWebContentExtractorMediator, WebContentExtractorMediator>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
