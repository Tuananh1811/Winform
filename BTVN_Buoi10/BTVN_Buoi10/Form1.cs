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

namespace BTVN_Buoi10
{
    public partial class Form1 : Form
    {
        string conString = @"Data Source=DESKTOP-OSNAEE6\SQLEXPRESS;Initial Catalog=DBSinhVien_15;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }
        public void loadCombobox()
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    conn.Open();
                    string sql = "select *from Tinh";
                    SqlDataAdapter dt = new SqlDataAdapter(sql, conn);
                    DataTable table = new DataTable();
                    dt.Fill(table);
                    cbbMaTinh.DataSource = table;
                    cbbMaTinh.DisplayMember = "MaTinh";
                    cbbMaTinh.ValueMember = "TenTinh";
                   

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void loadCombobox1()
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    conn.Open();
                    string sql = "select *from LopHocPhan";
                    SqlDataAdapter dt = new SqlDataAdapter(sql, conn);
                    DataTable table = new DataTable();
                    dt.Fill(table);
                    cbbMaLop.DataSource = table;
                    cbbMaLop.DisplayMember = "MaLop";
                    cbbMaLop.ValueMember = "TenHocPhan";
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    conn.Open();
                    string sql = "select SinhVien.MaSV,HoTen,NgaySinh,GioiTinh,Tinh.TenTinh,SoDT from SinhVien inner join Tinh on Tinh.MaTinh = SinhVien.MaTinh";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable table = new DataTable();
                    dgvSinhVien.DataSource = table;
                    table.Load(reader);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            loadCombobox();
            loadCombobox1();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    conn.Open();
                    Boolean gt = false;
                    if (radioButton1.Checked)
                        gt = true;
                    else
                        gt = false;
                  
                    string sql = "Insert into SinhVien values(@MaSV,@HoTen,@NgaySinh,@GioiTinh,@MaTinh,@SoDT)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgayS.Value.ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@GioiTinh", gt);
                    cmd.Parameters.AddWithValue("@MaTinh", cbbMaTinh.Text);
                    cmd.Parameters.AddWithValue("@SoDT", txtSDT.Text);
                    cmd.ExecuteNonQuery();
                    Form1_Load(sender, e);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("duplicate key"))
                        MessageBox.Show("Mã sinh viên bị trùng", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMaTinh_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();
                string sql = "MaTinh";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaTinh", cbbMaTinh.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                dgvSinhVien.DataSource = table;
               if(table.Rows.Count == 0){
                    MessageBox.Show("Không tìm thấy", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnMaLop_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                
                conn.Open();
                string sql = "MaLop";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaLop", cbbMaLop.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                dgvSinhVien.DataSource = table;
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

       

        private void dgvSinhVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtMaSV.Text = dgvSinhVien.Rows[dong].Cells[0].Value.ToString();
            txtHoTen.Text = dgvSinhVien.Rows[dong].Cells[1].Value.ToString();
            txtSDT.Text = dgvSinhVien.Rows[dong].Cells[5].Value.ToString();
            dtpNgayS.Text = dgvSinhVien.Rows[dong].Cells[2].Value.ToString();
            
           
        }

        private void btnTinhLop_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {

                conn.Open();
                string sql = "Tinh_MA";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaLop", cbbMaLop.Text);
                cmd.Parameters.AddWithValue("@MaTinh", cbbMaTinh.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                dgvSinhVien.DataSource = table;
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy mã và tỉnh", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
