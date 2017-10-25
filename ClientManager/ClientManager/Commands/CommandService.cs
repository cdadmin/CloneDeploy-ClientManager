using System.ServiceProcess;

namespace ClientManager.Commands
{
    public class CommandService : ICommand
    {
        public void Run()
        {
            ServiceBase.Run(new ServiceHost.Host());       
        }
    }
}
