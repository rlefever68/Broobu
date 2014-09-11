using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broobu.Publisher.Business.Bags;
using Broobu.Publisher.Business.Smtp;
using Broobu.Publisher.Contract.Domain;
using Broobu.Publisher.Contract.Interfaces;
using Wulka.Data;
using Wulka.Domain;
using Wulka.Exceptions;
using NLog;

namespace Broobu.Publisher.Business.Workers
{
    public class Emails : IPublish
    {


        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
            /// <summary>
        /// Publishes the specified information.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>PublishInfo.</returns>
        public PublishInfo Publish(PublishInfo info)
        {
            try
            {
                info.AddParameter("PlatformName",PublishConfig.PlatformName);
                info.AddParameter("PlatformMoreInfoUrl",PublishConfig.PlatformMoreInfoUrl);
                info.AddParameter("PlatformMoreInfoEmail",PublishConfig.PlatformMoreInfoEmail);
                _logger.Info("Publishing.....{0}", info);
                var msg = info.ToMailMessage();
                Mailer.SendEmail(msg);
                EmailBag.AddEmail(info);
                return info;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessage());
                info.AddError(ex.GetCombinedMessages());
            }
            return info;
        }

        public static void InflateDomain()
        {
            var res = Factory.CreateDefaultEmailBag();
            Provider<EmailBag>.Save(res);
            var tmp = Factory.CreateDefaultTemplateBag();
            Provider<TemplateBag>.Save(tmp);
            
        }
    }
}
