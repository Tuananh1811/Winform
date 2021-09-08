using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ConnectSQL
{
    public partial class Form1 : Form
    {
        String connString = @"Data Source=DESKTOP-OSNAEE6\SQLEXPRESS;Initial Catalog=DBSinhVien;Integrated Security=True";
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connString);
                 conn.Open();
                 String sql = "Select * From SinhVien";
                 SqlCommand command = new SqlCommand(sql, conn);
                 SqlDataReader reader = command.ExecuteReader();
                 DataTable table = new DataTable();
                 dataGridView1.DataSource = table;
                 table.Load(reader);
                 conn.Close();
              

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
