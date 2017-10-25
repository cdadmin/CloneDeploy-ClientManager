using ClientManager.Commands;

namespace ClientManager
{
    class Program
    {
       
        static void Main(string[] args)
        {
            CommandFactory.GetCommand(args).Run();
        }
    }
}
