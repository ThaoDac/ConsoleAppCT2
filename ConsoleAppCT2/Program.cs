using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.SqlServer.Server;

namespace ConsoleAppCT2
{
    internal class Program
    {
        //string connectionString = "Data Source = THINKPAD\\SQLEXPRESS;" +
        //                          "Initial Catalog = QLSV2;" +
        //                          "Integrated Security = True";
        //string connectionStr2 = "Data Source=thinkpad\\sqlexpress;" +
        //                    "Initial Catalog=QLSV2;" +
        //                    "Integrated Security=True";
       
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager
                                    .ConnectionStrings["QLSV_connectionString"]
                                    .ConnectionString;
            string maSV, ngaySinh, gioiTinh;

            Console.Write("Nhap ma sinh vien: ");
            maSV = Console.ReadLine();
            while(KiemTraKhoaChinh_SinhVien(connectionString, maSV))
            {
                Console.Write("Nhap lai ma sinh vien: ");
                maSV = Console.ReadLine();
            }

            Console.Write("Nhap ngay sinh: ");  // 13/12/2000
            DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
            ngaySinh = dateTime.ToString("yyyy/MM/dd");

            Console.Write("Nhap gioi tinh: ");   // nam NAM Nam nu nữ NỮ
            gioiTinh = Console.ReadLine();

            bool i = ThemSinhVien(connectionString, maSV, ngaySinh, IsGender(gioiTinh));
            if (i)
            {
                Console.WriteLine("them moi thanh cong");
            }
            else
            {
                Console.WriteLine("them moi khong thanh cong");
            }
        }

        private static bool IsGender (string gender)
        {
            bool index;
            if(gender.ToLower() == "nam")
            {
                index = true;
            }
            else
            {
                index = false;
            }
            return index;
        }

        private static bool ThemSinhVien(string connectionString, string maSV, string ngaySinh, bool gioiTinh)
        {
            //string insert_command = "INSERT INTO tblSINHVIEN (sMaSV, dNgaySinh, bGioiTinh)" +
            //                        "VALUES ('"+maSV+"','"+ngaySinh+"','"+gioiTinh+"')";
            string insert_proc = "Insert_tblSINHVIEN";
            using(SqlConnection conn = new SqlConnection(connectionString)) 
            {
                //conn.ConnectionString = connectionString;
                using(SqlCommand cmd = conn.CreateCommand()) 
                {
                    //cmd.Connection = conn;
                    cmd.CommandText = insert_proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    //khoi tao va truyen tham so cho proc
                    cmd.Parameters.Add("@maSV", SqlDbType.VarChar, 30).Value = maSV;
                    cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);

                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    return (i > 0);
                }
            }
        }

        private static bool KiemTraKhoaChinh_SinhVien(string connectionString, string maSV)
        {
            string checkID_proc = "KiemTraKhoaChinh_tblSINHVIEN";
            using(SqlConnection conn = new SqlConnection(connectionString)) 
            {
                //conn.ConnectionString = connectionString;
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = checkID_proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    //truyen tham so
                    cmd.Parameters.AddWithValue("@maSV", maSV);
                    conn.Open();
                    bool i = (cmd.ExecuteScalar() != null); //-> co du lieu tra ve
                    conn.Close();
                    if(i)
                    {
                        //throw new Exception("Ma sinh vien: "+maSV+" da ton tai");
                        Console.WriteLine("Ma sinh vien: " + maSV + " da ton tai");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private static void HienThiDanhSach_SinhVien(string connectionString)
        {
            string query_tblSV = "Select_tblSINHVIEN";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = query_tblSV;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                Console.WriteLine("{0}\t{1}\t{2}",
                                                reader["sMaSV"],
                                                reader["dNgaySinh"],
                                                reader["bGioiTinh"]);
                            }
                        }
                    }
                    con.Close();
                }
            }
        }

        private static void HienDDSV_NgatKetNoi(string connectionString)
        {
            string select_proc = "Select_tblSINHVIEN";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                //conn.ConnectionString = connectionString;
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = select_proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using (DataTable table = new DataTable())
                        {
                            adapter.Fill(table);
                            if(table.Rows.Count > 0)
                            {
                                //Hien thi du lieu co dieu kien
                                using(DataView dataView = table.DefaultView)
                                {
                                    dataView.RowFilter = "bGioiTinh = 'nu' AND .... OR ....";
                                    dataView.Sort = "dNgaySinh ASC";
                                    //Hien thi du lieu ra man hinh
                                    foreach (DataRowView row in dataView)
                                    {
                                        Console.WriteLine("{0}\t{1}",
                                                            row["sMaSV"],
                                                            row["dNgaySinh"]);
                                    }
                                }
                            }
                            else
                            {
                                //console "khong ton tai ban ghi nao"
                            }
                        }
                    }
                }
            }
        }

        private static bool XoaSinhVienNgatKetNoi(string connectionString, string masv)
        {
            string delete_proc = "Delete_tblSINHVIEN";
            string select_proc = "Select_tblSINHVIEN";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = select_proc;
                    cmd.CommandType= CommandType.StoredProcedure;
                    using(SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using (DataTable tblSINHVIEN = new DataTable("tblSINHVIEN"))
                        {
                            adapter.Fill(tblSINHVIEN);
                            using(DataSet dataSet = new DataSet())
                            {
                                dataSet.Tables.Add(tblSINHVIEN);

                                //tim ma sv can xoa
                                tblSINHVIEN.PrimaryKey = new DataColumn[] { tblSINHVIEN.Columns["sMaSV"] };
                                DataRow row = tblSINHVIEN.Rows.Find(masv);
                                row.Delete();

                                //Dong bo du lieu len CSDL su dung DeleteCommand
                                cmd.CommandText = delete_proc;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@masv", masv);

                                adapter.DeleteCommand = cmd;
                                int i = adapter.Update(dataSet, "tblSINHVIEN");

                                return i>0;
                            }
                        }
                    }
                }
            }
        }

        private static bool ThemSinhVienNgatKetNoi(string connectionString, string masv, string ngaysinh)
        {
            string insert_proc = "Insert_tblSINHVIEN";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                using(SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM tblSINHVIEN", conn);
                    DataTable dtSINHVIEN = new DataTable("tblSINHVIEN");
                    adapter.Fill(dtSINHVIEN);

                    //khoi tao dataset va add tung datatable vao dataset
                    DataSet dataSet = new DataSet();
                    dataSet.Tables.Add(dtSINHVIEN);
                    
                    //Them ban ghi moi vao dataTable
                    DataRow row = dtSINHVIEN.NewRow();
                    row["sMaSV"] = masv;
                    row["sNgaySinh"] = ngaysinh;
                    dtSINHVIEN.Rows.Add(row);

                    //dong bo du lieu
                    using(SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = insert_proc;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@masv", masv);
                        //.. khai bao day du cac Parameter

                        adapter.InsertCommand = cmd;
                        int i = adapter.Update(dataSet, "tblSINHVIEN");

                        return i > 0;
                    }
                }
            }
        }
    }


}
