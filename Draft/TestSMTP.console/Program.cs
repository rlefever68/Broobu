
using System;
using System.Net;
using System.Net.Mail;

namespace TestSMTP.console
{
    class Program
    {

      


        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Sending");
                var clt = new SmtpClient {Host = "smtp.telenet.be", Port = 587};
                var cred = new NetworkCredential("z112012", "raf012");
                clt.Credentials = cred;
                clt.EnableSsl = true;
                clt.Send("mailer@tropus.be", "rafael.lefever@gmail.com", "test", "test");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}
