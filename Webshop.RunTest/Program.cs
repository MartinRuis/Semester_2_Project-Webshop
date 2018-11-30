using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL;

namespace Webshop.RunTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            AccountContext ac = new AccountContext();
            ac.Create("Test", "Test", "T.", "Test@Test.com", "Teststraat 1", "test");
            //ac.Delete(2);
        }
    }
}
