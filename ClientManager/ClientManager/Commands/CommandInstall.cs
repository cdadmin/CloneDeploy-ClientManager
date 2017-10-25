using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ClientManager.Commands
{
    class CommandInstall : ICommand
    {
        public void Run()
        {
            if (!HasAdministrativeRight())
            {
                Console.WriteLine("Administrative Privileges Required To Install Service");
            }
            else
            {
                Console.WriteLine("Installing Client Management");
                try
                {
                    System.Configuration.Install.AssemblyInstaller Installer = new System.Configuration.Install.AssemblyInstaller(Assembly.GetExecutingAssembly(), new string[] { });
                    Installer.UseNewContext = true;
                    Installer.Install(null);
                    Installer.Commit(null);
                    Console.WriteLine();
                    Console.WriteLine("Successfully Installed Client Management");
                    Console.WriteLine("The Service Must Manually Be Started");
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Could Not Install Client Management");
                    Console.WriteLine(ex.Message);
                }
            }


        }

        public static bool HasAdministrativeRight()
        {
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
