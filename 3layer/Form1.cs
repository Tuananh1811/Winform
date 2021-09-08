using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3layer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataProcessing data = new DataProcessing();
        private void Form1_Load(object sender, EventArgs e)
        {
         
            DataTable dataTable = new DataTable();
            dataTable = data.ShowDB();
            dgvQLS.DataSource = dataTable;
            DataTable dataCombobox = new DataTable();
            dataCombobox = data.LoadComboBox();
            cbLoaiSach.DataSource = dataCombobox;
            cbLoaiSach.DisplayMember = "CategoryName";
            cbLoaiSach.ValueMember = "CategoryID";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
         
            DataTable dataTable = new DataTable();
            string ms = txtMaSach.Text;
            string td = txtTitle.Text;
           
            int gia =int.Parse( txtGia.Text);
            int soluong =int.Parse( txtSoLuong.Text);
                if (gia < 0 || soluong < 0)
                {
                    MessageBox.Show("Mày bị ngu à");
                }

                string ls = cbLoaiSach.SelectedValue.ToString();
            data.InsertSACH(ms, td, gia, soluong.ToString(), ls);
            Form1_Load(sender, e);

            }catch(Exception ex)
            {
                if(ex.Message.Contains("duplicate key"))
                {
                    MessageBox.Show("trùng mã sách", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
    }
}
