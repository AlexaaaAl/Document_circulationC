using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Document_circulation
{
    class SendMail
    {
        
        public static void SEND_MAIlTORECIP (string to_recip,string text_mail)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя

            MailAddress from = new MailAddress("adzulaj@gmail.com", "Документооборот");
            // кому отправляем
            MailAddress to = new MailAddress(to_recip);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "АСУП 'Алиса'";
            // текст письма
            m.Body = "<h2>Документ: <br> " + text_mail + "</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("adzulaj@gmail.com", "Alex_j_s_41");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
