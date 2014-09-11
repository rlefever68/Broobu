using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wulka.Domain;
using Wulka.Domain.Base;

namespace Broobu.Publisher.Contract.Domain
{
    public static class Factory
    {
        public static PublishInfo CreateTestConfirmationEmail()
        {
            var res = new PublishInfo()
            {
                Source = "rafael.lefever@gmail.com",
                Targets = new[] { "rafael.lefever@gmail.com", "rafael.lefever@insoft.com" },
                TemplateId = ConfirmationEmailTemplate.ID
            };
            res.AddParameter( new Parameter() {Id="ActivationLink", Value = "http://www.broobu.com/cloudeen/activation/{0}/{1}"});
            res.AddParameter( new Parameter() {Id="EmailFirstName", Value = "Rafael"});
            return res;
        }

    }
}
