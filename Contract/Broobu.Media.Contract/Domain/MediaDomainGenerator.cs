using System.Web.Hosting;
using Broobu.Media.Contract.Interfaces;
using Iris.Fx.Domain;
using Iris.Fx.Utils;

namespace Broobu.Media.Contract.Domain
{
    public class MediaDomainGenerator
    {
        public static EnumerationItem[] CreateEnumerationDefaults()
        {
            //var res = new[]
            //{
            //    new EnumerationItem()
            //    {
            //        Id = EnumerationConst.Root,
            //        Title = "Enumerations",
            //        TypeId = SysConst.NullGuid
            //    }, 
            //    new EnumerationItem()
            //    {
            //        Id = EnumerationConst.TypeEnum,
            //        Title = "Enumeration Types",
            //        TypeId = EnumerationConst.Root
            //    }, 
            //    new EnumerationItem()
            //    {
            //        Id = EnumerationConst.GenderEnum,
            //        Title = "Genders",
            //        TypeId = EnumerationConst.TypeEnum,
            //    },
            //    new EnumerationItem()
            //    {
            //        Id = EnumerationConst.GenderMaleEnum,
            //        Title = "Male",
            //        TypeId = EnumerationConst.GenderEnum
            //    },
            //    new EnumerationItem()
            //    {
            //        Id = EnumerationConst.GenderFemaleEnum,
            //        Title = "Female",
            //        TypeId = EnumerationConst.GenderEnum
            //    },
            //    new EnumerationItem()
            //    {
            //        Id = EnumerationConst.GenderUnknownEnum,
            //        Title = "Unknown",
            //        TypeId = EnumerationConst.GenderEnum
            //    }
            //};

            var path = HostingEnvironment.MapPath(MediaServiceConst.DefaultEnumerationsXmlPath);
           // DomainSerializer<EnumerationItem[]>.Serialize(res,path);
            return DomainSerializer<EnumerationItem[]>.Deserialize(path);     
        }



        /// <summary>
        /// Creates the default setting.
        /// </summary>
        /// <returns></returns>
        public static SettingItem CreateDefaultSetting()
        {
            return new SettingItem()
            {
                Id = SysConst.NullGuid,
                RoleId = SysConst.NullGuid,
                ApplicationFunctionId = SysConst.NullGuid,
                AccountId = SysConst.NullGuid,
                ObjectId = SysConst.NullGuid,
            };
        }


    }

    public class EnumerationConst
    {
        public static string Root = "ENUM_ROOT";
        public static string TypeEnum = "ENUM_TYPE";
        public static string GenderEnum = "ENUM_TYPE_GENDER";
        public static string GenderMaleEnum = "ENUM_GENDER_MALE";
        public static string GenderFemaleEnum = "ENUM_GENDER_FEMALE";
        public static string GenderUnknownEnum = "ENUM_GENDER_UNKNOWN";


    }
}
