/// <summary>
/// Enums
/// 
/// author: koutaro furusawa
/// </summary>
using System.ComponentModel;

namespace OCISDK.Core.src.Common
{
    public enum SortOrder
    {
        [DisplayName("ASC")]
        ASC,
        [DisplayName("DESC")]
        DESC
    }

    public enum SortBy
    {
        [DisplayName("ID")]
        ID,
        [DisplayName("TIMECREATED")]
        TIMECREATED,
        [DisplayName("DISPLAYNAME")]
        DISPLAYNAME
    }

    public enum ServerType
    {
        [DisplayName("VcnLocal")]
        VcnLocal,
        [DisplayName("VcnLocalPlusInternet")]
        VcnLocalPlusInternet,
        [DisplayName("CustomDnsServer")]
        CustomDnsServer
    }
}
