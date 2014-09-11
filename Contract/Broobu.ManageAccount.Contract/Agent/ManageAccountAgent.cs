using System;
using Pms.ManageAccount.Contract.Interfaces;
using Pms.Framework.Networking.Wcf;
using System.ComponentModel;
using Pms.ManageAccount.Contract.Domain;

namespace Pms.ManageAccount.Contract.Agent
{
    class ManageAccountAgent : DiscoProxy2<IManageAccount>, IManageAccountAgent
    {
        #region IManageAccountAgent Members

        
        public event Action<AccountViewItem[]> GetAccountsCompleted;
        

        public void GetAccountsAsync()
        {
            GetAccountsAsync(GetAccountsCompleted);
        }

        public void GetAccountsAsync(Action<AccountViewItem[]> act)
        {
            WithValidClient( () => 
                {
                    AccountViewItem[] res = null;
                    using(var wrk = new BackgroundWorker())
                    {
                        wrk.DoWork += (s,e) => 
                        { 
                            res = GetAccounts(); 
                        };
                        wrk.RunWorkerCompleted += (s,e) => 
                        {  
                            wrk.Dispose();
                            if(act!=null)
                                act.Invoke(res);
                        };
                        wrk.RunWorkerAsync();
                    }
                });
        }

        #endregion

        #region IManageAccount Members

        public Domain.AccountViewItem[] GetAccounts()
        {
            return Client.GetAccounts();
        }

        #endregion

    }
}
