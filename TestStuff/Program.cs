using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectStr = "Server=PAIN;Database=UserFilesDB;Trusted_Connection=True;";
            SqlConnection connect = new SqlConnection(connectStr);
            connect.Open();
        }
    }
}
