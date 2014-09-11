using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pms.Diagnostics.Contract.Domain
{
    public class DiagnosticsStatus
    {
        public const string Pending = "Pending";
        public const string Running = "Running";
        public const string Error = "Error";
        public const string Invalid = "Invalid";
        public const string Aborted = "Aborted";
        public const string Valid = "Valid";
    }
}
