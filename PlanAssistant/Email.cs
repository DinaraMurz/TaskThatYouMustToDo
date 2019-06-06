using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace PlanAssistant
{
    public class Email : Entity
    {
        // отправитель - устанавливаем адрес и отображаемое в письме имя
        public MailAddress From { get; set; }
        public MailAddress To { get; set; }

        public Email()
        {
            From = new MailAddress("dinara_myrzabek@mail.ru", "Dinara");
        }

        public void SendMessage(string header, string text)
        {
            From = new MailAddress("dinara_myrzabek@mail.ru", "Dinara");


            MailMessage m = new MailMessage(From, To);

            m.Subject = header;
            m.Body = text;
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient(From.Address, 587);
            smtp.Credentials = new NetworkCredential(From.Address, "J21Z9Z4U");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
