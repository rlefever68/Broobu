//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System;
using Broobu.Taxonomy.Contract.Domain;
using Description = Broobu.Taxonomy.Contract.Domain.Description;

namespace Broobu.Taxonomy.Contract.Interfaces
{
  	public partial interface ITranslateAgent: ITranslate
  	{
		#region Events
		event Action<Description> GetDescriptionCompleted;

		event Action<Description[]> GetDescriptionsForObjectCompleted;

		event Action<Description[]> GetDescriptionsForTypeCompleted;

		event Action<Description[]> GetDescriptionsForCultureCompleted;

		event Action<Description[]> GetDescriptionsForObjectAndCultureCompleted;

		event Action<Description[]> GetDescriptionsForObjectAndTypeCompleted;

		event Action<Description[]> GetDescriptionsForObjectCultureAndTypeCompleted;

		event Action<Description[]> GetDescriptionsForCultureAndTypeCompleted;

		event Action<Description[]> GetDescriptionsLikeTitleCompleted;

		event Action<Description> SaveDescriptionCompleted;

		event Action<Description> DeleteDescriptionCompleted;

		#endregion
		#region Methods
		void GetDescriptionAsync(string id, Action<Description> action = null);

		void GetDescriptionsForObjectAsync(string objectId, string displayName = "Unknown", Action<Description[]> action = null);

		void GetDescriptionsForTypeAsync(string typeId, Action<Description[]> action = null);

		void GetDescriptionsForCultureAsync(string objectId, Action<Description[]> action = null);

		void GetDescriptionsForObjectAndCultureAsync(string objectId, string cultureId, Action<Description[]> action = null);

		void GetDescriptionsForObjectAndTypeAsync(string objectId, string typeId, Action<Description[]> action = null);

		void GetDescriptionsForObjectCultureAndTypeAsync(string objectId, string cultureId, string typeId, Action<Description[]> action = null);

		void GetDescriptionsForCultureAndTypeAsync(string cultureId, string typeId, Action<Description[]> action = null);

		void GetDescriptionsLikeTitleAsync(string title, Action<Description[]> action = null);

		void SaveDescriptionAsync(Description description, Action<Description> action = null);

		void DeleteDescriptionAsync(Description description, Action<Description> action = null);

		#endregion

	}
}