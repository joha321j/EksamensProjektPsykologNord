using System;
using System.Collections.Generic;
using System.Text;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;
using ModelClassLibrary;
using PersistencyClassLibrary;

namespace ApplicationClassLibrary
{
    class MailNotification
    {
        private readonly ClientRepo _clientRepo;

        public MailNotification(IPersistable persistable)
        {
            _clientRepo = ClientRepo.GetInstance(persistable);
        }
        public void SendReminderMail(User user)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Kaare Veggerby Sandbøl", "kaar1498@edu.eal.dk"));
            message.To.Add(new MailboxAddress(user.Name, user.Email));

            message.Subject = "Test-Email to "+ user.Name;

            message.Body = new TextPart("plain")
            {
                Text = @"Hej " + user.Name + "." +
                "\n Dette er en påmindelse om din tid." +
                "\n Venlig Hilsen" +
                "\n Semplito Booking"

            };

            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.sendgrid.net", 587, false);

                client.Authenticate("apikey", "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");

                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void AppointmentCreatedEmail(Appointment appointment)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Kaare Veggerby Sandbøl", "kaar1498@edu.eal.dk"));
            User user = new User();
            foreach (User tempUser in appointment.Participants)
            {
                if (_clientRepo.IsClient(tempUser))
                {
                    user = tempUser;
                    message.To.Add(new MailboxAddress(user.Name, user.Email));
                }
                
            }
            

            message.Subject = "Bekræftelses Email til " + user.Name;

            message.Body = new TextPart("plain")
            {
                Text = @"Dette er en bekræftigelse på at " + user.Name + "'s aftale d. "+ appointment.DateAndTime.ToString("dd/MM/yyyy HH:mm")+"." +
                "\n Vi glæder os til at se dig" +
                "\n Venlig hilsen" +
                "\n Semplito"

            };

            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.sendgrid.net", 587, false);

                client.Authenticate("apikey", "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");

                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void AppointmentUpdatedEmail(Appointment appointment)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Kaare Veggerby Sandbøl", "kaar1498@edu.eal.dk"));
            User user = new User();
            User prac = new User();
            foreach (User tempUser in appointment.Participants)
            {
                if (_clientRepo.IsClient(tempUser))
                {
                    user = tempUser;
                }
                else
                {
                    prac = tempUser;
                }

            }
            message.To.Add(new MailboxAddress(user.Name, user.Email));

            message.Subject = "Bekræftelses Email til " + user.Name;

            message.Body = new TextPart("plain")
            {
                Text = @"Dette er en meddelelse om at " + user.Name + "'s aftale med "+ prac.Name +" er blevet rygget." +
                "\n Din tid er nu d. "+ appointment.DateAndTime.ToString("dd/MM/yyyy HH:mm")+"."+
                "\n Vi glæder os til at se dig" +
                "\n Hvis der er nogle problemer eller spørgsmål til din tid er du som altid velkommen til at kontakte os på mobil eller mail"+
                "\n Venlig hilsen" +
                "\n Semplito"

            };

            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.sendgrid.net", 587, false);

                client.Authenticate("apikey", "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");

                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void AppointmentDeletedEmail(Appointment appointment)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Kaare Veggerby Sandbøl", "kaar1498@edu.eal.dk"));
            User user = new User();
            User prac = new User();
            foreach (User tempUser in appointment.Participants)
            {
                if (_clientRepo.IsClient(tempUser))
                {
                    user = tempUser;
                }
                else
                {
                    prac = tempUser;
                }

            }
            message.To.Add(new MailboxAddress(user.Name, user.Email));

            message.Subject = "Bekræftelses Email til " + user.Name;

            message.Body = new TextPart("plain")
            {
                Text = @"Dette er en meddelelse om at " + user.Name + "'s aftale d. " + appointment.DateAndTime.ToString("dd/MM/yyyy HH:mm") + " med " + prac.Name + " er blevet aflyst." +                
                "\n Vi beklager ulejligheden og håber at du vil komme til os igen på at andet tidspunkt" +
                "\n Hvis der er nogle problemer eller spørgsmål til din tid er du som altid velkommen til at kontakte os på mobil eller mail" +
                "\n Venlig hilsen" +
                "\n Semplito"

            };

            using (SmtpClient client = new SmtpClient())
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
