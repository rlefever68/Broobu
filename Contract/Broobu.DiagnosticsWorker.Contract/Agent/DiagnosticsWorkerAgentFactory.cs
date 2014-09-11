using Pms.DiagnosticsWorker.Contract.Interfaces;

namespace Pms.DiagnosticsWorker.Contract.Agent
{
	public partial class DiagnosticsWorkerAgentFactory
	{
		#region Methods
		public static IRunDiagnosticsAgent CreateRunDiagnosticsAgent()		{
			return new RunDiagnosticsAgent();
		}
			
		#endregion		
	}
}