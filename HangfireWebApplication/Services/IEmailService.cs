using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.Demo.Services
{
    public interface IEmailService
    {
        void SendNewsletter();
        void SendSubscriptionEmail();
    }
}
