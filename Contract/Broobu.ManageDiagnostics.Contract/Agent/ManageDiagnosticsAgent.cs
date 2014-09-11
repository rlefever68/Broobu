using Pms.Framework.Domain;
using Pms.Framework.Networking.Wcf;
using Pms.ManageDiagnostics.Contract.Domain;
using Pms.ManageDiagnostics.Contract.Interfaces;
using System;

namespace Pms.ManageDiagnostics.Contract.Agent
{
	partial class ManageDiagnosticsAgent: DiscoProxy<IManageDiagnostics>, IManageDiagnosticsAgent
	{
		#region Events
		public event Action<Result> StartDiagnosticsCompleted;
		public event Action<Result> AddDiagnosticsPackageCompleted;
		public event Action<DiagnosticsBatchViewItem[]> GetDiagnosticsReportsByDateCompleted;
		public event Action<DiagnosticsViewItem[]> GetDiagnosticsReportCompleted;
		
		#endregion		
		#region Methods
		public Result StartDiagnostics()		{
			IManageDiagnostics clt = null;
			try
			{
				clt = CreateClient();
				return clt.StartDiagnostics();
			}
			finally
			{
				CloseClient(clt);
			}
		}
		public void StartDiagnosticsAsync(Action<Result> action = null)		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Result)null;
				wrk.DoWork += (s, e) =>
				{
					res = StartDiagnostics();
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (StartDiagnosticsCompleted != null)
						StartDiagnosticsCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		public Result AddDiagnosticsPackage(byte[] package)		{
			IManageDiagnostics clt = null;
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
		public DiagnosticsBatchViewItem[] GetDiagnosticsReportsByDate(DateTime date)		{
			IManageDiagnostics clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDiagnosticsReportsByDate(date);
			}
			finally
			{
				CloseClient(clt);
			}
		}
		public void GetDiagnosticsReportsByDateAsync(DateTime date, Action<DiagnosticsBatchViewItem[]> action = null)		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DiagnosticsBatchViewItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDiagnosticsReportsByDate(date);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDiagnosticsReportsByDateCompleted != null)
						GetDiagnosticsReportsByDateCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		public DiagnosticsViewItem[] GetDiagnosticsReport(string reportId)		{
			IManageDiagnostics clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDiagnosticsReport(reportId);
			}
			finally
			{
				CloseClient(clt);
			}
		}
		public void GetDiagnosticsReportAsync(string reportId, Action<DiagnosticsViewItem[]> action = null)		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DiagnosticsViewItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDiagnosticsReport(reportId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDiagnosticsReportCompleted != null)
						GetDiagnosticsReportCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		protected override string GetContractNamespace()		{
			return "http://pms.managediagnostics/11/06";
		}
			
		#endregion		
	}
}