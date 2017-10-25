using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientManager.Commands
{
    public class CommandVersion : ICommand
    {
        public void Run()
        {
            Console.WriteLine("Version Information");
        }
    }
}
