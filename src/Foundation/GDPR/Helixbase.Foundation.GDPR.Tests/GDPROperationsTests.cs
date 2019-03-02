using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitecore.Cintel.ContactService;
using Helixbase.Foundation.GDPR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Helixbase.Foundation.GDPR.Tests
{
    [TestClass()]
    public class GDPROperationsTests
    {
        [TestMethod()]
        public void AnonymizeTest()
        {
            Mock<IContactService> contactServiceMock = new Mock<IContactService>();
            contactServiceMock.Setup(m => m.Anonymize(Guid.Empty)).Returns(true);

            GDPROperations operations = new GDPROperations(contactServiceMock.Object);
            operations.Anonymize(Guid.Empty);
        }

        [TestMethod()]
        public void GetRightToBeForgottenRequestsTest()
        {
            Mock<IContactService> contactServiceMock = new Mock<IContactService>();
            contactServiceMock.Setup(m => m.Anonymize(Guid.Empty)).Returns(true);

            GDPROperations operations = new GDPROperations(contactServiceMock.Object);
            var requests = operations.GetRightToBeForgottenRequests();

            Assert.IsNotNull(requests);
        }
    }
}