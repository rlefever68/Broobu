using Pms.DiagnosticsWorker.Contract.Interfaces;
using Pms.Framework.Domain;
using Pms.Framework.Networking.Wcf;
using System;

namespace Pms.DiagnosticsWorker.Contract.Agent
{
	partial class RunDiagnosticsAgent: DiscoProxy<IRunDiagnostics>, IRunDiagnosticsAgent
	{
		#region Events
		public event Action<Result> RunDiagnosticsCompleted;
		public event Action<Result> AddDiagnosticsPackageCompleted;
		
		#endregion		
		#region Methods
		public Result RunDiagnostics()		{
			IRunDiagnostics clt = null;
			try
			{
				clt = CreateClient();
				return clt.RunDiagnostics();
			}
			finally
			{
				CloseClient(clt);
			}
		}
		public void RunDiagnosticsAsync(Action<Result> action = null)		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Result)null;
				wrk.DoWork += (s, e) =>
				{
					res = RunDiagnostics();
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (RunDiagnosticsCompleted != null)
						RunDiagnosticsCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		public Result AddDiagnosticsPackage(byte[] package)		{
			IRunDiagnostics clt = null;
			try
			{
				clt = CreateClient();
				return clt.AddDiagnosticsPackage(package);
			}
			finally
			{
				CloseClient(clt);
			}
		}
		public void AddDiagnosticsPackageAsync(byte[] package, Action<Result> action = null)		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Result)null;
				wrk.DoWork += (s, e) =>
				{
					res = AddDiagnosticsPackage(package);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (AddDiagnosticsPackageCompleted != null)
						AddDiagnosticsPackageCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		protected override string GetContractNamespace()		{
			return "http://pms.diagnosticsworker/11/04";
		}
			
		#endregion		
	}
}