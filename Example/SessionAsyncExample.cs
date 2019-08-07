﻿using OCISDK.Core.src;
using OCISDK.Core.src.Common;
using OCISDK.Core.src.Core.Request.Compute;
using OCISDK.Core.src.Core.Request.WorkRequest;
using OCISDK.Core.src.Identity;
using OCISDK.Core.src.Identity.Request;
using OCISDK.Core.src.Identity.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static OCISDK.Core.src.Common.ConfigFileReader;

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
                CompartmentIdInSubtree = false
            };
            var compartments = await identityClientAsync.ListCompartment(listCompartmentRequest);

            // loop get compartments async
            var tasks = new List<Task<GetCompartmentResponse>>();
            foreach (var com in compartments.Items)
            {
                if (com.LifecycleState != "ACTIVE") {
                    continue;
                }
                var getCompartmentRequest = new GetCompartmentRequest()
                {
                    CompartmentId = com.Id
                };

                var task = identityClientAsync.GetCompartment(getCompartmentRequest);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

            var computeClientAsync = session.GetComputeClientAsync();

            // display compartment
            foreach (var task in tasks)
            {
                Console.WriteLine($"compartmentName: {task.Result.Compartment.Name}");

                ListInstancesRequest listInstancesRequest = new ListInstancesRequest() {
                    CompartmentId = task.Result.Compartment.Id
                };
                var instances = await computeClientAsync.ListInstances(listInstancesRequest);
                foreach (var ins in instances.Items)
                {
                    Console.WriteLine($"/tInstance: {ins.DisplayName}");
                }
            }

            
            Console.WriteLine("Exit with key press...");
            Console.ReadLine();
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
