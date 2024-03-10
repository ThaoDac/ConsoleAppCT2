using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormA : Form, IChuyenDuLieu
    {
        public FormA()
        {
            InitializeComponent();
        }

        public void XyLyDuLieu(string value)
        {
            if(value != null)
            {
                tb_nhandulieutuFormB.Text = value;
            }
            else
            {
                tb_nhandulieutuFormB = null;
            }
        }

        private void btn_chuyenFormB_Click(object sender, EventArgs e)
        {
            //FormB formB= new FormB(tb_dulieuguiFormB.Text);
            FormB formB = new FormB(this);
            formB.Show();
        }
    }
}
