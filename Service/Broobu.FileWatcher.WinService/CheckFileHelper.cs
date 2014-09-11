using System;
using System.IO;

namespace Pms.FileWatcher.WinService
{
    public static class CheckFileHelper
    {
        public static bool IsFileAZip(string path)
        {
            if (String.IsNullOrEmpty(path) || !File.Exists(path)) return false;
// ReSharper disable PossibleNullReferenceException
            var ext = Path.GetExtension(path).ToLower();
// ReSharper restore PossibleNullReferenceException
            return (ext==".zip" || ext == ".gz");
        }
    }
}
