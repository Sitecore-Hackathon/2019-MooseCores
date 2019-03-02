using System.Web.Http;
using Sitecore.Pipelines;

namespace Sitecore.Feature.Gdpr.Pipelines.Initialize
{
    public class RegisterHttpRoutes
    {
        public void Process(PipelineArgs args)
        {
            GlobalConfiguration.Configuration.Routes.MapHttpRoute("Gdpr", "api/Gdpr/{id}", new
            {
                controller = "GdprApi",
                action = "GetContactData",
                id = RouteParameter.Optional
            });
        }
    }
}