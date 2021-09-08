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

namespace DoTuanAnh224
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
     
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DataProcessing data = new DataProcessing();
                DataTable dataTable = new DataTable();
            dataTable = data.ShowInfor();
            dgvKH.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtCMND.Text == "" || txtSoP.Text == "")
                {
                    MessageBox.Show("Không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (int.Parse(txtSoP.Text) < 0)
                {
                    MessageBox.Show("Không nhập nhỏ hơn 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DataProcessing data = new DataProcessing();
                DataTable dataTable = new DataTable();
                string makh = txtMaKH.Text;
                string tenkh = txtTenKH.Text;
                Boolean gt = false;
                if (cbNu.Checked)
                {
                    gt = true;
                }
                else
                {
                    gt = false;
                }
                string cmnd = txtCMND.Text;
                int sophong = int.Parse(txtSoP.Text);
                string ngaycheckin = dtpCheckIn.Value.ToString("yyyy");
                data.InsertKH(makh, tenkh, gt, cmnd, sophong, ngaycheckin);
                Form1_Load(sender, e);
                txtMaKH.Text = "";
                txtCMND.Text = "";
                txtTenKH.Text = "";
                txtSoP.Text = "";
                cbNu.Checked = false;
            }



            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate key"))
                {
                    MessageBox.Show("Bị trùng khóa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataProcessing data = new DataProcessing();
            DataTable dataTable = new DataTable();
            try
            {
                if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtCMND.Text == "" || txtSoP.Text == "")
                {
                    MessageBox.Show("Không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (int.Parse(txtSoP.Text) < 0)
                {
                    MessageBox.Show("Không nhập nhỏ hơn 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                string makh = txtMaKH.Text;
                string tenkh = txtTenKH.Text;
                Boolean gt = false;
                if (cbNu.Checked)
                {
                    gt = true;
                }
                else
                {
                    gt = false;
                }
                string cmnd = txtCMND.Text;
                int sophong = int.Parse(txtSoP.Text);
                string ngaycheckin = dtpCheckIn.Value.ToString("yyyy");
                data.Update(makh, tenkh, gt, cmnd, sophong, ngaycheckin);
                Form1_Load(sender, e);
                txtMaKH.Text = "";
                txtCMND.Text = "";
                txtTenKH.Text = "";
                txtSoP.Text = "";
                cbNu.Checked = false;
            }



            catch (Exception ex)
            {
               

               
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaKH.Text = dgvKH.Rows[row].Cells[0].Value.ToString();
                txtTenKH.Text = dgvKH.Rows[row].Cells[1].Value.ToString();
                if (dgvKH.Rows[row].Cells[2].Value.Equals(true))
                {
                    cbNu.Checked = true;
                }
                else
                {
                    cbNu.Checked = false;
                }
                txtCMND.Text = dgvKH.Rows[row].Cells[3].Value.ToString();
                txtSoP.Text = dgvKH.Rows[row].Cells[4].Value.ToString();
                dtpCheckIn.Text = dgvKH.Rows[row].Cells[5].Value.ToString();
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataProcessing data = new DataProcessing();
            DataTable dataTable = new DataTable();
            try
            {
                string ma = txtMaKH.Text;
                DialogResult dialog = MessageBox.Show("Bạn chắc muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {

                    data.DELETE(ma);
                    Form1_Load(sender, e);
                }
                txtMaKH.Text = "";
                txtCMND.Text = "";
                txtTenKH.Text = "";
                txtSoP.Text = "";
                cbNu.Checked = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
