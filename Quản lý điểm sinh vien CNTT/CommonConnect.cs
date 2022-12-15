using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Diagnostics;

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    class CommonConnect
    {
        //Phương thức kết nối chung 
     

 
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;
        private SqlCommand cmd1;
        private SqlDataReader reader1;
        private SqlCommand cmd2;
        private SqlDataReader reader2;
        // Trả về đối tượng kết nối
        public  SqlConnection Connected()
        {
            string conect = SystemInformation.UserDomainName.ToString();

            string source = "Data Source="+ conect + "\\EXPRESS;Initial Catalog=Quanlydiem;Integrated Security=True";       
            conn = new SqlConnection(source);
            conn.Open();            
            return conn;   
        }
    }
}

