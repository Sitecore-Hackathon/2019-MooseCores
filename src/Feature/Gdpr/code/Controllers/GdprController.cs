namespace Sitecore.Feature.News.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;  
    using Sitecore.Mvc.Presentation;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using Newtonsoft.Json;
    using Sitecore.XConnect;
    using Sitecore.XConnect.Client;
    using Sitecore.XConnect.Client.Serialization;
    using Sitecore.Web.Http.Filters;

    public class GdprApiController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetContactData(string id)
        {
           
            if (string.IsNullOrEmpty(id))
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            try
            {
                Guid contactId = new Guid(id);
                using (XConnectClient client = XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
                {
                    try
                    {
                        var contactReference = new ContactReference(contactId);

                        // Get all available contact facets in current model
                        var contactFacets = client.Model.Facets.Where(c => c.Target == EntityType.Contact).Select(x => x.Name);

                        // Get all available interaction facets in current model
                        var interactionFacets = client.Model.Facets.Where(c => c.Target == EntityType.Interaction).Select(x => x.Name);

                        var contact =  client.Get<Contact>(contactReference, new ContactExpandOptions(contactFacets.ToArray())
                        {
                            Interactions = new RelatedInteractionsExpandOptions(interactionFacets.ToArray())
                            {
                                // Get all interactions
                                EndDateTime = DateTime.MaxValue,
                                StartDateTime = DateTime.MinValue
                            }
                        });


                        // Serialize response
                        // Note special XdbJsonContractResolver - mandatory for serializing xConnect entities
                        var serializerSettings = new JsonSerializerSettings
                        {
                            ContractResolver = new XdbJsonContractResolver(client.Model,
                                serializeFacets: true,
                                serializeContactInteractions: true),
                            Formatting = Formatting.Indented,
                            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                            DefaultValueHandling = DefaultValueHandling.Ignore
                        };

                        string allData = JsonConvert.SerializeObject(contact, serializerSettings);
                        var fileBytes = Encoding.Default.GetBytes(allData);
                        var response = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new ByteArrayContent(fileBytes)
                        };

                        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = "ContactData.json",
                        };

                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        return response;

                    }
                    catch (XdbExecutionException)
                    {
                        return new HttpResponseMessage(HttpStatusCode.NotFound);
                    }
                }

            }
            catch (XdbExecutionException)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        //[HttpGet]
        //[ValidateHttpAntiForgeryToken]
        //public HttpResponseMessage Anonymize(string contactId)
        //{
        //    if (string.IsNullOrEmpty(contactId))
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.NotFound);
        //    }


        //}
    }
}