using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.Demo.Services
{
    public class EmailService : IEmailService
    {        
        public void SendNewsletter()
        {
            Console.WriteLine("Sending Newsletter");
        }
        public void SendSubscriptionEmail()
        {
            Console.WriteLine("Sending Subsciption Email");
        }
    }
}
