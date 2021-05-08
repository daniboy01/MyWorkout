﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MyWorkout.Bll.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkout.Bll.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly MailSettings mailSettings;

        public EmailSender( IOptions<MailSettings> mailSettings )
        {
            this.mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailMessage = new MimeMessage
            {
                Sender = MailboxAddress.Parse(mailSettings.Mail),
                Subject = subject
            };

            emailMessage.To.Add(MailboxAddress.Parse(email));

            var builder = new BodyBuilder
            {
                HtmlBody = htmlMessage
            };

            emailMessage.Body = builder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect( mailSettings.Host, mailSettings.Port, false );
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);

                await smtp.SendAsync(emailMessage);

                smtp.Disconnect(true);
            }
        }
    }
}
