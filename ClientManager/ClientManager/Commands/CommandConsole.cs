using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClientManager.ServiceHost;

namespace ClientManager.Commands
{
    public class CommandConsole : ICommand
    {
        public void Run()
        {
            var serviceHost = new Host();
            serviceHost.ManualStart();
            Console.WriteLine();
            Console.WriteLine("Client Management Running");
            Console.WriteLine("Press [Enter] to Exit.");
            Console.Read();
            serviceHost.ManualStop();
        }
    }
}
