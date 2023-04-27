// See https://aka.ms/new-console-template for more information
using MailKit.Net.Smtp;
using MimeKit;

Console.WriteLine("Hello, World!");

var message = new MimeMessage();
message.From.Add(new MailboxAddress("Room6 Bot", "info@room6.online"));
message.To.Add(new MailboxAddress("User", "d2c.tool@gmail.com"));
message.Subject = "How you doin'?";

message.Body = new TextPart("plain")
{
    Text = @"Hey Chandler,

I just wanted to let you know that Monica and I were going to go play some paintball, you in?

-- Joey"
};

using (var client = new SmtpClient())
{
    client.Connect("smtp-relay.sendinblue.com", 587, false);

    // Note: only needed if the SMTP server requires authentication
    client.Authenticate("d2c.tool@gmail.com", "xsmtpsib-33e3b3fdb631da874302095081f882dadd4144714d9a9b6f28fc29469b9d6426-PJ2YDQ0XcO4UdN86");

    client.Send(message);
    client.Disconnect(true);
}