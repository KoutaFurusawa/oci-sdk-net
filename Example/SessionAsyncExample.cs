using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Core;
using OCISDK.Core.Core.Request.Compute;
using OCISDK.Core.Core.Request.VirtualNetwork;
using OCISDK.Core.Core.Request.WorkRequest;
using OCISDK.Core.Core.Response.Compute;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Model;
using OCISDK.Core.Identity.Request;
using OCISDK.Core.Identity.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static OCISDK.Core.Common.ConfigFileReader;

namespace Example
{
    class SessionAsyncExample
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("+----------------------------------------+");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|       OCISDK SessionAsyncExample       |");
            Console.WriteLine("|                                        |");
            Console.WriteLine("+----------------------------------------+");

            string configPath = ".oci/config";

            System.OperatingSystem os = System.Environment.OSVersion;
            // windows
            if (os.Platform == PlatformID.Win32NT)
            {
                string rootPath = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
                configPath = $"{rootPath}/{configPath}";
                if (!Directory.Exists($"{rootPath}/.oci"))
                {
                    Directory.CreateDirectory($"{rootPath}/.oci");
                }
            }
            else
            {
                configPath = $"/home/user/{configPath}";
            }

            string profile;
            ConfigFile configReader;
            if (File.Exists(configPath))
            {
                Console.Write("Connection ProfileName(Empty Input is DEFAULT): ");
                profile = Console.ReadLine();
                if (string.IsNullOrEmpty(profile))
                {
                    profile = "DEFAULT";
                }

                // load connection file
                configReader = ConfigFileReader.Parse(configPath, profile);
            }
            else
            {
                profile = "DEFAULT";

                // create connection file
                Console.WriteLine("Create connection settings to Oracle Cloud Infrastructure");

                Console.Write("TenancyId (Required): ");
                string tenancyId = OCIDInput();

                Console.Write("UserId (Required): ");
                string userId = OCIDInput();

                Console.Write("Fingerprint (Required): ");
                string fingerprint = KeyInput();

                Console.Write("PrivateKeyPath (Required): ");
                string privateKeyPath = KeyInput();

                Console.Write("PrivateKeyPassphrase: ");
                string privateKeyPassphrase = InputPassword();

                string testFileContentsMyProfile = $"[{profile}]\n" +
                    $"tenancy={tenancyId}\n" +
                    $"user={userId}\n" +
                    $"fingerprint={fingerprint}\n" +
                    $"key_file={privateKeyPath}\n" +
                    $"pass_phrase={privateKeyPassphrase}\n";

                File.WriteAllText(configPath, testFileContentsMyProfile);

                configReader = ConfigFileReader.Parse(configPath, profile);
            }

            // ClientConfig settings
            var configSt = new ClientConfigStream();
            IOciSession session;
            var stt = File.ReadAllText(configReader.Get("key_file"));


            using (var st = File.OpenText(configReader.Get("key_file")))
            {
                configSt = new ClientConfigStream
                {
                    TenancyId = configReader.Get("tenancy"),
                    UserId = configReader.Get("user"),
                    Fingerprint = configReader.Get("fingerprint"),
                    PrivateKey = st,
                    PrivateKeyPassphrase = configReader.Get("pass_phrase"),
                    AccountId = configReader.Get("accountId"),
                    DomainName = configReader.Get("domain_name"),
                    IdentityDomain = configReader.Get("identity_domain"),
                    UserName = configReader.Get("user_name"),
                    Password = configReader.Get("password"),
                    HomeRegion = configReader.Get("home_region")
                };

                session = new OciSession(configSt);
            }

            // get Client
            var identityClientAsync = session.GetIdentityClientAsync();
            var computeClientAsync = session.GetComputeClientAsync();
            var virtualNetworkClientAsync = session.GetVirtualNetworkClientAsync();

            // get tenant
            var getTenancyRequest = new GetTenancyRequest()
            {
                TenancyId = configSt.TenancyId
            };
            var getTenacy = await identityClientAsync.GetTenancy(getTenancyRequest);

            Console.WriteLine($"tenantName: {getTenacy.Tenancy.Name}");

            // get compartments
            var listCompartmentRequest = new ListCompartmentRequest()
            {
                CompartmentId = configSt.TenancyId,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE,
                CompartmentIdInSubtree = true
            };
            var compartments = await identityClientAsync.ListCompartment(listCompartmentRequest);

            // loop get compartments async
            var infoTasks = new List<Task>();
            foreach (var com in compartments.Items)
            {
                if (com.LifecycleState != "ACTIVE")
                {
                    continue;
                }
                
                infoTasks.Add(LoadCompartmentDetail(com, identityClientAsync));
                infoTasks.Add(LoadInstances(com, computeClientAsync));
                infoTasks.Add(LoadVcn(com, virtualNetworkClientAsync));
            }

            await Task.WhenAll(infoTasks);

            Console.WriteLine();
            Console.WriteLine("Exit with key press...");
            Console.ReadLine();
        }

        private static async Task LoadCompartmentDetail(Compartment compartment, IIdentityClientAsync identityClientAsync)
        {
            var getCompartmentRequest = new GetCompartmentRequest()
            {
                CompartmentId = compartment.Id
            };

            var compartmentTask = await identityClientAsync.GetCompartment(getCompartmentRequest);
            Console.WriteLine($"loaded compartmentDetail: {compartmentTask.Compartment.Name}");
        }

        private static async Task LoadInstances(Compartment compartment, IComputeClientAsync computeClientAsync)
        {
            var listInstancesRequest = new ListInstancesRequest()
            {
                CompartmentId = compartment.Id
            };
            var getInstansTask = await computeClientAsync.ListInstances(listInstancesRequest);
            foreach (var instance in getInstansTask.Items)
            {
                Console.WriteLine($"loaded Instance: {instance.DisplayName} - compartment:{compartment.Name}");
            }
        }

        private static async Task LoadVcn(Compartment compartment, IVirtualNetworkClientAsync virtualNetworkClientAsync)
        {
            var listVcnRequest = new ListVcnRequest()
            {
                CompartmentId = compartment.Id
            };
            var getVcnTask = await virtualNetworkClientAsync.ListVcn(listVcnRequest);
            foreach (var vcn in getVcnTask.Items)
            {
                Console.WriteLine($"loaded Vcn: {vcn.DisplayName} - compartment:{compartment.Name}");
            }
        }

        // OCID input check
        private static string OCIDInput()
        {
            var count = 0;
            var readStr = "";
            while (count < 3)
            {
                readStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(readStr))
                {
                    if (OCID.IsValid(readStr))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{readStr} is not a valid OCID");
                    }
                }
                else
                {
                    Console.WriteLine("this parameter is Required!");
                }
                ++count;
            }

            if (string.IsNullOrEmpty(readStr))
            {
                throw new Exception("Required parameter is unknown");
            }

            return readStr;
        }

        // input check
        private static string KeyInput()
        {
            var count = 0;
            var readStr = "";
            while (count < 3)
            {
                readStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(readStr))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("this parameter is Required!");
                }
                ++count;
            }

            if (string.IsNullOrEmpty(readStr))
            {
                throw new Exception("Required parameter is unknown");
            }

            return readStr;
        }

        public static string InputPassword()
        {
            var pass = new StringBuilder();

            while (true)
            {
                var keyinfo = Console.ReadKey(true);

                switch (keyinfo.Key)
                {
                    case ConsoleKey.Enter:
                        Console.WriteLine();
                        return pass.ToString();

                    case ConsoleKey.Backspace:
                        if (1 <= pass.Length)
                        {
                            pass.Length -= 1;
                        }
                        else
                        {
                            Console.Beep();
                        }
                        break;

                    default:
                        if (Char.IsLetter(keyinfo.KeyChar))
                        {
                            if ((keyinfo.Modifiers & ConsoleModifiers.Shift) == 0)
                            {
                                pass.Append(keyinfo.KeyChar);
                            }
                            else
                            {
                                // Shift press...
                                pass.Append(Char.ToUpper(keyinfo.KeyChar));
                            }
                        }
                        else if (!Char.IsControl(keyinfo.KeyChar))
                        {
                            pass.Append(keyinfo.KeyChar);
                        }
                        else
                        {
                            // ather key to beep
                            Console.Beep();
                        }
                        break;
                }
            }
        }
    }
}
