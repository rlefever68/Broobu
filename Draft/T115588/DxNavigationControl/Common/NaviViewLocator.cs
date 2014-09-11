using DevExpress.Mvvm.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxNavigationControl.Views;

namespace DxNavigationControl.Common
{
    public class NaviViewLocator : IViewLocator
    {
        #region IViewLocator Member

        object IViewLocator.ResolveView(string name)
        {
            if (name.ToLower() == "startview")
                return new StartView();

            return null;
        }

        #endregion
    }
}
