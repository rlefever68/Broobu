//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================
using Pms.Framework.Domain;
using Pms.ManageDiagnostics.Contract.Domain;
using System;

namespace Pms.ManageDiagnostics.Contract.Interfaces
{
  	public partial interface IManageDiagnosticsAgent: IManageDiagnostics
  	{
		#region Events
		event Action<Result> StartDiagnosticsCompleted;

		event Action<Result> AddDiagnosticsPackageCompleted;

		event Action<DiagnosticsBatchViewItem[]> GetDiagnosticsReportsByDateCompleted;

		event Action<DiagnosticsViewItem[]> GetDiagnosticsReportCompleted;

		#endregion
		#region Methods
		void StartDiagnosticsAsync(Action<Result> action = null);

		void AddDiagnosticsPackageAsync(byte[] package, Action<Result> action = null);

		void GetDiagnosticsReportsByDateAsync(DateTime date, Action<DiagnosticsBatchViewItem[]> action = null);

		void GetDiagnosticsReportAsync(string reportId, Action<DiagnosticsViewItem[]> action = null);

		#endregion

	}
}