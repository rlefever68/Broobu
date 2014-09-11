//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System;
using Iris.Fx.Domain;

namespace Broobu.Media.Contract.Interfaces
{
  	public partial interface IDescriptionAgent: IDescription
  	{
		#region Events
		event Action<DescriptionItem> GetDescriptionItemCompleted;

		event Action<DescriptionItem[]> GetDescriptionItemsForObjectCompleted;

		event Action<DescriptionItem[]> GetDescriptionItemsForTypeCompleted;

		event Action<DescriptionItem[]> GetDescriptionItemsForCultureCompleted;

		event Action<DescriptionItem[]> GetDescriptionItemsForObjectAndCultureCompleted;

		event Action<DescriptionItem[]> GetDescriptionItemsForObjectAndTypeCompleted;

		event Action<DescriptionItem[]> GetDescriptionItemsForObjectCultureAndTypeCompleted;

		event Action<DescriptionItem[]> GetDescriptionItemsForCultureAndTypeCompleted;

		event Action<DescriptionItem[]> GetDescriptionItemsLikeTitleCompleted;

		event Action<DescriptionItem> SaveDescriptionCompleted;

		event Action<DescriptionItem> DeleteDescriptionCompleted;

		#endregion
		#region Methods
		void GetDescriptionItemAsync(string id, Action<DescriptionItem> action = null);

		void GetDescriptionItemsForObjectAsync(string objectId, Action<DescriptionItem[]> action = null);

		void GetDescriptionItemsForTypeAsync(string typeId, Action<DescriptionItem[]> action = null);

		void GetDescriptionItemsForCultureAsync(string objectId, Action<DescriptionItem[]> action = null);

		void GetDescriptionItemsForObjectAndCultureAsync(string objectId, string cultureId, Action<DescriptionItem[]> action = null);

		void GetDescriptionItemsForObjectAndTypeAsync(string objectId, string typeId, Action<DescriptionItem[]> action = null);

		void GetDescriptionItemsForObjectCultureAndTypeAsync(string objectId, string cultureId, string typeId, Action<DescriptionItem[]> action = null);

		void GetDescriptionItemsForCultureAndTypeAsync(string cultureId, string typeId, Action<DescriptionItem[]> action = null);

		void GetDescriptionItemsLikeTitleAsync(string title, Action<DescriptionItem[]> action = null);

		void SaveDescriptionAsync(DescriptionItem description, Action<DescriptionItem> action = null);

		void DeleteDescriptionAsync(DescriptionItem description, Action<DescriptionItem> action = null);

		#endregion

	}
}