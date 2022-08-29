using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LinkGroupDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB; Initial Catalog=test;Integrated Security=SSPI");
            conn.Open();
            //SqlCommand cmd = new SqlCommand("insert into Employee values(2,'Ramm',33)", conn);
            //cmd.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand("select * from Employee", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("ID -> "+reader.GetInt32(0)+" Name -> "+ reader.GetString(1)+" Age -> "+reader.GetInt32(0));
            }
            conn.Close();
        }

    }
}
