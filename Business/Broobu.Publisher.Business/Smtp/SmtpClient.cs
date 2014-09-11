using System;
using System.Net;
using System.Net.Mail;
using Wulka.Exceptions;
using NLog;

namespace Broobu.Publisher.Business.Smtp
{
    public static class Mailer
    {

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void SendEmail(MailMessage message)
        {
            try
            {
                foreach(var to in message.To)
                {
                    Logger.Info("Sending Email to {0}", to.Address);
                }
                var clt = new SmtpClient
                {
                    Host = SmtpConfig.SmtpHost,
                    Port = SmtpConfig.SmtpPort,
                    Credentials = new NetworkCredential(SmtpConfig.SmtpUser, SmtpConfig.SmtpPwd),
                    EnableSsl = SmtpConfig.SmtpUseSsl
                };
                clt.Send(message);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.GetCombinedMessages());
            }

        }
    }
}
