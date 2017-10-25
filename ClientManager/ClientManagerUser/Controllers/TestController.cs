using System.Collections.Generic;
using System.Web.Http;
using System.Windows.Forms;

namespace ClientManagerUser.Controllers
{
    public class TestController : ApiController
    {

        public IEnumerable<string> Get()
        {
            Program.ShowTrayMessage("Api Called");
            return new string[] { "Test1", "Test2" };
        }

        public string Get(int id)
        {
            return "Test";
        } 
    }
}
