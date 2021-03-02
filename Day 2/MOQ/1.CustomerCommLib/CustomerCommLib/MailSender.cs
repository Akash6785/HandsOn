using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace CustomerCommLib

{

    public class CustomerComm

    {

        IMailSender _mailSender;

        public CustomerComm(IMailSender mailSender)

        {

            _mailSender = mailSender;

        }

        public bool SendMailToCustomer()

        {

            //Actual logic goes here

            //define message and mail address

            _mailSender.SendMail("to","SomeMessage");

            return true;

        }

    }

}