//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================
using Pms.Diagnostics.Contract.Domain;
using System;

namespace Pms.Diagnostics.Contract.Interfaces
{
  	public partial interface IDiagnosticsAgent: IDiagnostics
  	{
		#region Events
		event Action<DiagnosticsRunItem[]> GetDiagnosticsRunItemsForDateCompleted;

		event Action<DiagnosticsRunDetailItem[]> GetDiagnosticsDetailsForRunCompleted;

		#endregion
		#region Methods
		void GetDiagnosticsRunItemsForDateAsync(DateTime date, Action<DiagnosticsRunItem[]> action = null);

		void GetDiagnosticsDetailsForRunAsync(string id, Action<DiagnosticsRunDetailItem[]> action = null);

		#endregion

	}
}