using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.GeneralElement
{
    /// <summary>
    /// GeneralElemenClient interface
    /// </summary>
    public interface IGeneralElemenClient : IClientSetting
    {
        /// <summary>
        /// Returns the Region the bucket resides in. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        List<string> GetBucketLocation(GetBucketLocationRequest request);

    }
}
