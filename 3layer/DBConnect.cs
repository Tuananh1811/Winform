using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _3layer
{
    class DBConnect
    {
        public SqlConnection GetSqlConnection()
        {
            string connString = @"Data Source=DESKTOP-OSNAEE6\SQLEXPRESS;Initial Catalog=BT1_27;Integrated Security=True";

            return new SqlConnection(connString);
        }
        public DataTable GetDataTable(string sql)
        {
            SqlConnection sqlConnection = GetSqlConnection();
            DataTable dataTable = new DataTable();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, sqlConnection);
            SDA.Fill(dataTable);
            return dataTable;
        }
        public void getExecuteNonQuery(string sql)
        {
            SqlConnection conn = GetSqlConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
