using System;
using System.Diagnostics;
using System.Transactions;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pms.Contact.Business.Interfaces;
using Pms.Contact.Contract.Domain;
using Pms.Framework.Domain;

namespace Pms.Contact.Business.Test
{
    [TestClass]
    public class ContactTestFixture
    {
        private readonly ILog _logger;

        public ContactTestFixture()
        {
            _logger = LogManager.GetLogger(GetType()); 
        }

        [Ignore]
        public void TryDeleteDocumentItem()
        {
            var id                   = "13F0CBA5-C2E7-4251-86BE-59CC01AD49FD";
            var identificationNumber = "4DDE638F-7632-4A77-8FE8-7B62C06AE154";// "8dfdd485-68f2-48cd-883b-cc0f43e94fd2";
            var typeId               = "A07C5CE3-659C-4FCC-A60B-5CCB6E26B8A4";// "1b453a59-b318-4e14-8684-83f0b78fa8a1";

            Debug.WriteLine(identificationNumber);
            IContactProvider p = ContactProviderFactory.CreateProvider();
            var savedDocument = p.SaveDocumentItem(new DocumentItem{Id = id,IdentificationNumber = identificationNumber, TypeId = typeId, IssueDate = DateTime.Now});

            Debug.WriteLine(savedDocument.ToString());


            using (TransactionScope scope = new TransactionScope())
            {
                p.DeleteDocumentItem(id);
            }
            var result1 = p.GetDocumentItem(id);

            Assert.IsNotNull(result1);


            using (TransactionScope scope = new TransactionScope())
            {
                var result2 = p.DeleteDocumentItem(id);
                scope.Complete();
            }
            var result3 = p.GetDocumentItem(id);

            Assert.IsNull(result3);

        }


        [TestMethod]
        public void TryGenerate()
        {
            IContactProvider p = ContactProviderFactory.CreateProvider();
            p.GenerateDefaultData();
            
        }

        [Ignore]
        public void TryGenerateDefaultData()
        {
            Debug.WriteLine("TryGenerateDefaultData started on " + DateTime.Now);
            _logger.Info("TryGenerateDefaultData started on " + DateTime.Now);
            IContactProvider p = ContactProviderFactory.CreateProvider();
            Result result = p.GenerateDefaultData();
            if (result.HasErrors)
            {
                Debug.WriteLine(string.Format("Contact.GenerateDefaultData() reported {0} errors", result.ErrorCount));
                _logger.ErrorFormat("GenerateDefaultData reported {0} errors", result.ErrorCount);
            }
            Assert.IsFalse(result.HasErrors, "GenerateDefaultData() generated errors");
            Debug.WriteLine("TryGenerateDefaultData finished on " + DateTime.Now);
        }


    }
}
