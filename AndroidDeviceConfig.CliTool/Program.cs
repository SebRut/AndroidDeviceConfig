using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidDeviceConfig.CliTool
{
    class Program
    {
        private static void Main(string[] args)
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine("1. Add Device Version");
            menu.AppendLine("2. Save");
            menu.AppendLine("3. Exit");
            
            DeviceConfig config = new DeviceConfig();

            config.Name = TextInput("Device Name?");
            config.Vendor = TextInput("Vendor?");


            bool run = true;
            while (run)
            {
                Console.WriteLine(menu.ToString());
                switch (Console.ReadLine())
                {
                    case "1":
                        config.Versions.Add(AddVersionLoop());
                        break;
                    case "2":
                        DeviceConfig.SaveConfig((config.Vendor + config.Name).Replace(" ", "") + ".xml", config);
                        run = false;
                        break;
                    case "3":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("unrecognized option");
                        break;
                }
            }
        }

        private static DeviceVersion AddVersionLoop()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine("1. Add identifier");
            menu.AppendLine("2. Add recovery");
            menu.AppendLine("3. Add ActionSet");
            menu.AppendLine("4. end");
            DeviceVersion version = new DeviceVersion();
            bool run = true;
            while (run)
            {
                
                Console.WriteLine(menu.ToString());
                switch (Console.ReadLine())
                {
                    case "1":
                        DeviceIdentifier ident = new DeviceIdentifier();
                        ident.Type = (IdentifierType) Enum.Parse(typeof(IdentifierType), TextInput("identifier?"));
                        ident.AdditionalArgs = MultiLineTextInput("Additional Args seperated by ,");
                        version.Identifiers.Add(ident);
                        break;
                    case "2":
                        Recovery rec = new Recovery();
                        rec.Name = TextInput("Recovery name?");
                        rec.DownloadUrl = TextInput("Download url?");
                        version.Recoveries.Add(rec);
                        break;
                    case "3":
                        version.PossibleActions.Add(AddActionLoop());
                        break;
                    case "4":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("unrecognized option");
                        break;
                }
                
            }
            return version;
        }

        private static ActionSet AddActionLoop()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine("1. Add Action");
            menu.AppendLine("2. Exit");

            ActionSet set = new ActionSet();

            set.Description = TextInput("Description?");

            bool run = true;
            while (run)
            {
                Console.WriteLine(menu.ToString());
                switch (Console.ReadLine())
                {
                    case "1":
                        Action action = new Action();
                        action.Type = (ActionType) Enum.Parse(typeof(ActionType), TextInput("action type?"));
                        action.AdditionalInfos = MultiLineTextInput("additional args, seperated by ,");
                        break;
                    case "2":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("unrecognized option");
                        break;
                }
            }
            return set;
        }

        private static List<string> MultiLineTextInput(string text)
        {
            return new List<string>(TextInput(text).Split(','));
        }

        private static string TextInput(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }
    }
}
