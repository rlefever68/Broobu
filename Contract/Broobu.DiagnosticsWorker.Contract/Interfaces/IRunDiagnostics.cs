//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================
using Pms.Framework.Domain;
using System;
using System.ServiceModel;

namespace Pms.DiagnosticsWorker.Contract.Interfaces
{
	[ServiceContract(Namespace = "http://pms.diagnosticsworker/11/04")]
  	public partial interface IRunDiagnostics
  	{
		#region Methods
		[OperationContract]
		Result RunDiagnostics();

		[OperationContract]
		Result AddDiagnosticsPackage(byte[] package);

		#endregion

	}
}