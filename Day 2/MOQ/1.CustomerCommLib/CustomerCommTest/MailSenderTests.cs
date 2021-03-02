using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommTest
{
    [TestFixture]
    public class MailSenderTests
    {
        CustomerComm customer;
        Mock<IMailSender> mockMail;
        [OneTimeSetUp]
        public void init()
        {
            mockMail = new Mock<IMailSender>();
            mockMail.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            customer = new CustomerComm(mockMail.Object);
        }


        [TestCase("Mnachester", "City")]
        [TestCase("Manchester", "United")]
        [TestCase("Jinx", "jacks")]
        
        public void SendMailTest(string s1, string s2)
        {

            customer.SendMailToCustomer();
            mockMail.Verify(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()));
            bool result = mockMail.Object.SendMail(s1, s2);
            Assert.AreEqual(true, result);

        }
    }
}
