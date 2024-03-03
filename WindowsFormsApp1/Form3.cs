using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        private string connectionString =
            ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;
        private bool gioiTinh;

        private DataTable dtSINHVIEN = new DataTable();
        private DataView dvSINHVIEN = new DataView();


        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            btn_them.Enabled = false;
            LoadDataToGridView();
        }

        private void LoadDataToGridView()
        {
            string queryStr = "SELECT_tblSINHVIEN";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = queryStr;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dtSINHVIEN);
                        if (dtSINHVIEN.Rows.Count > 0)
                        {
                            dvSINHVIEN = dtSINHVIEN.DefaultView;
                            dgv_dssv.AutoGenerateColumns = false;
                            dgv_dssv.DataSource = dvSINHVIEN;
                        }
                        else
                        {
                            MessageBox.Show("Khong co ban ghi nao ton tai");
                        }

                    }
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (rb_nam.Checked == true)
            {
                gioiTinh = true;
            }
            else if (rb_nu.Checked == true)
            {
                gioiTinh = false;
            }

            //thuc hien phuong thuc kiem tra su ton tai cua khoa chinh
            string idsv = tb_mssv.Text;

            //Thuc hien them moi du lieu bang pp ngat ket noi
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT_tblSINHVIEN";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using (DataTable dtSINHVIEN = new DataTable("tblSINHVIEN"))
                        {
                            adapter.Fill(dtSINHVIEN);
                            using (DataSet dataSet = new DataSet())
                            {
                                //add tung dataTable vao dataSet
                                dataSet.Tables.Add(dtSINHVIEN);

                                //them ban ghi moi vao DataTable
                                DataRow newRow = dtSINHVIEN.NewRow();
                                newRow["sMaSV"] = tb_mssv.Text.Trim();
                                newRow["dNgaySinh"] = dt_ngaySinh.Value.ToString("yyyy/MM/dd");
                                newRow["bGioiTinh"] = gioiTinh;
                                //ghi day du cac truong du lieu
                                dtSINHVIEN.Rows.Add(newRow);

                                //them ban ghi len server thong qua InsertCommand
                                cmd.CommandText = "Insert_tblSINHVIEN";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.
                                    Add("@masv", SqlDbType.VarChar, 30, "sMaSV").Value = tb_mssv.Text.Trim();
                                cmd.Parameters.AddWithValue("@ngaysinh", dt_ngaySinh.Value.ToString("yyyy/MM/dd"));
                                cmd.Parameters.AddWithValue("@gioitinh", gioiTinh);

                                adapter.InsertCommand = cmd;
                                adapter.Update(dataSet, "tblSINHVIEN");

                                MessageBox.Show("Them moi thanh cong");
                                //Tai lai du lieu len man hinh
                            }
                        }
                    }
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (rb_nam.Checked == true)
            {
                gioiTinh = true;
            }
            else
            {
                gioiTinh = false;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT_tblSINHVIEN", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using (DataTable dtSINHVIEN = new DataTable("tblSINHVIEN"))
                        {
                            adapter.Fill(dtSINHVIEN);
                            using (DataSet dataSet = new DataSet())
                            {
                                dataSet.Tables.Add(dtSINHVIEN);

                                //chinh sua du lieu trong dataTable
                                dtSINHVIEN.PrimaryKey = new DataColumn[] { dtSINHVIEN.Columns["sMaSV"] };
                                DataRow row = dtSINHVIEN.Rows.Find(tb_mssv.Text);
                                row["dNgaySinh"] = dt_ngaySinh.Value.ToString("yyyy/MM/dd");
                                row["bGioiTinh"] = gioiTinh;
                                //...

                                //thuc hien updateCommand
                                cmd.CommandText = "Update_tblSINHVIEN";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("masv", tb_mssv.Text);
                                //.....
                                adapter.UpdateCommand = cmd;
                                adapter.Update(dataSet, "tblSINHVIEN");

                                MessageBox.Show("Chinh sua thanh cong");
                                //Thuc hien phuong thuc tai lai du lieu len giao dien

                            }
                        }
                    }
                }
            }
        }

        private void dgv_dssv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_dssv.CurrentRow.Index;
            //chuyen du lieu tu dgv len cac dieu khien tuong ung
            //tb_mssv.Text = dgv_dssv.Rows[index].Cells["MaSV"].Value.ToString();
            //tb_mssv.Text = dtSINHVIEN.Rows[index]["sMaSV"].ToString();
            //dt_ngaySinh.Text = dtSINHVIEN.Rows[index]["dNgaySinh"].ToString();

            tb_mssv.Text = dvSINHVIEN[index]["sMaSV"].ToString();
            dt_ngaySinh.Text = dvSINHVIEN[index]["dNgaySinh"].ToString();

            if ((bool)(dvSINHVIEN[index]["bGioiTinh"]) == true)
            {
                rb_nam.Checked = true;
            }
            else
            {
                rb_nu.Checked = true;
            }

        }

        //private void tb_hoten_TextChanged(object sender, EventArgs e)
        //{
        //    if(this.tb_hoten.Text.Length > 0)
        //    {
        //        btn_them.Enabled = true;
        //    }
        //    else 
        //    { 
        //        btn_them.Enabled = false; 
        //    }
        //}

        //private void tb_hoten_Validating(object sender, CancelEventArgs e)
        //{
        //    if(string.IsNullOrEmpty(tb_hoten.Text))
        //    {
        //        //e.Cancel = true;
        //        errorProvider.SetError(tb_hoten, "Họ tên sinh viên không được để trống");
        //    }
        //    else
        //    {
        //        //e.Cancel = false;
        //        errorProvider.SetError(tb_hoten, null);
        //    }
        //}


    }
}
