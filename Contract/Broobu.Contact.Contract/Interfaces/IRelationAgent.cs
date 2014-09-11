//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System;
using Broobu.Contact.Contract.Domain;

namespace Broobu.Contact.Contract.Interfaces
{
  	public partial interface IRelationAgent: IRelation
  	{
		#region Events
		event Action<Relation> GetRelationItemCompleted;

		event Action<Relation[]> GetRelationItemsCompleted;

		event Action<Relation> SaveRelationItemCompleted;

		#endregion
		#region Methods
		void GetRelationItemAsync(string id, Action<Relation> action = null);

		void GetRelationItemsAsync(Action<Relation[]> action = null);

		void SaveRelationItemAsync(Relation relationItem, Action<Relation> action = null);

		#endregion

	}
}