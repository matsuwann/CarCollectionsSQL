using MailKit.Net.Smtp;
using MimeKit;

namespace new_email_tool
{
    internal class Add
    {
        static void Main(string[] args)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Obscura Car Management", "obscura@gmail.com.com"));
            message.To.Add(new MailboxAddress("Matthew Tuazon", "mtthwtzn@gmail.com"));
            message.Subject = "Obscura Car Management";

            message.Body = new TextPart("html")
            {
                Text = "<h1>Hi, Matthew!</h1>" +
                "<p>You have successfully added a car to the list.</p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("a563851d548a8a", "9067d6d7b76a01");

                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
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