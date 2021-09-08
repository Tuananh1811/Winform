using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mucdichSD = "";
            double SUM = 0;
            try
            {
                if(txtMa.Text==""||txtHoTen.Text==""||txtTuoi.Text==""||chbMat.Checked==false&&cbChamSocDa.Checked==false&&cbMoBung.Checked==false&& cbNams.Checked==false
                    ||double.Parse(txtSoBuoi.Text) < 0 || txtSoBuoi.Text == "")
                {
                    throw new Exception(" không được bỏ trống!");
                }
                if(int.Parse(txtTuoi.Text) < 0)
                {
                    throw new Exception("Tuổi không thể nhỏ hơn 0");
                }
                
             
                if (cbChamSocDa.Checked)
                {
                    mucdichSD += cbChamSocDa.Text + ", ";

                }
                if (chbMat.Checked)
                {
                    mucdichSD += chbMat.Text + ", ";
                }
                if (cbMoBung.Checked)
                {
                    mucdichSD += cbMoBung.Text + ", ";
                }
                if (cbNams.Checked)
                {
                    mucdichSD += cbNams.Text + ", ";
                }

                string gioitinh = "";
                if (rdbNam.Checked)
                {
                    gioitinh = "Nam";
                }
                if (rdbNu.Checked)
                {
                    gioitinh = "Nữ";
                }
                KHACHHANG kh = new KHACHHANG(txtMa.Text, txtHoTen.Text, gioitinh, int.Parse(txtTuoi.Text), mucdichSD, dtpNgayBD.Value.ToString(), double.Parse(txtSoBuoi.Text));
                int i = listView1.Items.Count;
                listView1.Items.Add(kh.Xuat()[0]);
                listView1.Items[i].SubItems.Add(kh.Xuat()[1]);
                listView1.Items[i].SubItems.Add(kh.Xuat()[2]);
                listView1.Items[i].SubItems.Add(kh.Xuat()[3]);
                listView1.Items[i].SubItems.Add(kh.Xuat()[4]);
                listView1.Items[i].SubItems.Add(kh.Xuat()[5]);

                if (cbChamSocDa.Checked)
                {
                    SUM += kh.tongtien(cbChamSocDa.Text);
                }
                if (chbMat.Checked)
                {
                    SUM += kh.tongtien(chbMat.Text);
                }
                if (cbMoBung.Checked)
                {
                    SUM += kh.tongtien(cbMoBung.Text);
                }
                if (cbNams.Checked)
                {
                  SUM += kh.tongtien(cbNams.Text);
                }

                listView1.Items[i].SubItems.Add(SUM.ToString());
                txtMa.Clear();
                txtHoTen.Clear();
                txtTuoi.Clear();
                cbChamSocDa.Checked = false;
                cbMoBung.Checked = false;
                cbNams.Checked = false;
                chbMat.Checked = false;
                txtSoBuoi.Clear();

            }
            catch (FormatException FE)
            {
                MessageBox.Show(FE.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
            
            
        }

        int d;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            listView1.Items.RemoveAt(d);
        }


        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            d = e.ItemIndex;
            txtMa.Text = listView1.Items[d].SubItems[0].Text;
            txtHoTen.Text = listView1.Items[d].SubItems[1].Text;
            if (listView1.Items[d].SubItems[2].Text == "Nam")
            {
                rdbNam.Checked = true;
            }
            if (listView1.Items[d].SubItems[2].Text == "Nữ")
            {
                rdbNam.Checked = true;
            }

            txtTuoi.Text = listView1.Items[d].SubItems[3].Text;
            String[] arr = listView1.Items[d].SubItems[4].Text.Split(',');
            for (int a = 0; a < arr.Length; a++) //chỗ này em mới lấy được 1 checkbox 
            {
                if (arr[a] == cbChamSocDa.Text)
                {
                    cbChamSocDa.Checked = true;
                }
               if (arr[a] == chbMat.Text)
                {
                    chbMat.Checked = true;
                }
                 if (arr[a] == cbMoBung.Text)
                {
                    cbMoBung.Checked = true;
                }
                if (arr[a] == cbNams.Text)
                {
                    cbNams.Checked = true;
                }
            }


            dtpNgayBD.Text = listView1.Items[d].SubItems[5].Text;

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
