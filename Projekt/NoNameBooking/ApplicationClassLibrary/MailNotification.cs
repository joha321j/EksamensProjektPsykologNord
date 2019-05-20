using System;
using System.Collections.Generic;
using System.Text;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    class MailNotification
    {
        public void SendTestMail(User user)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Kaare Veggerby Sandbøl", "kaar1498@edu.eal.dk"));
            message.To.Add(new MailboxAddress(user.Name, user.Email));

            message.Subject = "Test-Email";

            message.Body = new TextPart("plain")
            {
                Text = @"This is a test email to" + user.Name + "." +
                "\n We hope you recieved this message in good health" +
                "\n Kinds regards" +
                "\n Semplito Booking"

            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.sendgrid.net", 587, false);

                client.Authenticate("apikey", "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");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
