//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================
using Pms.Framework.Domain;
using Pms.ManageDiagnostics.Contract.Domain;
using System;
using System.ServiceModel;

namespace Pms.ManageDiagnostics.Contract.Interfaces
{
	[ServiceContract(Namespace = "http://pms.managediagnostics/11/06")]
  	public partial interface IManageDiagnostics
  	{
		#region Methods
		[OperationContract]
		Result StartDiagnostics();

		[OperationContract]
		Result AddDiagnosticsPackage(byte[] package);

		[OperationContract]
		DiagnosticsBatchViewItem[] GetDiagnosticsReportsByDate(DateTime date);

		[OperationContract]
		DiagnosticsViewItem[] GetDiagnosticsReport(string reportId);

		#endregion

	}
}