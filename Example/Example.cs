using OCISDK.Core.src;
using OCISDK.Core.src.Common;
using System;
using System.IO;
using System.Text;
using static OCISDK.Core.src.Common.ConfigFileReader;

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
                configPath = $"~/{configPath}";
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
                PrivateKeyPath = configReader.Get("key_file"),
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
                Console.WriteLine("[5]: Display BootVolume List Example");
                Console.WriteLine("[6]: Display Audit List Example");
                Console.WriteLine("[ESC] or [E(e)] : Exit Example");
                Console.WriteLine("");

                int mode = 0;
                var presskey = Console.ReadKey(true);
                if (presskey.Key == ConsoleKey.Escape || presskey.KeyChar == 'E' || presskey.KeyChar == 'e')
                {
                    Console.WriteLine("Exit....");
                    return;
                }
                var select = presskey.KeyChar;
                if (!int.TryParse(select.ToString(), out mode))
                {
                    Console.WriteLine("Incorrect input...");
                    continue;
                }
                if (mode <= 0 || mode > 6)
                {
                    Console.WriteLine("Incorrect input...");
                    continue;
                }

                // Indentity
                // Compartment
                if (mode == 1 || mode == 2)
                {
                    IndentityCompartmentExample.CompartmentConsoleDisplay(config);
                }

                // Core
                // VirtualNetworks
                if (mode == 1 || mode == 3)
                {
                    CoreVirtualNetworkExample.VirtualNetworkExample(config);
                }

                // Instances
                if (mode == 1 || mode == 4)
                {
                    CoreInstanceExample.InstanceConsoleDisplay(config);
                }

                // BlockStorage
                // BootVolumes
                if (mode == 1 || mode == 5)
                {
                    BlockStorageExample.BootVolumeConsoleDisplay(config);
                }

                // Audit
                if (mode == 1 || mode == 6)
                {
                    AuditExample.AuditDisplay(config);
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
