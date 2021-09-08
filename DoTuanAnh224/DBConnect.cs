using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DoTuanAnh224
{
    class DBConnect
    {
        public SqlConnection GetSqlConnection()
        {
            String connString = @"Data Source=DESKTOP-OSNAEE6\SQLEXPRESS;Initial Catalog=DoTuanAnh;Integrated Security=True";
            return new SqlConnection(connString);
        }
        public DataTable GetDataTable(String sql)
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn =GetSqlConnection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public void ExecutenonQuery(String sql)
        {
            SqlConnection conn = GetSqlConnection();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.ExecuteNonQuery();
            conn.Close();

        }

    }
}
