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
using BUS;

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmDoiMatKhau : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if((LoginBUS.Instance.UpdateUser(errorProvider1, txtTaikhoan, txtMKcu, txtMKmoi, txtConfimMk, cboQuyen) == true))
            {
                this.Close();
            }
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            conn=cc.Connected();
            if (conn.State == ConnectionState.Open) ;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
