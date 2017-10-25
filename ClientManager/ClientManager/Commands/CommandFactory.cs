using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientManager.Commands
{
    public class CommandFactory
    {
        public static ICommand GetCommand(string[] args)
        {

            if (args == null || args.Length == 0)
                return new CommandService();

            string str = args[0];
            switch (str)
            {
                case "version":
                    return new CommandVersion();
                    break;
                case "install":
                    return new CommandInstall();
                    break;
                case "console":
                    return new CommandConsole();
                    break;
                default:
                    return null;
                    break;
            }


        }
    }
}
