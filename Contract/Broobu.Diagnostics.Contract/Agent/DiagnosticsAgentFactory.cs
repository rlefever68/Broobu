using Pms.Diagnostics.Contract.Interfaces;

namespace Pms.Diagnostics.Contract.Agent
{
	public partial class DiagnosticsAgentFactory
	{
		#region Methods
		public static IDiagnosticsAgent CreateDiagnosticsAgent()		{
			return new DiagnosticsAgent();
		}
			
		#endregion		
	}
}