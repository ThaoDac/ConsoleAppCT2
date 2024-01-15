using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string insert_command = "INSERT INTO tblSINHVIEN (sMaSV, dNgaySinh, bGioiTinh)" +
                                    "VALUES ('"+maSV+"','"+ngaySinh+"','"+gioiTinh+"')";
            using(SqlConnection conn = new SqlConnection(connectionString)) 
            {
                //conn.ConnectionString = connectionString;
                using(SqlCommand cmd = conn.CreateCommand()) 
                {
                    //cmd.Connection = conn;
                    cmd.CommandText = insert_command;
                    cmd.CommandType = CommandType.Text;

                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    return (i > 0);
                }
            }

        }
    }


}
