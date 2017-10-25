using System.Collections.Generic;
using System.Web.Http;

namespace ClientManagerTray.Controllers
{
    public class TestController : ApiController
    {

        public IEnumerable<string> Get()
        {
            Program.ShowTrayMessage("Api Works!  This a Test For A Very Long Message \r\n For the notification in the tray icon and Now \r\n it's even longer than it was before");
            return new string[] { "Test1", "Test2" };
        }

        public string Get(int id)
        {
            return "Test";
        } 
    }
}
