using Pms.SoaStudio.Contract.Interfaces;

namespace Pms.SoaStudio.Contract.Agent
{
	public partial class SoaStudioAgentFactory
	{
		#region Methods
		public static ISoaStudioAgent CreateSoaStudioAgent()		
        {
			return new SoaStudioAgent();
		}
			
		#endregion		
	}
}