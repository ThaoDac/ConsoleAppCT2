﻿using System;
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
    public partial class Form3 : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();  
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            btn_them.Enabled = false;
            tb_hoten.Focus();   
        }

        private void tb_hoten_TextChanged(object sender, EventArgs e)
        {
            if(this.tb_hoten.Text.Length > 0)
            {
                btn_them.Enabled = true;
            }
            else 
            { 
                btn_them.Enabled = false; 
            }
        }

        private void tb_hoten_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tb_hoten.Text))
            {
                //e.Cancel = true;
                errorProvider.SetError(tb_hoten, "Họ tên sinh viên không được để trống");
            }
            else
            {
                //e.Cancel = false;
                errorProvider.SetError(tb_hoten, null);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            tb_hoten.Focus();
        }

        private void Form3_Move(object sender, EventArgs e)
        {
            tb_hoten.Focus();
        }
    }
}