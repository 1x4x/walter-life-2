using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCreater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = DatabaseCreater.Manager.UserManager.GetUserList();
            foreach (var item in list) {
                Console.WriteLine(item.username + "\r\n");
            }


        }
    }
}
