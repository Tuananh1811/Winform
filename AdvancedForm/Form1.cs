using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AdvancedForm
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void pageSetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void restoreZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void mnuFNew_Click(object sender, EventArgs e)
        {
            ChilForm frm = new ChilForm();
            frm.MdiParent = this;
            
            frm.Show();
        }
        private void tsNew_Click(object sender, EventArgs e)
        {
            mnuFNew_Click(sender, e);

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form activeForm = this.ActiveMdiChild;
            //openDlg.Title = "Open File";
            //openDlg.Filter = "Text File| *.txt|(All Files)| *.*";

            //if (openDlg.ShowDialog() == DialogResult.OK)
            //{
            //    StreamReader reader = new StreamReader(openDlg.FileName);
            //    if (activeForm != null)
            //    {
            //        RichTextBox richTextBox = (RichTextBox)activeForm.ActiveControl;
            //        if (richTextBox != null)
            //        {
            //            richTextBox.Text = reader.ReadToEnd();

            //        }
            //    }
            //    reader.Close();
            //}
            //khai báo form con
            ChilForm frm = new ChilForm();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openDlg.FileName);
                frm.richTextBox1.Text = reader.ReadToEnd();
                frm.MdiParent = this;
                frm.Text = openDlg.SafeFileName;
                frm.Show();
                reader.Close();
            }
        
        }

        private void tsOpen_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeForm = this.ActiveMdiChild;
            if (activeForm != null)
            {
                activeForm.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           


        }
    }
}
