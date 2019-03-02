namespace Sitecore.Feature.EPTab.Data
{
    using System;
    using Sitecore.Feature.EPTab.Model;
    using Sitecore.Feature.EPTab.Repositories;

    public class EpTabViewGdpr : EpExpressViewModel
    {
        public override string Heading => "Contact PII Data";
        public override string TabLabel => "GDPR";
        public override object GetModel(Guid contactId)
        {
            Sitecore.XConnect.Contact contact = EPRepository.GetContact(contactId, new string[] {});

            return new EpTabGdprModel
            {
                ContactId = contact.Id.ToString(),
                LastModified = contact.LastModified
            };
        }
        public override string GetFullViewPath(object model)
        {
            return "/views/EpTabGdpr.cshtml";
        }
    }
}