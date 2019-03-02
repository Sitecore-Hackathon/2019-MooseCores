using Helixbase.Foundation.GDPR.DAL;
using Helixbase.Foundation.RightToBeForgotten.Model;
using Sitecore.Cintel.ContactService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Helixbase.Foundation.GDPR
{
    public class GDPROperations
    {
        IContactService _contactService;
        SitecoreGDPRDB _sitecoreGDPRCustomDBContext;

        public GDPROperations(IContactService contactService)
        {
            _contactService = contactService;
            _sitecoreGDPRCustomDBContext = new SitecoreGDPRDB();
        }

        public void Anonymize(Guid contactId)
        {
            var anonymizeRequest = new RightToBeForgottenRequest()
            {
                ContactID = contactId,
                RequestDate = DateTime.Now.ToUniversalTime()
            };

            _sitecoreGDPRCustomDBContext.RightToBeForgottenRequests.Add(anonymizeRequest);
            _sitecoreGDPRCustomDBContext.SaveChanges();

            _contactService.Anonymize(contactId);
        }

        public IEnumerable<ForgetRequest> GetRightToBeForgottenRequests()
        {
            IEnumerable<ForgetRequest> requests =
                _sitecoreGDPRCustomDBContext.RightToBeForgottenRequests
                    .Select(r => new ForgetRequest()
                    {
                        ContactID = r.ContactID,
                        RequestDate = r.RequestDate
                    }).ToList();
            return requests;
        }
    }
}
