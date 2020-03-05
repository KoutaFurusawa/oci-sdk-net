using OCISDK.Core.UnpublishedService.ConsoleIdcs.Request;
using OCISDK.Core.UnpublishedService.ConsoleIdcs.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.ConsoleIdcs
{
    /// <summary>
    /// ConsoleIdcsClient interface
    /// </summary>
    public interface IConsoleIdcsClient : IClientSetting
    {
        /// <summary>
        /// GetIdcsUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetIdcsUserResponse GetIdcsUser(GetIdcsUserRequest request);
    }
}
