using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WcfDataProviderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerStatusClient.ServerStatusClient serverStatusClient = new ServerStatusClient.ServerStatusClient();
            DataTable dataTable = serverStatusClient.GetServerStatusDetails();

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row.ItemArray.GetValue(0) + " - " + row.ItemArray.GetValue(1) + " - " + row.ItemArray.GetValue(2));
            }
            Console.ReadLine();
        }
    }
}
