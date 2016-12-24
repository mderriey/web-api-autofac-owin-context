using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using System.Web.Http;

namespace WebApi.AutofacOwinContext
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(Startup).Assembly);
            var container = builder.Build();

            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }
    }
}