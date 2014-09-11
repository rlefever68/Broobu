using Pms.ManageDiagnostics.Contract.Interfaces;

namespace Pms.ManageDiagnostics.Contract.Agent
{
	public partial class ManageDiagnosticsAgentFactory
	{
		#region Methods
		public static IManageDiagnosticsAgent CreateManageDiagnosticsAgent()		{
			return new ManageDiagnosticsAgent();
		}
			
		#endregion		
	}
}