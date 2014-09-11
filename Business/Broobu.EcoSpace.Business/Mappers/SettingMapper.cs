using Iris.Fx.Core;
using Iris.Fx.Domain;
using Iris.Fx.Repository.Contract.Domain;
using System.Xml.Linq;


namespace Iris.Fx.Business.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    class SettingMapper : MapperBase<Setting,SettingItem>
    {
        /// <summary>
        /// Maps from service to business internal.
        /// </summary>
        /// <param name="serviceEntity">The service entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override SettingItem MapFromServiceToBusinessInternal(Setting serviceEntity)
        {
            return new SettingItem()
            {
                ApplicationFunctionId = serviceEntity.ApplicationFunctionId,
                RoleId = serviceEntity.RoleId,
                AccountId = serviceEntity.AccountId,
                SettingInfo = XElement.Parse(serviceEntity.SettingInfo, LoadOptions.None),
                ObjectId = serviceEntity.ObjectId
            };
        }

        /// <summary>
        /// Maps from business to service internal.
        /// </summary>
        /// <param name="serviceEntity">The service entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override Setting MapFromBusinessToServiceInternal(SettingItem serviceEntity)
        {
            return new Setting()
            {
                RoleId = serviceEntity.RoleId,
                AccountId = serviceEntity.AccountId,
                ApplicationFunctionId = serviceEntity.ApplicationFunctionId,
                SettingInfo = serviceEntity.SettingInfo.ToString(SaveOptions.DisableFormatting),
                ObjectId = serviceEntity.ObjectId
            };
        }
    }
}
