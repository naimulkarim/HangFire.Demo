using Hangfire.Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly IEmailService emailService;
        private readonly IBackgroundJobClient backgroundJobClient;
        private readonly IRecurringJobManager recurringJobManager;

        public NewsletterController(IEmailService emailService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            this.emailService = emailService;
            this.backgroundJobClient = backgroundJobClient;
            this.recurringJobManager = recurringJobManager;
        }


        [HttpGet("/SubscriptionConfirmation")]
        public ActionResult CreateDelayedJob()
        {
            backgroundJobClient.Schedule(() => emailService.SendSubscriptionEmail(), TimeSpan.FromSeconds(60));
            return Ok();
        }

        [HttpGet("/SendNesletter")]
        public ActionResult CreateReccuringJob()
        {
            recurringJobManager.AddOrUpdate("jobId", () => emailService.SendNewsletter(), Cron.Minutely);
            return Ok();
        }

    }
}
