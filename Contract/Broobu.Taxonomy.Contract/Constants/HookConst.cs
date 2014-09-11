using System.Collections.Generic;
using Broobu.Taxonomy.Contract.Domain;

namespace Broobu.Taxonomy.Contract.Constants
{
    /// <summary>
    /// Class EnumerationConst.
    /// </summary>
    public class HookConst
    {
        /// <summary>
        /// The root
        /// </summary>
        public static string Root = "HOOK_ROOT";

        /// <summary>
        /// The type enum
        /// </summary>
        public static string EnumRoot = "HOOK_ENUMS";

        /// <summary>
        /// The gender enum
        /// </summary>
        public static string GenderEnum = "ENUM_GENDER";

        /// <summary>
        /// The gender male enum
        /// </summary>
        public static string GenderMaleEnum = "ENUM_GENDER_MALE";

        /// <summary>
        /// The gender female enum
        /// </summary>
        public static string GenderFemaleEnum = "ENUM_GENDER_FEMALE";

        /// <summary>
        /// The gender unknown enum
        /// </summary>
        public static string GenderUnknownEnum = "ENUM_GENDER_UNKNOWN";


        /// <summary>
        /// The eco space root
        /// </summary>
        public const string EcoSpaceRoot = "HOOK_ECOSPACE";

        /// <summary>
        /// The root hook
        /// </summary>
        public static Hook RootHook = new RootHook();

        /// <summary>
        /// The description type default
        /// </summary>
        public static string DescriptionTypeDefault = "ENUM_DESCRIPTION_TYPE_DEFAULT";

        /// <summary>
        /// The description type enum
        /// </summary>
        public static string DescriptionTypeEnum = "ENUM_DESCRIPTION_TYPE";

        public static string DescriptionTypeAlternative = "ENUM_DESCRIPTION_TYPE_ALT";
        public static string DataCultureEnum = "ENUM_DATA_CULTURE";
        public static string DataCultureEnumEnglish = "en-US";
        public static string DataCultureEnumDutch = "nl-NL";
        public static string DataCultureEnumFrench = "fr-FR";
        public static string DataCultureEnumGerman = "de-DE";
        public static string DataCultureEnumSpanish = "es-ES";
        public static string DataCultureEnumItalian = "it-IT";
        public static string PublicEcoSpace = "ECO_PUBLIC";
        public static string PrivateEcoSpaces = "ECO_PRIVATE";
        public static string RoleRoot = "ROLE_ROOT";
    }
}