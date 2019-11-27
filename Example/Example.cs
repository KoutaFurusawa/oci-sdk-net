using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Search;
using OCISDK.Core.Search.Request;
using System;
using System.IO;
using System.Text;
using static OCISDK.Core.Common.ConfigFileReader;

namespace Example
{
    class Example
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+----------------------------------------+");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|             OCISDK Example             |");
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
            var config = new ClientConfig
            {
                TenancyId = configReader.Get("tenancy"),
                UserId = configReader.Get("user"),
                Fingerprint = configReader.Get("fingerprint"),
                PrivateKey = configReader.Get("key_file"),
                PrivateKeyPassphrase = configReader.Get("pass_phrase")
            };

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Mode Selection....");
                Console.WriteLine("[1]: All Example run");
                Console.WriteLine("[2]: Display TenatcyInfomation and Compartment Example");
                Console.WriteLine("[3]: Display VirtualNetwork List Example");
                Console.WriteLine("[4]: Display Instance List Example");
                Console.WriteLine("[5]: Display BlockStorage List Example");
                Console.WriteLine("[6]: Display Audit List Example");
                Console.WriteLine("[7]: Display ObjectStorage List Example");
                Console.WriteLine("[8]: SearchResouces Example");
                Console.WriteLine("[9]: Monitoring Example");
                Console.WriteLine("[a]: Database Example");
                Console.WriteLine("[b]: DNS Example");
                Console.WriteLine("[c]: LoadBalancer Example");
                Console.WriteLine("[d]: Users Example");
                Console.WriteLine("[ESC]: Exit Example");
                Console.WriteLine("");

                var presskey = Console.ReadKey(true);
                if (presskey.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Exit....");
                    return;
                }
                var mode = presskey.KeyChar;

                // Indentity
                // Compartment
                if (mode == '1' || mode == '2')
                {
                    IdentityCompartmentExample.CompartmentConsoleDisplay(config);
                }

                // Core
                // VirtualNetworks
                if (mode == '1' || mode == '3')
                {
                    CoreVirtualNetworkExample.VirtualNetworkExample(config);
                }

                // Instances
                if (mode == '1' || mode == '4')
                {
                    CoreInstanceExample.InstanceConsoleDisplay(config);
                }

                // BlockStorage
                // BootVolumes
                if (mode == '1' || mode == '5')
                {
                    BlockStorageExample.BlockStoragesConsoleDisplay(config);
                }

                // Audit
                if (mode == '1' || mode == '6')
                {
                    AuditExample.AuditDisplay(config);
                }

                // ObjectStorage
                if (mode == '1' || mode == '7')
                {
                    ObjectStorageExample.DisplayObjectStorage(config);
                }

                // search
                if (mode == '1' || mode == '8')
                {
                    SearchExample.SearchResourcesExample(config);
                }

                // monitoring
                if (mode == '1' || mode == '9')
                {
                    MonitoringExample.MonitoringResourceExample(config);
                }

                //database
                if (mode == '1' || mode == 'a')
                {
                    DatabaseExample.DatabaseConsoleDisplay(config);
                }

                //dns
                if (mode == '1' || mode == 'b')
                {
                    DNSExample.DNSConsoleDisplay(config);
                }

                //loadbalancer
                if (mode == '1' || mode == 'c')
                {
                    LoadBalancerExample.ConsoleDisplay(config);
                }

                //users
                if (mode == '1' || mode == 'd')
                {
                    IdentityUsersExample.ConsoleDisplay(config);
                }
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
                } else
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
