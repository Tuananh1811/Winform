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

namespace BT_27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string ConString = @"Data Source=DESKTOP-OSNAEE6\SQLEXPRESS;Initial Catalog=BT1_27;Integrated Security=True";
        public void loadCombobox()
        {
            using(SqlConnection conn=new SqlConnection(ConString))
            {
                conn.Open();
                string sql = "select *from Category";
                SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
                DataTable dataTable = new DataTable();
                SDA.Fill(dataTable);
                cbLoaiSach.DataSource = dataTable;
                cbLoaiSach.DisplayMember = "CategoryName";
                cbLoaiSach.ValueMember = "CategoryID";

            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadCombobox();
            using(SqlConnection conn=new SqlConnection(ConString))
            {
                conn.Open();
                string sql = "select Product.ProductCode,Product.DescriptionPro,Product.UnitPrice,Product.OnhandQuantity,Category.CategoryName" +
                    " from Product inner join Category on Product.CategoryID = Category.CategoryID";
                SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
                DataTable dataTable = new DataTable();
                SDA.Fill(dataTable);
                dgvPro.DataSource = dataTable;

            }
        }

        private void cbLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using(SqlConnection conn=new SqlConnection(ConString))
            {
                try
                {

                conn.Open();

               
                string sql = "insert into Product values(@ProductCode,@DescriptionPro,@UnitPrice,@OnhandQuantity,@CategoryID)";
                SqlCommand command = new SqlCommand(sql, conn);
                    if (txtMaSach.Text == "")
                    {
                        MessageBox.Show("Không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                  //  if(cbLoaiSach.Text==cbLoaiSach.ValueMember.)
                command.Parameters.AddWithValue("@ProductCode", txtMaSach.Text);
                command.Parameters.AddWithValue("@DescriptionPro", txtTitleSach.Text);
                command.Parameters.AddWithValue("@UnitPrice", txtGia.Text);
                command.Parameters.AddWithValue("@OnhandQuantity", txtSoLuong.Text);
                   
                command.Parameters.AddWithValue("@CategoryID",cbLoaiSach.SelectedValue.ToString());
                command.ExecuteNonQuery();
                Form1_Load(sender, e);
                }
                catch(Exception ex)
                {
                    if (ex.Message.Contains("duplicate key"))
                        MessageBox.Show("Mã sản phẩm bị trùng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn=new SqlConnection(ConString))
            {
                try
                {
                conn.Open();
                String sql = "DELETE Product where ProductCode=@msp";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@msp", txtMaSach.Text);
                command.ExecuteNonQuery();
                Form1_Load(sender, e);

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            using(SqlConnection conn=new SqlConnection(ConString))
            {
                try
                {

                conn.Open();
                string sql = "UPDATE Product SET ProductCode=@maSP,DescriptionPro=@mota,UnitPrice=@gia,OnhandQuantity=@soluong,Product.CategoryID=@ma where ProductCode=@maSP";
                SqlCommand command = new SqlCommand(sql, conn);
                if (txtMaSach.Text == "")
                {
                    MessageBox.Show("Không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                command.Parameters.AddWithValue("@maSP", txtMaSach.Text);
                command.Parameters.AddWithValue("@mota", txtTitleSach.Text);
                command.Parameters.AddWithValue("@gia", txtGia.Text);
                command.Parameters.AddWithValue("@soluong", txtSoLuong.Text);

                command.Parameters.AddWithValue("@ma", cbLoaiSach.SelectedValue.ToString());
                command.ExecuteNonQuery();
                Form1_Load(sender, e);
                }
                catch(Exception ex)
                {
                    if (ex.Message.Contains("duplicate key"))
                        MessageBox.Show("Mã sản phẩm bị trùng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaSach.Text = dgvPro.Rows[row].Cells[0].Value.ToString();
                txtTitleSach.Text= dgvPro.Rows[row].Cells[1].Value.ToString();
                txtGia.Text = dgvPro.Rows[row].Cells[2].Value.ToString();
                txtSoLuong.Text = dgvPro.Rows[row].Cells[3].Value.ToString();
                cbLoaiSach.Text = dgvPro.Rows[row].Cells[4].Value.ToString();
            }
        }
    }
}
