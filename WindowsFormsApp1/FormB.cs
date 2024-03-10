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
    public partial class FormB : Form
    {
        private IChuyenDuLieu _ichuyenDuLieu;
        public FormB()
        {
            InitializeComponent();
        }

        public FormB(IChuyenDuLieu ichuyenDuLieu)
        {
            InitializeComponent( );
            this._ichuyenDuLieu = ichuyenDuLieu;
        }
        public FormB(string value)
        {
            InitializeComponent();
            tb_nhandulieutuFormA.Text = value;  
        }

        private void FormB_Load(object sender, EventArgs e)
        {

        }

        private void btn_chuyenFormA_Click(object sender, EventArgs e)
        {
            _ichuyenDuLieu.XyLyDuLieu(tb_guidulieusangFormA.Text);
            this.Close();
        }

        private void tb_guidulieusangFormA_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                _ichuyenDuLieu.XyLyDuLieu(tb_guidulieusangFormA.Text);
                this.Close();
            }
        }
    }
}
