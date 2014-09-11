using Pms.Diagnostics.Contract.Domain;
using Pms.Diagnostics.Contract.Interfaces;
using Pms.Framework.Networking.Wcf;
using System;

namespace Pms.Diagnostics.Contract.Agent
{
	partial class DiagnosticsAgent: DiscoProxy<IDiagnostics>, IDiagnosticsAgent
	{
		#region Events
		public event Action<DiagnosticsRunItem[]> GetDiagnosticsRunItemsForDateCompleted;
		public event Action<DiagnosticsRunDetailItem[]> GetDiagnosticsDetailsForRunCompleted;
		
		#endregion		
		#region Methods
		public DiagnosticsRunItem[] GetDiagnosticsRunItemsForDate(DateTime date)		{
			IDiagnostics clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDiagnosticsRunItemsForDate(date);
			}
			finally
			{
				CloseClient(clt);
			}
		}
		public void GetDiagnosticsRunItemsForDateAsync(DateTime date, Action<DiagnosticsRunItem[]> action = null)		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DiagnosticsRunItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDiagnosticsRunItemsForDate(date);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDiagnosticsRunItemsForDateCompleted != null)
						GetDiagnosticsRunItemsForDateCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		public DiagnosticsRunDetailItem[] GetDiagnosticsDetailsForRun(string id)		{
			IDiagnostics clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDiagnosticsDetailsForRun(id);
			}
			finally
			{
				CloseClient(clt);
			}
		}
		public void GetDiagnosticsDetailsForRunAsync(string id, Action<DiagnosticsRunDetailItem[]> action = null)		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DiagnosticsRunDetailItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDiagnosticsDetailsForRun(id);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDiagnosticsDetailsForRunCompleted != null)
						GetDiagnosticsDetailsForRunCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		protected override string GetContractNamespace()		{
			return "http://pms.diagnostics/11/04";
		}
			
		#endregion		
	}
}