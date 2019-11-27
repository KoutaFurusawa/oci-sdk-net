using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Model;
using OCISDK.Core.Identity.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    class IdentityUsersExample
    {
        public static void ConsoleDisplay(ClientConfig config)
        {
            var identityClient = new IdentityClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            LoadOciUsers(identityClient);
            
            Console.WriteLine("* Users------------------------");
            var listUsersRequest = new ListUsersRequest()
            {
                CompartmentId = config.TenancyId
            };

            var users = identityClient.ListUsers(listUsersRequest).Items;
            foreach (var user in users)
            {
                Console.WriteLine($" |-{user.Name}");
                Console.WriteLine($" | providerId: {user.IdentityProviderId}");
                Console.WriteLine($" | inactiveStatus: {user.InactiveStatus}");
                Console.WriteLine($" | lifecycleState: {user.LifecycleState}");
                Console.WriteLine($" | mfaActivated: {user.IsMfaActivated}");
                Console.WriteLine($" | timeCreated: {user.TimeCreated}");
            }
        }

        private static IEnumerable<UserDetails> OciUsers;

        private static void LoadOciUsers(IdentityClient client)
        {
            OciUsers = GetOciUsers(client, null);
        }

        private static IEnumerable<UserDetails> GetOciUsers(IdentityClient client, string pageId)
        {
            var res = new List<UserDetails>();

            var listUsersRequest = new ListUsersRequest()
            {
                CompartmentId = client.Config.TenancyId,
                Page = pageId,
                Limit = 2
            };
            var users = client.ListUsers(listUsersRequest);

            res.AddRange(users.Items);

            if (!string.IsNullOrEmpty(users.OpcNextPage))
            {
                res.AddRange(GetOciUsers(client, users.OpcNextPage));
            }

            return res;
        }

    }
}
