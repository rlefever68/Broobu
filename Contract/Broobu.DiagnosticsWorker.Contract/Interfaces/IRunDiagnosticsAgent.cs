//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================
using Pms.Framework.Domain;
using System;

namespace Pms.DiagnosticsWorker.Contract.Interfaces
{
  	public partial interface IRunDiagnosticsAgent: IRunDiagnostics
  	{
		#region Events
		event Action<Result> RunDiagnosticsCompleted;

		event Action<Result> AddDiagnosticsPackageCompleted;

		#endregion
		#region Methods
		void RunDiagnosticsAsync(Action<Result> action = null);

		void AddDiagnosticsPackageAsync(byte[] package, Action<Result> action = null);

		#endregion

	}
}