﻿using MailKit.Net.Smtp;
using MimeKit;
using System;

namespace new_email_tool
{
    public class EmailService
    {
        private readonly string _smtpServer = "sandbox.smtp.mailtrap.io";
        private readonly int _port = 2525;
        private readonly string _userName = "a563851d548a8a";
        private readonly string _password = "9067d6d7b76a01";
        private readonly string _recipientName = "Matthew Tuazon"; 
        private readonly string _recipientEmail = "mtthwtzn@gmail.com"; 
        public void SendEmail(string subject, string htmlBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Obscura Car Management", "obscura@gmail.com"));
            message.To.Add(new MailboxAddress(_recipientName, _recipientEmail));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = htmlBody
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_smtpServer, _port, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate(_userName, _password);
                    client.Send(message);
                    Console.WriteLine("Email sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}