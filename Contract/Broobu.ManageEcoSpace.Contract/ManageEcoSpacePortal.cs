using Broobu.ManageEcoSpace.Contract.Agent;
using Broobu.ManageEcoSpace.Contract.Interfaces;

namespace Broobu.ManageEcoSpace.Contract
{
	public static class ManageEcoSpacePortal
	{

		public static IManageEcoSpaceAgent Agent		
        {
            get { return new ManageEcoSpaceAgent(); }
		}


	}
}