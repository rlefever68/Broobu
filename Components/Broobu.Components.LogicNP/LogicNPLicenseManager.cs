using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicNP.ShellObjects;

namespace Broobu.Components.LogicNP
{
    public class LogicNPLicenseManager
    {

        private const string LicenseKey =
            @"O@?>AEHeZlDibB@JZVXidlTvKkTraVXmZVOdRWftZWH-cxnvYVXeZVurbFTjZWXicj@kbVDmbB3gb1.>9sMQDT@/XE.eGVVIx`-ecqS_Mqa@8APAh32Q/bWM8BApPgja24pP0K2HP`wjMNr5";

        public static void RegisterShellObjects()
        {
            const string prefix = "Welcome to the ShellObjects Sample";
            const string licKey = prefix + LicenseKey;
            var popup = new ShellPopup {TextString = licKey};
        }

    }
}
